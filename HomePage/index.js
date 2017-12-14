
function addElement(size, angle, ratioOfRadius, selector, text, lines) {

    var parent = $(selector);
    var maxRadius = parent.width() / 2;
    var angleInRad = DegreesToRad(angle);

    var radius = maxRadius * ratioOfRadius;
    var top = maxRadius - Math.sin(angleInRad) * radius - size / 2;
    var left = maxRadius + Math.cos(angleInRad) * radius - size / 2;

    var element = $("<div>")
        .addClass("element")
        .css("width", size)
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

var threeOclock = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.7 * 400, 0, 400, 400)
];

var nineOclock = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.7 * 400, 0, -160, 400)
];

var twelveOclock = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.3 * 400, 90, 400, 200)
];

var sixOclock = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.3 * 400, 90, 400, 800)
];

var oneThirty = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.2 * 400, 45, 640, 240)
];

var tenThirty = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.2 * 400, 45, 140, 240)
];

//  function radialToXY(r, angle, centerX, centerY)

// var lines2 = [
//     radialToXY(0 * 400, 0, 400, 400),
//     radialToXY(0.375 * 400, 0, 400, 400),
//     radialToXY(0.6 * 400, 15, 400, 400)
// ];
// var lines3 = [
//     radialToXY(0 * 400, 0, 400, 400),
//     radialToXY(0.375 * 400, 0, 400, 400),
//     radialToXY(0.6 * 400, -15, 400, 400)
// ];

addElement(30, 0, 0.75, ".dandelion-menu", "3", threeOclock);
addElement(30, -180, 0.75, ".dandelion-menu", "9", nineOclock);
addElement(30, 90, 0.75, ".dandelion-menu", "12", twelveOclock);
addElement(30, -90, 0.75, ".dandelion-menu", "6", sixOclock);

addElement(30, 45, 0.8, ".dandelion-menu", "1", oneThirty);
addElement(30, 135, 0.8, ".dandelion-menu", "10", tenThirty);


// addElement(30, 15, 0.75, ".dandelion-menu", "30", lines2);
// addElement(30, -15, 0.75, ".dandelion-menu", "-30", lines3);

//          function addElement(size, angle, ratioOfRadius, selector, text, lines)
