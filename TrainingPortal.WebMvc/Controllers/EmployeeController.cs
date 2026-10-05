using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using TrainingPortal.Entities.Models;
using TrainingPortal.WebMvc.Helpers;
using System.Threading.Tasks;

namespace TrainingPortal.WebMvc.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            HttpClient client =
ApiHelper.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/employee");

            List<Employee> employees =
            await response.Content
            .ReadAsAsync<List<Employee>>();

            return View(employees);
        }
        // return View(new List<Employee>());

        // GET: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.PostAsJsonAsync(
                    "api/employee",
                    employee);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync(
                    "api/employee/" + id);

            Employee employee =
                await response.Content
                .ReadAsAsync<Employee>();

            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.PutAsJsonAsync(
                    "api/employee",
                    employee);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync(
                    "api/employee/" + id);

            Employee employee =
                await response.Content
                .ReadAsAsync<Employee>();

            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.DeleteAsync(
                    "api/employee/" + id);

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync(
                    "api/employee/" + id);

            Employee employee =
                await response.Content
                .ReadAsAsync<Employee>();

            return View(employee);
        }
    }
}



// GET: Employee/Details/5
/*public ActionResult Details(int id)
        {
            return View();
        }

        

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
*/