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
    public class TraineeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync("api/trainee");

            List<Trainee> trainees =
            await response.Content.ReadAsAsync<List<Trainee>>();

            return View(trainees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Trainee trainee)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.PostAsJsonAsync(
            "api/trainee",
            trainee);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(trainee);
        }

        public async Task<ActionResult> Details(
        int trainingId,
        int empId)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            $"api/trainee/{trainingId}/{empId}");

            Trainee trainee =
            await response.Content.ReadAsAsync<Trainee>();

            return View(trainee);
        }

        public async Task<ActionResult> Edit(
        int trainingId,
        int empId)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            $"api/trainee/{trainingId}/{empId}");

            Trainee trainee =
            await response.Content.ReadAsAsync<Trainee>();

            return View(trainee);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Trainee trainee)
        {
            HttpClient client = ApiHelper.GetClient();

            await client.PutAsJsonAsync(
            "api/trainee",
            trainee);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(
        int trainingId,
        int empId)
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            $"api/trainee/{trainingId}/{empId}");

            Trainee trainee =
            await response.Content.ReadAsAsync<Trainee>();

            return View(trainee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(
        int trainingId,
        int empId)
        {
            HttpClient client = ApiHelper.GetClient();

            await client.DeleteAsync(
            $"api/trainee/{trainingId}/{empId}");

            return RedirectToAction("Index");
        }
    }
}