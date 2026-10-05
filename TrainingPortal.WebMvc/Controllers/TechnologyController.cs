using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TrainingPortal.Entities.Models;
using TrainingPortal.WebMvc.Helpers;

namespace TrainingPortal.WebMvc.Controllers
{
    [Authorize]
    public class TechnologyController : Controller
    {
        // GET: Technology
        public async Task<ActionResult> Index()
        {
            HttpClient client = ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync("api/technology");

            List<Technology> technologies =
                await response.Content
                .ReadAsAsync<List<Technology>>();

            return View(technologies);
        }

        // GET: Technology/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync(
                    "api/technology/" + id);

            Technology technology =
                await response.Content
                .ReadAsAsync<Technology>();

            return View(technology);
        }

        // GET: Technology/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Technology/Create
        [HttpPost]
        public async Task<ActionResult> Create(
    Technology technology)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.PostAsJsonAsync(
                    "api/technology",
                    technology);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(technology);
        }

        // GET: Technology/Edit/5
        /*public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Technology/Edit/5
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
        }*/
        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync(
                    "api/technology/" + id);

            Technology technology =
                await response.Content
                .ReadAsAsync<Technology>();

            return View(technology);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(
            Technology technology)
        {
            HttpClient client =
                ApiHelper.GetClient();

            await client.PutAsJsonAsync(
                "api/technology",
                technology);

            return RedirectToAction("Index");
        }

        // GET: Technology/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Technology/Delete/5
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
        }*/
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            HttpResponseMessage response =
                await client.GetAsync(
                    "api/technology/" + id);

            Technology technology =
                await response.Content
                .ReadAsAsync<Technology>();

            return View(technology);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(
            int id)
        {
            HttpClient client =
                ApiHelper.GetClient();

            await client.DeleteAsync(
                "api/technology/" + id);

            return RedirectToAction("Index");
        }
    }
}
