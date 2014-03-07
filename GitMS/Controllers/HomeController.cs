using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitMS.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(String id) {

            var node = NodeStore.Repository.Read(id);
            return View(node.View, node);

        }

        public ActionResult Display(string  category) {

            var node = NodeStore.Repository.ReadByPath(category ?? "/");

            return View(node.View, node);

        }


    }
}
