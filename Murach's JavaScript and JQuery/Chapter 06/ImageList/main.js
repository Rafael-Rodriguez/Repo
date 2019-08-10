"use strict";

var $ = function(id)
{
    return document.getElementById(id);
}

var initializeImageSwap = function()
{
    var listNode = $("imageList");
    var captionNode = $("caption");
    var imageNode = $("mainImage");


    var imageLinks = listNode.getElementsByTagName("a");
    
    var i, image, linkNode, link;
    for(i = 0; i < imageLinks.length; ++i)
    {
        linkNode = imageLinks[i];

        //preload image
        image = new Image();
        image.src = linkNode.getAttribute("href");

        link = createOnClickCallback(link, imageNode, captionNode, linkNode);
    }

    imageLinks[0].focus();
}

window.onload = function()
{
    initializeImageSwap();
}

function createOnClickCallback(link, imageNode, captionNode, linkNode) {
    linkNode.onclick = function (event) {
        link = this; // "This" is the link that was clicked
        imageNode.src = link.getAttribute("href");
        captionNode.firstChild.nodeValue = link.getAttribute("title");
        //cancel the default action of the event
        if (!event) {
            event = window.event;
        }
        if (event.preventDefault) {
            event.preventDefault();
        }
        else {
            event.returnFalse = false;
        }
    };
    return link;
}
