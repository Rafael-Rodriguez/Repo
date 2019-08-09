"use strict";

var $ = function(id)
{
    return document.getElementById(id);
}

var joinList = function() {
    var emailAddress1 = $("emailAddress1").value;
    var emailAddress2 = $("emailAddress2").value;
    var firstName = $("firstName").value;
    var errorMessage = "";

    if(emailAddress1 == "")
    {
        errorMessage = "First email address entry required.";
        $("emailAddress1").focus();
    }
    else if(emailAddress2 == "")
    {
        errorMessage = "Second email address entry required.";
        $("emailAddress2").focus();
    }
    else if(emailAddress1 != emailAddress2)
    {
        errorMessage = "Email address entries must match";
        $("emailAddress2").focus();
    }
    else if(firstName == "")
    {
        errorMessage = "First name entry required.";
        $(firstName).focus();
    }

    if(errorMessage == "")
    {
        $("emailForm").submit();
    }
    else 
    {
        alert(errorMessage);
    }
}

var resetForm = function() {
    $("emailForm").reset();

}

window.onload = function()
{
    $("buttonJoinList").onclick = joinList;
    $("buttonResetForm").onclick = resetForm;
    $("emailAddress1").focus();
}