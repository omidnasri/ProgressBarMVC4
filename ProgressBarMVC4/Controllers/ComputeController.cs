using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using net.openstack.Providers.Rackspace;
using net.openstack.Core.Domain;

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
            if (Session["apikey"].ToString() == null){
                RedirectToAction("Index", "Home");
            }
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = Session["apikey"].ToString(),
                Username = Session["username"].ToString()
            };
            CloudServersProvider cloudServersProviders = new CloudServersProvider(cloudIdentity);
            System.Collections.IEnumerable flavors = cloudServersProviders.ListFlavorsWithDetails(region: "IAD");
            ViewBag.Flavors= flavors;
            return View("Index");
        }

        public ActionResult ListImagesInit()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = Session["apikey"].ToString(),
                Username = Session["username"].ToString()
            };
            CloudServersProvider cloudServersProviders = new CloudServersProvider(cloudIdentity);
            System.Collections.IEnumerable images = cloudServersProviders.ListImagesWithDetails(region: "IAD");
            ViewBag.Images = images;
            return View("Index");
        }
    }
}
