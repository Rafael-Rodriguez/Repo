"use strict";

var $ = function(id)
{
    return document.getElementById(id);
}

var joinList = function() {
    var emailAddress1 = $("emailAddress1").value;
    var emailAddress2 = $("emailAddress2").value;
    var firstName = $("firstName").value;
    var passedErrorCheck = true;

    if(emailAddress1 == "")
    {
        $("emailAddress1").nextElementSibling.firstChild.nodeValue = "First email address entry required.";
        $("emailAddress1").focus();
        passedErrorCheck = false;
    }
    
    
    if(emailAddress2 == "")
    {
        $("emailAddress2").nextElementSibling.firstChild.nodeValue = "Second email address entry required.";
        $("emailAddress2").focus();
        passedErrorCheck = false;
    }

    if(emailAddress1 != emailAddress2)
    {
        var errorMessage = "Email address entries must match";
        $("emailAddress1").nextElementSibling.firstChild.nodeValue = errorMessage;
        $("emailAddress2").nextElementSibling.firstChild.nodeValue = errorMessage;
        $("emailAddress2").focus();
        passedErrorCheck = false;
    }
    
    if(firstName == "")
    {
        $("firstName").nextElementSibling.firstChild.nodeValue = "First name entry required.";
        $("firstName").focus();
        passedErrorCheck = false;
    }
    
    if(passedErrorCheck)
    {
        $("emailForm").submit();
    }
}

var resetForm = function() {
    $("emailForm").reset();
    $("emailAddress1").nextElementSibling.firstChild.nodeValue = "*";
    $("emailAddress2").nextElementSibling.firstChild.nodeValue = "*";
    $("firstName").nextElementSibling.firstChild.nodeValue = "*";
}

window.onload = function()
{
    $("buttonJoinList").onclick = joinList;
    $("buttonResetForm").onclick = resetForm;
    $("emailAddress1").focus();
}