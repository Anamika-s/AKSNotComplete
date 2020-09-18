using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentClient.Models;

namespace StudentClient.Controllers
{
    public class SchoolWebApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
             Uri Endpoint = new Uri(Environment.GetEnvironmentVariable("API_URL"));
         //   client.BaseAddress = new Uri("https://localhost:44308/");
        //     Uri Endpoint = new Uri(Environment.GetEnvironmentVariable("schoolapi"));
            client.BaseAddress = Endpoint;
            return client;
        }
    }
    public class StudentCController : Controller
    {
        SchoolWebApi api = new SchoolWebApi();

        // GET: StudentCController
        public ActionResult Index()
        {
            List<StudentViewModel> schools = new List<StudentViewModel>();
            using (var client = api.Initial())
            {

                //HTTP GET
                var responseTask = client.GetAsync("api/students");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<StudentViewModel>>();
                    readTask.Wait();



                    schools = readTask.Result;
                }


                }
                return View(schools);
            }

        

        // GET: StudentCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
