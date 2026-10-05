using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;
using TrainingPortal.WebMvc.Helpers;

namespace TrainingPortal.MVC.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync("api/training");

            List<Training> trainings =
            await response.Content.ReadAsAsync<List<Training>>();

            return View(trainings);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Training training)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.PostAsJsonAsync(
            "api/training",
            training);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(training);
        }

        public async Task<ActionResult> Details(int id)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            "api/training/" + id);

            Training training =
            await response.Content.ReadAsAsync<Training>();

            return View(training);
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            "api/training/" + id);

            Training training =
            await response.Content.ReadAsAsync<Training>();

            return View(training);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Training training)
        {
            HttpClient client = ApiHelper.GetClient();

            await client.PutAsJsonAsync(
            "api/training",
            training);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            "api/training/" + id);

            Training training =
            await response.Content.ReadAsAsync<Training>();

            return View(training);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = ApiHelper.GetClient();

            await client.DeleteAsync(
            "api/training/" + id);

            return RedirectToAction("Index");
        }
    }
}