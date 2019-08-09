"use strict";

var $ = function(id) 
{
    return document.getElementById(id);
};

var calculateMpg = function(miles, gallons) 
{
    var mpg = (miles/gallons);
    mpg = mpg.toFixed(1);
    return mpg;
};

var processEntries = function() 
{
    var miles = parseFloat($("milesDriven").value);
    var gallons = parseFloat($("gallonsGasUsed").value);

    if(isNaN(miles) || isNaN(gallons))
    {
        alert("Both entries must be numeric");
    }
    else if(miles <= 0 || gallons <= 0) 
    {
        alert("Both entries must be greater than zero");
    }
    else
    {
        $("mpg").value = calculateMpg(miles, gallons);
    }
};

var clearEntries = function()
{
    $("milesDriven").value = "";
    $("gallonsGasUsed").value = "";
    $("mpg").value = "";
    $("mpg").focus();
};

window.onload = function() {
    $("calculate").onclick = processEntries;
    $("clearEntries").onclick = clearEntries;
    $("milesDriven").focus();
};