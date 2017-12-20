function getFirstWord(str) {
    let spacePosition = str.indexOf(' ');
    if (spacePosition === -1)
        return str;
    else
        return str.substr(0, spacePosition);
};



function addLine(selector, lines) {
    var parent = $(selector);

    var lines = GetLine(2, lines);


    for (var i = 0; i < lines.length; i++) {
        parent.append(lines[i])
            .addClass('diamondLine');
    }

    // $(".diamondLine").hover(function () {

    //     for (var i = 0; i < lines.length; i++) {
    //         lines[i].addClass('hover');
    //     }
    // }, function () {
    //     for (var i = 0; i < lines.length; i++) {
    //         lines[i].removeClass('hover');
    //     };
    // });

    for (var i = 0; i < lines.length; i++) {
        parent.append(lines[i]);
    }
}

// function addcircle(selector, lines) {
//     var parent = $(selector);

//     var lines = GetLine(2, lines);


//     var smallCircle = $("<div>")
//         .addClass("small-circle");


//     for (var i = 0; i < lines.length; i++) {
//         parent.append(lines[i])
//             .addClass('diamondLine');
//     }

//     // $(".diamondLine").hover(function () {

//     //     for (var i = 0; i < lines.length; i++) {
//     //         lines[i].addClass('hover');
//     //     }
//     // }, function () {
//     //     for (var i = 0; i < lines.length; i++) {
//     //         lines[i].removeClass('hover');
//     //     };
//     // });

//     parent.append(smallCircle);

//     for (var i = 0; i < lines.length; i++) {
//         parent.append(lines[i]);
//     }
// }

var index = 0;

function addElement(size, angle, ratioOfRadius, selector, text, lines) {

    var parent = $(selector);
    var maxRadius = parent.width() / 2;
    var angleInRad = DegreesToRad(angle);

    var radius = maxRadius * ratioOfRadius;
    var top = maxRadius - Math.sin(angleInRad) * radius - size / 2;
    var left = maxRadius + Math.cos(angleInRad) * radius - size / 2;

    // var additionalClass = getFirstWord(text);

    // additionalClass = additionalClass.replace(/^\((.+)\)$/, '$1');

    // var additionalClass = ["0", "30", "60", "80", "90", "120", "150", "180","210", "240", "270", "300", "330", "350"]

    var element = $("<div>")
        .addClass("element")
       //.addClass(additionalClass)
        .css("width", size * 3)
        .css("height", size)
        .css("top", top)
        .css("left", left)
        .text(text);

        element.attr("data-order", index);

       
        console.log(index);

        index++;

        

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
      //  console.log(startPoint);
      //  console.log(endPoint);

        let lenght = Math.sqrt(Math.pow((endPoint.x - startPoint.x), 2) + Math.pow((endPoint.y - startPoint.y),
            2));
        let angle = RadToDegree(Math.atan2(endPoint.y - startPoint.y, endPoint.x - startPoint.x)) - 90;

      //  console.log("l:" + lenght);
     //   console.log("a:" + angle);

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

var two = [
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
    radialToXY(0.65 * 400, -15, 400, 400),
    // radialToXY(1 * 400, -15, 400, 400)

];

var ten = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.4 * 400, 180, 400, 400),
    radialToXY(0.65 * 400, 165, 400, 400)

    // radialToXY(0.65 * 400, 15, 100, 400)
];

var eight = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.4 * 400, 180, 400, 400),
    radialToXY(0.65 * 400, 195, 400, 400),


];

var eleven = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.4 * 400, 90, 400, 400),
    radialToXY(0.65 * 400, 105, 400, 400)
];


var one = [
    radialToXY(0 * 400, 0, 400, 400),
    radialToXY(0.4 * 400, 90, 400, 400),
    radialToXY(0.65 * 400, 75, 400, 400)
];



addElement(70, 90, 0.75, ".dandelion-menu", "environment sync", twelveOclock); //12
addElement(90, 65, 0.8, ".dandelion-menu", "import tool (Sitefinity content)", one); // 1
addElement(70, 45, 0.8, ".dandelion-menu", "version control (revision history)", oneThirty); // 1.5
addElement(60, 15, 1, ".dandelion-menu", "auto sitemap", two); // 2
addElement(60, 0, 1.1, ".dandelion-menu", "multilingual", threeOclock); // 3
addElement(60, -15, 1, ".dandelion-menu", "forums", four); // 4
addElement(60, -45, 0.8, ".dandelion-menu", "modular", fourThirty); // 4.5
addElement(60, -145, 1, ".dandelion-menu", "blogs", sevenThirty); // 7.5
addElement(60, -165, 1.2, ".dandelion-menu", "(DOS) attack protection", eight); // 8
addElement(60, -178, 1.4, ".dandelion-menu", "tagging", nineOclock); // 9
addElement(60, -193, 1.2, ".dandelion-menu", "dynamic content", ten); // 10
addElement(60, 145, 1, ".dandelion-menu", "content import tool", tenThirty); // 10.5
addElement(70, 130, 0.9, ".dandelion-menu", "search (Google integration)", eleven); // 11


//          function addElement(size, angle, ratioOfRadius, selector, text, lines)

// 

var mainDiamondLine = [
    radialToXY(1.5 * 400, 180, 400, 800),
    radialToXY(1.5 * 400, 0, 400, 800),
];

var upperMainLine = [
    radialToXY(1.5 * 400, 180, 400, 800),
    radialToXY(1 * 400, 180, 400, 760),
    radialToXY(1 * 400, 0, 400, 760),
    radialToXY(1.5 * 400, 0, 400, 800)
];

var downMainLine = [
    radialToXY(1.5 * 400, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870),
    radialToXY(1.5 * 400, 0, 400, 800),
];

var firstVertical = [
    radialToXY((1.5 * 400) - 100, 180, 400, 800),
    radialToXY(1 * 400, 180, 400, 760)
];

var secondVertical = [
    radialToXY((1.5 * 400) - 200, 180, 400, 800),
    radialToXY(1 * 400, 180, 400, 760)
];

var thirdVertical = [
    radialToXY((1.5 * 400) - 300, 180, 400, 800),
    radialToXY(1 * 300, 180, 400, 760)
];

var fourthVertical = [
    radialToXY((1.5 * 400) - 400, 180, 400, 800),
    radialToXY(1 * 200, 180, 400, 760)
];

var fifthVertical = [
    radialToXY((1.5 * 400) - 500, 180, 400, 800),
    radialToXY(1 * 100, 180, 400, 760)
];

var sixthVertical = [
    radialToXY((1.5 * 400) - 700, 180, 400, 800),
    radialToXY(1 * -100, 180, 400, 760)
];

var seventhVertical = [
    radialToXY((1.5 * 400) - 800, 180, 400, 800),
    radialToXY(1 * -200, 180, 400, 760)
];

var eigthVertical = [
    radialToXY((1.5 * 400) - 900, 180, 400, 800),
    radialToXY(1 * -300, 180, 400, 760)
];

var ninthVertical = [
    radialToXY((1.5 * 400) - 1000, 180, 400, 800),
    radialToXY(1 * -400, 180, 400, 760)
];

var firstDownVertical = [
    radialToXY((1.5 * 400) - 200, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var secondDownVertical = [
    radialToXY((1.5 * 400) - 300, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var thirdDownVertical = [
    radialToXY((1.5 * 400) - 400, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var fourthDownVertical = [
    radialToXY((1.5 * 400) - 500, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var fifthDownVertical = [
    radialToXY((1.5 * 400) - 600, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var sixthDownVertical = [
    radialToXY((1.5 * 400) - 700, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var seventhDownVertical = [
    radialToXY((1.5 * 400) - 900, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];

var eigthDownVertical = [
    radialToXY((1.5 * 400) - 1000, 180, 400, 800),
    radialToXY(0 * 400, 180, 400, 870)
];


addLine(".dandelion-menu", sixOclock); // 6

addLine(".dandelion-menu", mainDiamondLine);

addLine(".dandelion-menu", upperMainLine);
addLine(".dandelion-menu", downMainLine);

addLine(".dandelion-menu", firstVertical);
addLine(".dandelion-menu", secondVertical);
addLine(".dandelion-menu", thirdVertical);
addLine(".dandelion-menu", fourthVertical);
addLine(".dandelion-menu", fifthVertical);
addLine(".dandelion-menu", sixthVertical);
addLine(".dandelion-menu", seventhVertical);
addLine(".dandelion-menu", eigthVertical);
addLine(".dandelion-menu", ninthVertical);

addLine(".dandelion-menu", firstDownVertical);
addLine(".dandelion-menu", secondDownVertical);
addLine(".dandelion-menu", thirdDownVertical);
addLine(".dandelion-menu", fourthDownVertical);

addLine(".dandelion-menu", fifthDownVertical);
addLine(".dandelion-menu", sixthDownVertical);
addLine(".dandelion-menu", seventhDownVertical);
addLine(".dandelion-menu", eigthDownVertical);