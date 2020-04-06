import Toggle from './toggle.js'


var timer;

var startUpgrade = function() {
    $("cancel").setAttribute("class", "hidden");
    $("message").firstChild.nodeValue = "Download starting...";

    $("upgrade").setAttribute("class", "hidden");
}

var cancelUpgrade = function() {
    clearTimeout(timer);
    $("upgrade").setAttribute("class", "hidden");
}

var $ = function(id) {
    return document.getElementById(id);
}

window.onload = function() {
    timer = setTimeout( startUpgrade, 5000);
    $("cancel").onclick = cancelUpgrade;

    var toggle = new Toggle();

    toggle.run();
}