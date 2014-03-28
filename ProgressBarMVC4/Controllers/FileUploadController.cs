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
using Lib.Web.Mvc;

namespace ProgressBarMVC4.Controllers
{
    [HandleError]
    public class FileUploadController : Controller
    {

        long filesize;

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

        [HttpPost]
        public ActionResult Create2(Models.FileUploadModel uploadParameters)
        {
            try
            {
                var username = uploadParameters.Username;
                var apiKey = uploadParameters.Apikey;
                var containerName = uploadParameters.Container;
                var objectName = uploadParameters.Objectname;
                var theFile = uploadParameters.Pathtofile;

                CloudIdentity cid = new CloudIdentity() { Username = username, APIKey = apiKey };
                CloudFilesProvider cfp = new CloudFilesProvider(cid);

                filesize = theFile.ContentLength;


                using (var stream = theFile.InputStream)
                {
                    cfp.CreateObject(containerName, stream, objectName, progressUpdated: updateProgress);
                }


                return RedirectToAction("Index", "Home");
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

        #region Actions
        public ActionResult Progressbar()
        {
            Session["OPERATION_PROGRESS"] = 0;
            return View();
        }

        /// <summary>
        /// Action for triggering long running operation
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Operation(Models.FileUploadModel viewModel)
        {
            HttpSessionStateBase session = Session;

            //Separate thread for long running operation
//            ThreadPool.QueueUserWorkItem(delegate
//            {
                var file = viewModel.Pathtofile;
                var username = viewModel.Username;
                var apiKey = viewModel.Apikey;
                var containerName = viewModel.Container;
                var objectName = viewModel.Objectname;

                CloudIdentity cid = new CloudIdentity() { Username = username, APIKey = apiKey };
                CloudFilesProvider cfp = new CloudFilesProvider(cid);

                filesize = file.ContentLength;


                using (var stream = file.InputStream)
                {
                    cfp.CreateObject(containerName,stream,objectName,progressUpdated:updateProgress);
                }

                
                //int operationProgress;
                //for (operationProgress = 0; operationProgress <= 100; operationProgress = operationProgress + 2)
                //{
                //    session["OPERATION_PROGRESS"] = operationProgress;
                //    Thread.Sleep(1000);
                //}
 //           });

                return RedirectToAction("Index", "Home");

//            return Json(new { progress = 0 });
        }

        private void updateProgress(long bytesSent)
        {
            HttpSessionStateBase session = Session;
            session["OPERATION_PROGRESS"] = (((bytesSent * 100) / filesize).ToString());

        }
        
        [NoCache]
        public ActionResult OperationProgress()
        {
            int operationProgress = 0;

            if (Session["OPERATION_PROGRESS"] != null)
                operationProgress = Convert.ToInt32(Session["OPERATION_PROGRESS"].ToString());

            return Json(new { progress = operationProgress }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
