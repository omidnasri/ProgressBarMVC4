

/*!
    ASP.NET SignalR File Upload Progress Bar
*/


$(function () {

    var uploader = $.connection.fileUploaderHub;
    
    // Add client-side hub methods that the server will call
    // In this case, the server will update the client with
    // the percentage completed of the upload.
    $.extend(uploader.client, {
        updateProgressBar: function (pct) {
            $("#pct").html(pct);
        }
    });

    $.connection.hub.start().done(function () {
        {
            var username = $("#username").val();
            var apikey = $("#apikey").val();
            var containername = $("#containername").val();
            var pathtofile = $("#pathtofile").val();
            var objectname = $("#objectname").val();
            uploader.server.fileUpload(username, apikey, containername, pathtofile, objectname).done(function () { $("form").submit(); });
//            uploader.server.fileUpload(username, apikey, containername, pathtofile, objectname);

        };
    });

});