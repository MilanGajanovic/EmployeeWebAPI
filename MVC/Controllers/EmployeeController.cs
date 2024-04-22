using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList = null;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                empList = JsonConvert.DeserializeObject<IEnumerable<mvcEmployeeModel>>(content);
            }
            else
            {
                // Handle unsuccessful response
                ModelState.AddModelError(string.Empty, "Failed to retrieve employee data: " + response.ReasonPhrase);
            }

            return View(empList);

        }
    }
}