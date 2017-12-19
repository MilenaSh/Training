function getFirstWord(str) {
    let spacePosition = str.indexOf(' ');
    if (spacePosition === -1)
        return str;
    else
        return str.substr(0, spacePosition);
};


function addElement(size, angle, ratioOfRadius, selector, text, lines) {
    
        var parent = $(selector);
        var maxRadius = parent.width() / 2;
        var angleInRad = DegreesToRad(angle);
    
        var radius = maxRadius * ratioOfRadius;
        var top = maxRadius - Math.sin(angleInRad) * radius - size / 2;
        var left = maxRadius + Math.cos(angleInRad) * radius - size / 2;
    
        var additionalClass = getFirstWord(text);

        additionalClass = additionalClass.replace(/^\((.+)\)$/,'$1');

        var element = $("<div>")
            .addClass("element")
            .addClass(additionalClass)            
            .css("width", size*3)
            .css("height", size)
            .css("top", top)
            .css("left", left)
            .text(text);
    
        //[{ x: 200, y: 200 }, { x: 100, y: 150 }, { x: left, y: top }]
        var lines = GetLine(3, lines);
    
    
        for (var i = 0; i < lines.length; i++) {
            parent.append(lines[i])
        }
    
        $(element).hover(function () {
    
            for (var i = 0; i < lines.length; i++) {
                lines[i].addClass('hover');
            }
        }, function () {
            for (var i = 0; i < lines.length; i++) {
                lines[i].removeClass('hover');
            };
        });
    
        parent.append(element);
    
        for (var i = 0; i < lines.length; i++) {
            parent.append(lines[i]);
        }
    }
    
    
    function DegreesToRad(angle) {
        return (angle / 180) * Math.PI;
    }
    
    function RadToDegree(rad) {
        return (rad / Math.PI) * 180;
    }
    
    function GetLine(width, points) {
        let segments = [];
    
        for (var i = 0; i < points.length; i += 1) {
            let startPoint = points[i];
            let endPoint = points[i + 1];
            console.log(startPoint);
            console.log(endPoint);
    
            let lenght = Math.sqrt(Math.pow((endPoint.x - startPoint.x), 2) + Math.pow((endPoint.y - startPoint.y),
                2));
            let angle = RadToDegree(Math.atan2(endPoint.y - startPoint.y, endPoint.x - startPoint.x)) - 90;
    
            console.log("l:" + lenght);
            console.log("a:" + angle);
    
            var line = $("<div>")
                .addClass("line")
                .css("height", lenght)
                .css("width", width)
                .css("top", startPoint.y)
                .css("left", startPoint.x)
                .css("transform", "rotate(" + angle + "deg)")
                .css("transform-origin", "50% 0%");
    
            segments.push(line)
    
            if (i + 1 == points.length - 1) {
                break;
            }
        }
    
    
    
        return segments;
    }
    
    function radialToXY(r, angle, centerX, centerY) {
    
        var angleInRad = DegreesToRad(angle);
    
        var top = centerY - Math.sin(angleInRad) * r;
        var left = centerX + Math.cos(angleInRad) * r;
    
        return {
            x: left,
            y: top
        }
    }
    
    

    
    var twelveOclock = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.175 * 400, 90, 400, 200)
    ];
    
    var oneThirty = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.2 * 400, 45, 550, 250)
    ];
    
    var threeOclock = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.7 * 400, 0, 400, 400)
    ];
    
    var fourThirty = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.7 * 400, -45, 400, 400)
    ];
    
    var sixOclock = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0 * 400, 90, 400, 800)
    ];

    var sevenThirty = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.7 * 400, -135, 400, 400)
    ];
    
    var nineOclock = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.7 * 400, 0, -160, 400)
    ];
    
    var tenThirty = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.2 * 400, 45, 140, 240)
    ];
    
    //  function radialToXY(r, angle, centerX, centerY)
    
    // smaller lines

    var two= [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.4 * 400, 0, 400, 400),
        radialToXY(0.65 * 400, 15, 400, 400)
    ];

    // var threeOclock = [
    //     radialToXY(0 * 400, 0, 400, 400),
    //     radialToXY(0.7 * 400, 0, 400, 400)
    // ];

    var four = [
        radialToXY(0 * 400, 0, 400, 400),
        radialToXY(0.4 * 400, 0, 400, 400),
        radialToXY(0.65 * 400, -15, 400, 400)
    ];

    var ten= [
        radialToXY(0 * 400, 0, 150, 300),
        radialToXY(0.2 * 400, 0, 180, 400)
        
        // radialToXY(0.65 * 400, 15, 100, 400)
    ];

    var eight= [
        radialToXY(0 * 400, 0, 260, 400),
        radialToXY(0.4 * 400, 0, 0, 500)
        
        // radialToXY(0.65 * 400, 15, 100, 400)
    ];

    addElement(60, 90, 0.75, ".dandelion-menu", "environment sync", twelveOclock); //12
    addElement(60, 45, 0.8, ".dandelion-menu", "version control (revision history)", oneThirty); // 1.5
    addElement(60, 0, 1.1, ".dandelion-menu", "multilingual", threeOclock); // 3
    addElement(60, -45, 0.8, ".dandelion-menu", "modular", fourThirty); // 4.5
    
    
    addElement(0, -90, 1, ".dandelion-menu", "", sixOclock); // 6
    addElement(60, -145, 1, ".dandelion-menu", "blogs", sevenThirty); // 7.5
    
    addElement(60, -178, 1.4, ".dandelion-menu", "tagging", nineOclock); // 9
    
    addElement(60, 145, 1, ".dandelion-menu", "content import tool", tenThirty); // 10.5
    
    
    addElement(60, 15, 1, ".dandelion-menu", "auto sitemap", two); // 2
    addElement(60, -15, 1, ".dandelion-menu", "forums", four); // 4

    addElement(60, -165, 1.2, ".dandelion-menu", "(DOS) attack protection", eight); // 8
    addElement(60, -193, 1.2, ".dandelion-menu", "dynamic content", ten); // 10
    
    //          function addElement(size, angle, ratioOfRadius, selector, text, lines)
    
    