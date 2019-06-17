"use strict";

var $ = function(id)
{
    return document.getElementById(id);
}

var calculateMpg = function(miles, gallons)
{
    var mpg = (miles/gallons);
    
    mpg = mpg.toFixed(1);

    return mpg;
}

var processEntries = function() 
{
    var miles = parseFloat($("miles").value);
    var gallons = parseFloat($("gallons").value);

    if(isNaN(miles))
    {
        alert("miles must be numeric");
    }
    else if(isNaN(gallons))
    {
        alert("gallons must be numeric");
    }
    else if(miles <= 0)
    {
        alert("miles must be greater than zero");
    }
    else if(gallons <= 0)
    {
        alert("gallons must be greater than zero");
    }
    else if(gallons > miles)
    {
        alert("The number of gallons must be less than or equal to the number of miles driven");
    }
    else
    {
        $("mpg").value = calculateMpg(miles, gallons);
    }
}

var clearEntries = function() 
{
    $("miles").value = "";
    $("gallons").value = "";
    $("mpg").value = "";

    $("miles").focus();
}

window.onload = function()
{
    $("calculate").onclick = processEntries;
    $("clearEntries").onclick = clearEntries;
    $("miles").focus();
}