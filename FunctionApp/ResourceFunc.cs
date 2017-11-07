using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Threading;

namespace FunctionApp
{
    public static class ResourceFunc
    {
        [FunctionName("ResourceFunc")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            log.Info(Thread.CurrentThread.CurrentCulture.DisplayName);
            log.Info(Thread.CurrentThread.CurrentUICulture.DisplayName);
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("FunctionApp.Prova", System.Reflection.Assembly.GetExecutingAssembly());
            log.Info(rm.GetString("Nome"));
            return req.CreateResponse(HttpStatusCode.OK, rm.GetString("Nome"));
        }
    }
}
