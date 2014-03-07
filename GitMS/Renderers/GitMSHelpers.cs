using GitMS.Models;
using GitMS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitMS
{

    public abstract class ViewBase<TModel> : System.Web.Mvc.WebViewPage<TModel> where TModel : class
    {
        // now this will be available in any view @HelloWorld()
        public string HelloWorld() {
            return "Hello from the ViewBase class";
        }

        private GitMSHelper _gitMSHelper;

        public GitMSHelper GitMS { 
            get { 
                if (_gitMSHelper == null )  _gitMSHelper = new GitMSHelper();
                return _gitMSHelper;
            } 
        }

    }

}

namespace GitMS.Renderers
{

    public class GitMSHelper
    {
        public MvcHtmlString RenderField(GitMS.Models.Field field) {
            IRenderer renderer;

            switch(field.Type) {
                case "SimpleText":
                    renderer = new FieldRenderer();
                    break;
                default:
                    renderer = new FieldRenderer();
                    break;
            }

            return renderer.Render(field);
        }
    }


}