export default class Toggle
{
    constructor()
    {

    }

    toggle()
    {
        var h2 = this;
        var div = h2.nextElementSibling;

        if(h2.className == "minus")
        {
            h2.className = "";
        }
        else
        {
            h2.className = "minus;"
        }

        if(div.className == "open")
        {
            div.className = "";
        }
        else
        {
            div.className = "open";
        }
    }

    run()
    {
        var faqs = this.$("faqs");
        var h2Elements = faqs.getElementsByTagName("h2");

        for(var i = 0; i < h2Elements.length; ++i)
        {
            h2Elements[i].onclick = this.toggle;
        }

        h2Elements[0].firstChild.focus();
    }

    $(id)
    {
        return document.getElementById(id);
    }
}