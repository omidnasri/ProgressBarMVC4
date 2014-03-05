MVC4 example of using SignalR with the OpenStack.NET file upload to display a progress bar on a web client

March 5, 2014

During lengthy operations, it is a best practice to keep the user updated as to the progress of the operation. In the example of file uploads, a progress bar is a good graphical representation.

(Text showing the size of the object, the number of bytes uploaded, a calculated speed and an estimated time to completion add value and are easily added)

One of the requirements to update a .NET web page is to allow the previous postback cycle to complete. Until the server-side processing is finished, the page cannot be udpated.

To work around this limitation, the SignalR component allows Comet calls (AKA "reverse AJAX") to one or more clients.

In the specific case where a large object is being uploaded to a Cloud Container using the method "CreateFileFromObject", a progress update Action can be specified. This action receives, as it's input, the number of bytes sent.

Using this Action, we can use SignalR to call a function on the client to update the progress. In our example, we simply send the percentage completed.

Finally, that information is used as the value for the jQuery Progress Bar UI widget. By binding a function to the event "DOMSubtreeModified" for the <div> containing the percentage value, we are able to dynamically update the progress bar.

### END ###