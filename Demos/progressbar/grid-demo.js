'use strict'

var Grid = function () {

    //var gridConfig = {
    //    columns : [],
    //    pager : {},
    //    data : {},
    //    filters : {},
    //    sorting : {},
    //    additional : {}
    //}

    /*var gridData = {
        items : [],
        filters : [],
        sortedColumn : [],
        page: int
        pageSize :int
    }*/

    function validateCol(colConfig) {

        //TODO; Validation for conConfig

        return true;
    }

    function buildColumnConfig(colConfigs, config) {
        config.columns = [];

        for (var i = 0; i < colConfigs.length; i++) {
            if (validateCol(colConfigs[i])) {
                config.columns.push(colConfigs[i]);
            }
        }

        return config;
    }

    function buildPagerConfig(pagerData, config) {
        // validations
        if (!Array.isArray(pagerData.pageSizes)) {
            throw Error("pageSizes not array");
        }

        let def = undefined;
        for (var i = 0; i < pagerData.pageSizes.length; i++) {
            var item = pagerData.pageSizes[i];

            if (+item == NaN || +item < 0) {
                throw Error("pageSizes not a number");
            }

            if (item === pagerData.default) {
                def = pagerData.default;
            }
        }

        config.pager = {};
        config.pager.pageSizes = pagerData.pageSizes;
        config.pager.pageReadOnly = pagerData.pageReadOnly;
        config.pager.default = def;

        return config;
    }

    function buildDataConfig(dataConfig, config) {
        var sources = "/allnews";
        config.data = {};
        config.data.onGetData = getData;
        config.data.link = dataConfig.link;
        config.data.serverSide = dataConfig.serverSide;

        return config;
    }

    function getData(data) {
        return new Promise((resolve, reject) => {
            Loader.show(true);

            let body;
            if (data.config.data.serverSide) {
                body = {
                    skip: (data.page - 1) * data.pageSize,
                    take: data.pageSize
                }
            } else {
                body = {};
            }

            body.filters = data.filters || [];

            $.ajax({
                url: data.config.data.link,
                method: 'POST',
                data: body,
                success: resolve,
                error: reject
            }).then(function (res) {
                Loader.hide();
                return res;
            });
        });
    }

    function updateData(table) {

        var data = $(table).data('sitetriksGird');
        let config = $(table).data('sitetriksGird').config;
        if (config.data.serverSide == true) {
            return getData(data)
                .then(function (res) {
                    if (res.success) {
                        data.items = res.items;
                        data.filterItems = data.items;
                    }

                    if (res.nextPageExists) {
                        data.nextPageExists = true;
                    } else {
                        data.nextPageExists = false;
                    }

                    $(table).data('sitetriksGird', data);

                    return res;
                });
        }
        else {
            return new Promise((resolve, reject) => {
                var items = data.items;

                var filteredItems = clientSideFilter(items, data.filters);

                var sortedItems = clientSideSorting(filteredItems, data.sortingRule);

                var pagedData = clientSidePaging(sortedItems, data.page - 1, data.pageSize);

                if ((pagedData.length < data.pageSize) || ((data.page) * data.pageSize >= sortedItems.length)) {
                    data.nextPageExists = false;
                } else {
                    data.nextPageExists = true;
                }

                data.filterItems = pagedData;

                $(table).data('sitetriksGird', data);

                resolve({ success: true, items: data.filteredItems });
            });
        }
    }

    function clientSidePaging(items, page, pageSize) {
        let start = page * pageSize;
        let end = start + +pageSize;
        if (end > items.length) {
            end = items.length;
        }

        return items.slice(start, end);
    }

    function clientSideSorting(items, sortingRule) {
        if (sortingRule == null) {
            return items;
        }
        //{name, direction} name - name of field/column, direction - is ascedning
        var sorted = items;
        var direction = 1;
        if (!sortingRule.isAscending) {
            direction = -1;
        }
        sorted = sorted.sort(function (a, b) {
            if (a > b) {
                return 1 * direction;
            }

            if (a < b) {
                return -1 * direction;
            }

            return 0;
        })

        return sorted;

    }

    function clientSideFilter(items, filters) {
        // filter structure
        // { name, type, value}

        var result = items; // array

        for (var i = 0; i < filters.length; i++) {
            if (result.length == 0) {
                break;
            }

            var filter = filters[i];

            if (filter.value == null) {
                continue;
            }

            if (filter.comparison === 7) {
                result = result.filter(function (item) {
                    return filterStringContains(item, filter.propertyName, filter.value);
                })
            }

            if (filter.comparison === 4) {
                result = result.filter(function (item) {
                    return filterNumberGreater(item, filter.propertyName, filter.value);
                })
            }

            if (filter.comparison === 1) {
                result = result.filter(function (item) {
                    return filterNumberEquals(item, filter.propertyName, filter.value);
                })
            }

            if (filter.comparison === 2) {
                result = result.filter(function (item) {
                    return filterNumberSmaller(item, filter.propertyName, filter.value);
                })
            }
        }

        return result;
    }

    // filter functions
    function filterNumberGreater(item, field, value) {
        return item[field] > value;
    }

    function filterNumberSmaller(item, field, value) {
        return item[field] < value;
    }

    function filterNumberEquals(item, field, value) {
        return item[field] == value;
    }

    function filterStringContains(item, field, value) {
        return item[field].includes(value);
    }
    // end of filter functions

    //paging
    function onNextPage(table) {
        $(table).data('sitetriksGird').page += 1;
        return updateData(table);
    }

    function onPreviousPage(table) {
        if ($(table).data('sitetriksGird').page > 0) {
            $(table).data('sitetriksGird').page -= 1;
            return updateData(table);
        }

        return Promise.reject(new Error('wtf onPreviousPage'));
    }

    function onSetPage(table, page) {
        var data = $(table).data('sitetriksGird');
        let condition = data.pageSize * (page - 1) < data.filterItems.length;
        if (page > 0 && condition) {
            $(table).data('sitetriksGird').page = page;
            return updateData(table)
        }

        return Promise.reject(new Error('wtf onSetPage'));
    }

    // set pagesize
    function setPageSize(pageSize, table) {
        // get all data
        //var data = $(table).data('sitetriksGird');

        //if (pageSizeIndex < 0 && table.data('sitetriksGird').config.pager.pageSizes.length <= pageSizeIndex) {
        //    throw new Error("Invalid page size");
        //}

        //$(table).data('sitetriksGird').pageSize = table.data('sitetriksGird').config.pager.pageSizes[pageSizeIndex];

        // changed to pageSize from index, simplifies testing
        $(table).data('sitetriksGird').pageSize = pageSize;
        $(table).data('sitetriksGird').page = 1;

        // update the table according to the page size
        return updateData(table);
    }

    function buildGridConfig(columns, buttons, pager, data) {

        var config = {};

        config = buildColumnConfig(columns, config);
        config = buildPagerConfig(pager, config);
        config = buildDataConfig(data, config);
        config.buttons = buttons;

        return config;
    }

    function init(selector, config) {
        let pageSize = config.pager.pageSizes[0];
        if (config.pager.default) {
            pageSize = config.pager.default;
        }

        let page = 1;

        config.data.onGetData({ config: config, page: page, pageSize: pageSize }).then(function (res) {
            if (res.success) {

                var $parent = $(selector);

                var $table = $('<table>')
                    .attr('id', 'test');

                let items = res.items
                let filterItems;

                let nextPageExists;

                if (config.data.serverSide) {
                    if (res.nextPageExists) {
                        nextPageExists = true;
                    } else {
                        nextPageExists = false;
                    }

                    filterItems = items;
                } else {
                    filterItems = clientSidePaging(items, page - 1, pageSize);

                    if ((filterItems.length < pageSize) || ((page) * pageSize >= items.length)) {
                        nextPageExists = false;
                    } else {
                        nextPageExists = true;
                    }
                }

                $table.data('sitetriksGird',
                    {
                        config: config,
                        items: items,
                        filterItems: filterItems,
                        filters: [],
                        sortedColumn: {},
                        page: page,
                        pageSize: pageSize,
                        getData: config.data.onGetData,
                        updateData: updateData,
                        nextPage: onNextPage,
                        previousPage: onPreviousPage,
                        setPage: onSetPage,
                        nextPageExists: nextPageExists
                    });

                createHeader($table);
                createBody($table);
                createPager($table);

                $parent.on('click', '#nextPageArrow', function (ev) {
                    if ($table.data('sitetriksGird').nextPageExists) {
                        onNextPage($table).then(function () {
                            updateBody($table);

                            $('#previousPageArrow').removeClass('btn-disabled');
                            if (!$table.data('sitetriksGird').nextPageExists) {
                                $('#nextPageArrow').addClass('btn-disabled');
                            }

                            $('#pageNumber').text($table.data('sitetriksGird').page);
                        });
                    }
                })

                $parent.on('click', '#previousPageArrow', function (ev) {
                    if ($table.data('sitetriksGird').page > 1) {
                        onPreviousPage($table).then(function () {
                            updateBody($table);

                            $('#nextPageArrow').removeClass('btn-disabled');
                            if ($table.data('sitetriksGird').page <= 1) {
                                $('#previousPageArrow').addClass('btn-disabled');
                            }

                            $('#pageNumber').text($table.data('sitetriksGird').page);
                        });
                    }
                })

                $parent.on('change', '#pageSize', function (ev) {
                    let pageSize = $(this).val();
                    setPageSize(pageSize, $table).then(function () {
                        updateBody($table);

                        $('#nextPageArrow').removeClass('btn-disabled');
                        if ($table.data('sitetriksGird').page <= 1) {
                            $('#previousPageArrow').addClass('btn-disabled');
                        }

                        if (!$table.data('sitetriksGird').nextPageExists) {
                            $('#nextPageArrow').addClass('btn-disabled');
                        }

                        $('#pageNumber').text($table.data('sitetriksGird').page);
                    });
                })

                createButtons($table).appendTo($parent);

                $table.appendTo($parent);
            }
        });
    }

    function createButtons($table) {
        let $fragment = $(document.createElement('div'))
            .addClass('buttons-row');
        let tableId = $table.attr('id');

        // -----------------------------------------------
        // serch logic; TODO: move!

        //$(document.createElement('input'))
        //    .attr('type', 'text')
        //    .attr('id', 'search-field')
        //    .appendTo($fragment);

        $(document.createElement('a'))
            .text('Search')
            .addClass('btn btn-info')
            .on('click', function (ev) {
                let $fields = $('.search-field');

                let data = $table.data('sitetriksGird');
                data.filters = [];

                $fields.each(function (index, elem) {
                    let $element = $(elem);
                    let pattern = $element.val();

                    if (pattern && pattern.length >= 1) {
                        let comparison;
                        switch ($element.attr('data-type')) {
                            case 'string':
                                comparison = 7;
                                break;
                            case 'number':
                                comparison = 1;
                                break;
                            default:
                        }

                        data.filters.push({
                            propertyName: $element.attr('data-property'),
                            comparison: 7,
                            value: pattern
                        })
                    }
                })

                data.page = 1;

                $table.data('sitetriksGrid', data);
                updateData($table)
                    .then(function (res) {

                        $('#nextPageArrow').removeClass('btn-disabled');
                        if ($table.data('sitetriksGird').page <= 1) {
                            $('#previousPageArrow').addClass('btn-disabled');
                        }

                        if (!$table.data('sitetriksGird').nextPageExists) {
                            $('#nextPageArrow').addClass('btn-disabled');
                        }

                        $('#pageNumber').text($table.data('sitetriksGird').page);

                        updateBody($table);
                    });
            })
            .appendTo($fragment);

        // -----------------------------------------------

        let buttons = $table.data('sitetriksGird').config.buttons;

        buttons.forEach(function (element, index) {
            $(document.createElement('a'))
                .text(element.title)
                .addClass(element.classes)
                .on('click', function (ev) {

                    let ids = [];
                    $('#' + tableId).find('input[type=checkbox]:checked').each(function (ind, el) { ids.push($(el).attr('data-id')) });

                    if (ids.length > 0) {

                        Loader.show(true);

                        $.ajax({
                            url: element.postUrl,
                            method: 'POST',
                            data: { ids: ids },
                            success: function (res) {
                                Loader.hide();
                                element.callback(res);
                            }
                        })
                    }
                })
                .appendTo($fragment);
        })

        return $fragment;
    }

    function createHeader($table) {
        // add thead
        let config = $table.data('sitetriksGird').config;

        var tHead = $('<thead>').appendTo($table);
        tHead.attr('id', "tableHeader");

        // get column configuration

        var columnConfiguration = config.columns;

        // create header row
        var headerRow = $('<tr>');

        // add header cell for each configuration and use the title property for the text
        for (var i = 0; i < columnConfiguration.length; i++) {
            let content;
            if (columnConfiguration[i].headerTemplate) {
                content = columnConfiguration[i].headerTemplate.replace('#item#', columnConfiguration[i].title)
            } else {
                content = columnConfiguration[i].title;
            }

            let $cell = $('<th>').html(content);

            if (columnConfiguration[i].filter) {

                $(document.createElement('input'))
                    .attr('type', 'text')
                    .attr('data-property', columnConfiguration[i].name)
                    .attr('data-type', columnConfiguration[i].type)
                    .attr('class', 'search-field')
                    .appendTo($cell);
            }

            headerRow.append($cell);
        }

        // append header row
        headerRow.appendTo(tHead);
    }

    function createBody($table) {
        // add tbody
        let $tBody = $('<tbody>');
        $tBody.attr('class', "tableBody");

        buildBody($table, $tBody)
            .appendTo($table);
    }

    function updateBody($table) {
        // add tbody
        let $tBody = $('.tableBody');
        $tBody.html('');

        buildBody($table, $tBody);
    }

    function buildBody($table, $tBody) {
        let data = $table.data('sitetriksGird');
        let config = $table.data('sitetriksGird').config;
        let pageSize = $table.data('sitetriksGird').pageSize;

        // get data
        var tableData = data.filterItems;
        pageSize = pageSize || tableData.length;
        if (pageSize > tableData.length) {
            pageSize = tableData.length;
        }

        // get column configuration
        var columnConfiguration = config.columns;

        // for each item add row and fill in cells corresponding to column configuration
        for (var i = 0; i < pageSize; i++) {
            var bodyRow = $('<tr>');
            bodyRow.attr('class', "bodyRow");
            // for each column create a cell and fill it in with the column.name corresponding field

            for (var j = 0; j < columnConfiguration.length; j++) {

                let content;

                switch (columnConfiguration[j].type) {
                    case 'checkbox':
                        content = `<input type="checkbox" data-id="${tableData[i][columnConfiguration[j].name]}"/>`;

                        break;

                    default:
                        if (columnConfiguration[j].contentTemplate) {
                            content = columnConfiguration[j].contentTemplate.replace('#item#', tableData[i][columnConfiguration[j].name])
                        } else {
                            content = tableData[i][columnConfiguration[j].name];
                        }
                        break;
                }

                $('<td>').html(content)
                    .appendTo(bodyRow);
            }

            //bodyRow.appendTo($tBody);
            $tBody.append(bodyRow);
        }
        return $tBody;
    }

    function createPager($table) {
        let config = $table.data('sitetriksGird').config;
        // add tfooter
        var tFooter = $('<tfoot>').appendTo($table);

        // get pager configuration
        var pagerConfiguration = config.pager;
        let def = pagerConfiguration.default;

        // add pager row
        var pagerRow = $('<tr>');

        // create previous and next arrow

        var pagerContainer = $('<td>');
        pagerContainer.attr('id', "pagerContainer");

        var previousPageArrow = $('<span>').addClass("glyphicon glyphicon-arrow-left btn-pager btn-disabled");
        previousPageArrow.attr('id', "previousPageArrow");

        var nextPageArrow = $('<span>').addClass("glyphicon glyphicon-arrow-right btn-pager");
        nextPageArrow.attr('id', "nextPageArrow");
        if (!$table.data('sitetriksGird').nextPageExists) {
            nextPageArrow.addClass('btn-disabled');
        }

        // page size

        var pageSize = $('<select>');
        pageSize.attr('id', "pageSize");

        pagerConfiguration.pageSizes.forEach(function (element, index) {
            let $option = $(document.createElement('option'))
                .val(element)
                .text(element);

            if (def && +def === +element) {
                $option.attr('selected', 'selected');
            }

            $option.appendTo(pageSize);
        });

        // page number
        var pageNumber = $('<span>').text(1);
        pageNumber.attr('id', "pageNumber");

        // append elements
        pageSize.appendTo(pagerContainer);
        previousPageArrow.appendTo(pagerContainer);
        pageNumber.appendTo(pagerContainer);
        nextPageArrow.appendTo(pagerContainer);

        pagerContainer.appendTo(pagerRow);
        pagerRow.appendTo(tFooter);
    }

    return {
        init: init,
        build: buildGridConfig
    };
}