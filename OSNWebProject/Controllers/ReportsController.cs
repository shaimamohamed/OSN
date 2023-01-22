using Core.Entities;
using Core.Model;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSNWebProject.Controllers
{
    public class ReportsController : Controller
    {
        public ReportsController()
        {

        }

        public async Task<IActionResult> Index()
        {
           return View();
        }

        //[HttpGet]
        public async Task<IActionResult> Report1()
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //var response =  client.GetAsync("http://localhost:64739/api/Reports/Report1").Result;

                //if (!response.IsSuccessStatusCode)
                //{
                //    ViewBag.Message = "Invalid Action";
                //    return View();
                //}
                //else
                //{
                //    var result = await response.Content.ReadAsStringAsync();
                //    var res = JsonConvert.DeserializeObject<GeneralResponse<Report1DTO>>(result);
                //    return View(res);

                //}

                HttpResponseMessage response = await client.GetAsync("http://localhost:64739/api/Reports/Report1");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<GeneralResponse<Report1DTO>>(result);
            return View(res.Data);

            return Json(result);


        }
        //List<Report1DTO> cc = new List<Report1DTO>();
        //Report1DTO a = new Report1DTO()
        //{
        //    Email = "lll",
        //    parents = new Parent() { Name = "ddd" }
        //};
        //Report1DTO aa = new Report1DTO()
        //{
        //    Email = "lll",
        //    parents = new Parent() { Name = "ddd" }
        //};
        //cc.Add(a);
        //cc.Add(aa);
        //return View(cc);

    }

        //[HttpGet]
        public async Task<IActionResult> Report2()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("http://localhost:64739/api/Reports/Report2");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Invalid Action";
                    return View();
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<GeneralResponse<Report2DTO>>(result);
                    return View(res);

                }

            }
        }


        //[HttpGet]
        public async Task<IActionResult> Report3()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("http://localhost:64739/api/Reports/Report3");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Invalid Action";
                    return View();
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<GeneralResponse<Report3DTO>>(result);
                    return View(res);

                }

            }
        }


        //[HttpGet]
        public async Task<IActionResult> Report4()  
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("http://localhost:64739/api/Reports/Report4");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Invalid Action";
                    return View();
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<GeneralResponse<Report4DTO>>(result);
                    return View(res.Data);

                }

            }
        }


    }
}
