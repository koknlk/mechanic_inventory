using front_end_mvc_dot_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace front_end_mvc_dot_net_framework.Controllers
{
    public class MechanicController : Controller
    {
        // GET: Mechanic
        public ActionResult Index()
        {
            IEnumerable<Mechanic> mechanicEmployees;
            HttpResponseMessage responseCall = ApiConnection.webApiClient.GetAsync("Mechanic").Result;
            mechanicEmployees = responseCall.Content.ReadAsAsync<IEnumerable<Mechanic>>().Result;
            return View(mechanicEmployees);
        }


        //Create or update mechanic employee
        public ActionResult AddOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new Mechanic());
            }
            else {
                HttpResponseMessage response = ApiConnection.webApiClient.GetAsync("Mechanic/" +id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Mechanic>().Result);
            }
           
        }


        //post mechanic detailts into db
        [HttpPost]
        public ActionResult AddOrUpdate(Mechanic mechanicEmp)
        {
            if (mechanicEmp.id == 0)
            {
                HttpResponseMessage response = ApiConnection.webApiClient.PostAsJsonAsync("Mechanic", mechanicEmp).Result;   
            }
            else
            {
                HttpResponseMessage responseCall = ApiConnection.webApiClient.PutAsJsonAsync("Mechanic"+ mechanicEmp.id, mechanicEmp).Result;
            }
            return RedirectToAction("Index");
        }


       // remove mechanic
        public ActionResult Remove(int id)
        {
            HttpResponseMessage response = ApiConnection.webApiClient.DeleteAsync("Mechanic/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}