﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using net.openstack.Providers.Rackspace;
using net.openstack.Core.Domain;

namespace ProgressBarMVC4.Controllers
{
    public class IdentityController : Controller
    {
        //
        // GET: /Identity/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Authenticate(FormCollection formCollection)
        {
            Session["apikey"] = formCollection["apikey"];
            Session["username"] = formCollection["username"];
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = Session["apikey"].ToString(),
                Username = Session["username"].ToString()
            };
            try
            {
            CloudIdentityProvider cloudIdentityProvider = new CloudIdentityProvider(cloudIdentity);
            UserAccess userAccess = cloudIdentityProvider.Authenticate(cloudIdentity);
            ViewBag.LastOperation = "Authentication successful";
            ViewBag.username = formCollection["username"];
            ViewBag.apikey = formCollection["apikey"];
            ViewBag.isAuthenticated = true;
            }
            catch (Exception e)
            {
                ViewBag.isAuthenticated = false;
                ViewBag.LastOperation = e.Message;
            }

            return View("Index");
        }
    }
}
