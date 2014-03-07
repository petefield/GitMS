using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitMS.Renderers
{

    public class FieldRenderer : IRenderer
    {
        public System.Web.Mvc.MvcHtmlString Render(Models.Field field) {
            return new MvcHtmlString(field.Value);
        }



    }
}