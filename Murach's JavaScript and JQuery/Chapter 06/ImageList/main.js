"use strict";

var $ = function(id)
{
    return document.getElementById(id);
}

window.onload = function()
{
    $("image_list").innerHTML = "<li><img src='images/bison.jpg'></li>";

    $("image_list").innerHTML += "<li><img src='images/deer.jpg'></li>";

    $("image_list").innerHTML += "<li><img src='images/hero.jpg'></li>";

    $("image_list").innerHTML += "<li><img src='images/release.jpg'></li>";
}