using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppAzure48.Models;

namespace WebAppAzure48.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            string secName = "secretsMonitor";
            var service = new KeyVaultService();
            await service.CreateSecretAsync(secName, "Testing");
            string config = await service.GetSecretAsync(secName);
            ViewBag.Message = $"Key vault Test - {config}";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}