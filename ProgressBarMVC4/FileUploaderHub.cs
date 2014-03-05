using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using net.openstack.Providers.Rackspace;
using net.openstack.Core.Domain;
using net.openstack.Core.Providers;

namespace ProgressBarMVC4
{
    //[HubName("fileUploader")]
    public class FileUploaderHub : Hub
    {

        long fileSize;

        public void fileUpload(string username, string apiKey, string containerName, string pathToFile, string objectName)
        {
            CloudIdentity cid = new CloudIdentity() { Username = username, APIKey = apiKey };
            CloudFilesProvider cfp = new CloudFilesProvider(cid);

            fileSize = new FileInfo(pathToFile).Length;

            cfp.CreateObjectFromFile(
            container: containerName,
            filePath: pathToFile,
            objectName: objectName,
            progressUpdated: updateProgress);

        }

        private void updateProgress(long bytesSent)
        {
            // Send percent completed to the client(s)
            Clients.All.updateProgressBar(((bytesSent * 100) / fileSize).ToString());
        }
    }
}