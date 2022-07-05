using front_end_mvc_dot_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace front_end_mvc_dot_net_framework.Controllers
{
    public class MechanicsToolsController : Controller
    {
        // GET: MechanicsTools
        public ActionResult Index()
        {
            IEnumerable<Tools> mechanicTools;
            HttpResponseMessage responseCall = ApiConnection.webApiClient.GetAsync("MechanicTools").Result;
            mechanicTools = responseCall.Content.ReadAsAsync<IEnumerable<Tools>>().Result;
            return View(mechanicTools);
        }


        //Create or update mechanics tools
        public ActionResult AddOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new Tools());
            }
            else
            {
                HttpResponseMessage response = ApiConnection.webApiClient.GetAsync("MechanicTools/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Tools>().Result);
            }

        }


        //post to db(mechanis tools)
        [HttpPost]
        public ActionResult AddOrUpdate(Tools mechanicTool)
        {
            if (mechanicTool.id == 0)
            {
                HttpResponseMessage response = ApiConnection.webApiClient.PostAsJsonAsync("MechanicTools", mechanicTool).Result;
            }
            else
            {
                HttpResponseMessage responseCall = ApiConnection.webApiClient.PutAsJsonAsync("MechanicTools" + mechanicTool.id, mechanicTool).Result;
            }
            return RedirectToAction("Index");
        }


        //remove mechanics tools
        public ActionResult Remove(int id)
        {
            HttpResponseMessage response = ApiConnection.webApiClient.DeleteAsync("MechanicTools/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}