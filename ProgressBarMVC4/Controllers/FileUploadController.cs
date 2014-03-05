using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.IO;
using Microsoft.AspNet.SignalR.Hubs;
using net.openstack.Providers.Rackspace;
using net.openstack.Core.Domain;
using net.openstack.Core.Providers;
using Microsoft.AspNet.SignalR;
using ProgressBarMVC4;

namespace ProgressBarMVC4.Controllers
{
    public class FileUploadController : Controller
    {
        //
        // GET: /FileUpload/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /FileUpload/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /FileUpload/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FileUpload/Create

        [HttpPost]
        public ActionResult Create(Models.FileUploadModel uploadParameters)
        {
            try
            {
                return View(uploadParameters);
            }
            catch
            {
                return View();
            }
        }

        // GET: /FileUpload/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /FileUpload/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FileUpload/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /FileUpload/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
