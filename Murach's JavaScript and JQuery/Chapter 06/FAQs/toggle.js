export default class Toggle
{
    constructor()
    {

    }

    toggle()
    {
        var h2 = this;
        var div = h2.nextElementSibling;

        if(h2.hasAttribute("class"))
        {
            h2.removeAttribute("class");
        }
        else
        {
            h2.setAttribute("class", "minus");
        }

        if(div.hasAttribute("class"))
        {
            div.removeAttribute("class");
        }
        else
        {
            div.setAttribute("class", "open");
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