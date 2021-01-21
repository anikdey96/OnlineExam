using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExam.Models;
using System.Net.Http;

namespace OnlineExam.Controllers
{
    public class OnlineExamProjectController : Controller
    {
        // GET: OnlineExamProject
        public ActionResult Index()
        {
            IEnumerable<OnlineExamClass> oec = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44375/api/exam");

            var consumeapi = hc.GetAsync("Exam");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<OnlineExamClass>>();
                displaydata.Wait();
                oec = displaydata.Result;

            }
            return View(oec);
        }
    }
}