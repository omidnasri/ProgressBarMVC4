using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgressBarMVC4.Controllers
{
    public class ComputeController : Controller
    {
        //
        // GET: /Compute/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListFlavorsInit()
        {
            return View();
        }

        public ActionResult ListImagesInit()
        {
            return View();
        }
    }
}
