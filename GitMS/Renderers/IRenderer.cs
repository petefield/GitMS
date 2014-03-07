using System;
using System.Collections.Generic;


namespace GitMS.Renderers
{
    interface IRenderer
    {
        System.Web.Mvc.MvcHtmlString Render(GitMS.Models.Field field);
       
    }
}
