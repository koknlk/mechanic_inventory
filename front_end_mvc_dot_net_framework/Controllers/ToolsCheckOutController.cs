using front_end_mvc_dot_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace front_end_mvc_dot_net_framework.Controllers
{
    public class ToolsCheckOutController : Controller
    {
        // GET: ToolsCheckOut
        public ActionResult Index()
        {


            IEnumerable<ToolCheckOut> mechanicEmployees;
            HttpResponseMessage responseCall = ApiConnection.webApiClient.GetAsync("ToolsCheckOut").Result;
            mechanicEmployees = responseCall.Content.ReadAsAsync<IEnumerable<ToolCheckOut>>().Result;
            return View(mechanicEmployees);
        }


        //Tools Checkout
        public ActionResult CheckOut(int id = 0)
        {
            if (id == 0)
            {
                return View(new ToolCheckOut());
            }
            else
            {
                HttpResponseMessage response = ApiConnection.webApiClient.GetAsync("ToolsCheckOut/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Mechanic>().Result);
            }

        }

        //Post checkout to db

        [HttpPost]
        public ActionResult CheckOut(Mechanic toolsCheckOut)
        {
            if (toolsCheckOut.id == 0)
            {
                HttpResponseMessage response = ApiConnection.webApiClient.PostAsJsonAsync("ToolsCheckOut", toolsCheckOut).Result;
            }
            else
            {
                HttpResponseMessage responseCall = ApiConnection.webApiClient.PutAsJsonAsync("ToolsCheckOut" + toolsCheckOut.id, toolsCheckOut).Result;
            }
            return RedirectToAction("Index");
        }


        //Remove checkout
        public ActionResult Remove(int id)
        {
            HttpResponseMessage response = ApiConnection.webApiClient.DeleteAsync("ToolsCheckOut/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}