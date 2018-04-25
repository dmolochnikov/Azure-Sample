using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.ApplicationInsights;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BookStore
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Task.Run(() => LogEvent(Server.MachineName));
        }

        private static async Task LogEvent(string machineName)
        {
            var blobClient = new CloudBlobClient(new Uri("https://dmbookstore.blob.core.windows.net/"), new StorageCredentials("dmbookstore", "KQtYK3w/lauKclzplGDNkcLqT6zC9kHFtzOTyxo92rqg8MyCYrxDfL5dPyy08h6FYadI4daTtrLSUSieZLxslA=="));
            var container = blobClient.GetContainerReference("logs");
            var id = $"HelloWorld_{DateTime.Now}";
            var blob = container.GetAppendBlobReference(id);
            await blob.UploadTextAsync($"Server name is '{machineName}', current time is '{DateTime.Now}'").ConfigureAwait(false);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception error = Server.GetLastError();
            Logger.Error("ZZZ! An error was detected on application level", error);

            var ai = new TelemetryClient();
            ai.TrackException(error, new Dictionary<string, string> { {"SOURCE", "Captured from TelemetryClient" } });
        }
    }
}