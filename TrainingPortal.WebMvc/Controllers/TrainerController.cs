using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;
using TrainingPortal.WebMvc.Helpers;

namespace TrainingPortal.WebMvc.Controllers
{
    [Authorize]
    public class TrainerController : Controller
    {
        // GET: Trainer
        public async Task<ActionResult> Index()
        {
            HttpClient client =
ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync("api/trainer");

            List<Trainer> trainers =
            await response.Content
            .ReadAsAsync<List<Trainer>>();

            return View(trainers);
        
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(
        Trainer trainer)
        {
            HttpClient client =
            ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.PostAsJsonAsync(
            "api/trainer",
            trainer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        public async Task<ActionResult> Details(
        int id)
        {
            HttpClient client =
            ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            "api/trainer/" + id);

            Trainer trainer =
            await response.Content
            .ReadAsAsync<Trainer>();

            return View(trainer);
        }

        public async Task<ActionResult> Edit(
        int id)
        {
            HttpClient client =
            ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            "api/trainer/" + id);

            Trainer trainer =
            await response.Content
            .ReadAsAsync<Trainer>();

            return View(trainer);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(
        Trainer trainer)
        {
            HttpClient client =
            ApiHelper.GetClient();

            await client.PutAsJsonAsync(
            "api/trainer",
            trainer);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(
        int id)
        {
            HttpClient client =
            ApiHelper.GetClient();

            HttpResponseMessage response =
            await client.GetAsync(
            "api/trainer/" + id);

            Trainer trainer =
            await response.Content
            .ReadAsAsync<Trainer>();

            return View(trainer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(
        int id)
        {
            HttpClient client =
            ApiHelper.GetClient();

            await client.DeleteAsync(
            "api/trainer/" + id);

            return RedirectToAction("Index");
        }
    }
}

/*
// GET: Trainer/Details/5
public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
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

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trainer/Edit/5
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

        // GET: Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trainer/Delete/5
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