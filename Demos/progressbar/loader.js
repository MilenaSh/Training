var Loader = (function(){
    
    function next(){
        // accepts data.auto

        $(window).one("animationend", function() {
            start();
        });
    }

    function stop(){

    }

    function build(data){

        // var numberSections = Object.keys(data).length;
        var numberSections = data.sections.length;

        var width = 100 / numberSections;

        var mainContainer = $('<div>');
        mainContainer.addClass('main-container');

        $('body').append(mainContainer);

        var barContainer = $('<div>');
        barContainer.addClass('bar-container');

        mainContainer.append(barContainer);

        progressContainer = $('<ul>');
        progressContainer.addClass('progress-container');
        progressContainer.attr('id', 'bar');
        progressContainer.attr('data-currentIndx', '1');

        var order = 0;

        for (var section in data) {
            var listItem = $('<li>').addClass('section').attr('data-section', `${order}`).attr('style', `width:${data[section].size}%; height:100%;`);
            var divItem = $('<div>').addClass('progress-bar');

            listItem.append(divItem);
            progressContainer.append(listItem);

            order++;
    }
}


    function force(){

        // force if previous ended sooner

    }

    function start(data, currentId) {
        
        var currentBarSection = $($($('#bar').find("[data-section='" + currentId + "']")[0]).find('.progress-bar')[0]);
        
        if (currentBarSection == null) {
            return;
        }
        if (currentBarSection.hasClass('activation') && currentBarSection.css("animation-play-state") == "running") {
            return;
        }

        currentBarSection.addClass('activation');
        currentBarSection.css("animation-play-state", "running");
        currentBarSection.css("animation-duration", `${data[currentId].estimatedTime}s`);

        let messageContainer = $('.progress-message');
        messageContainer.html('Loading ' + data[currentId].name);

        let label = $('.progress-label');
        var currentProgress = 0;
        var endProgress = 0;

        for(let item in data){
            if(item > currentId){
                break;
            }
            if(item< currentId){
                currentProgress +=data[item].size;
            }
            endProgress +=data[item].size;

        }
        
        $('.progress-label').text(currentProgress);
        
        $({
            progress : currentProgress
        })
        .animate({
            progress:endProgress
        },
        {
            duration:2000,
            step: function(){
                label.text(Math.floor(this.progress)+" %");
            },   
            complete: function() {
                label.text(this.progress+" %");
            }             
        })

        // console.log(currentId);

        // $(currentBarSection).one('animationend', function(){
        //     start(data, currentId+1);
        // })

        // goes in next()
        
    }
    
    var data = {
        sections :[
            {
                name: "First section",
                estimatedTime: 3,
                isLoaded: false,
            },
            {
                name: "Second section",
                estimatedTime: 4,
                isLoaded: false,
            },
            {
                name: "Thurd section",
                estimatedTime: 1,
                isLoaded: false,
            },
            {
                name: "Fourth section",
                estimatedTime: 3,
                isLoaded: false,
            },
            {
                name: "Fifth section",
                estimatedTime: 2,
                isLoaded: false,
            }
        ],
        auto : true,   // automatically start next
        allowForce : false,
}


$(sdasdas).data('stloader')

    return{
        buildLoader: build,
        start: start,
        stop: stop,
        next: next,
        forceCurrent : force
    }
}())