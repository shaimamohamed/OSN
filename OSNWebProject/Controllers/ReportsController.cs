using Core.Entities;
using Core.Model;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSNWebProject.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        public ReportsController()
        {

        }

        public async Task<IActionResult> Index()
        {
           return View();
        }

        public async Task<IActionResult> Report1()
        {
            using (var client = new HttpClient())
            {
              
            HttpResponseMessage response = await client.GetAsync("http://localhost:64739/api/Reports/Report1");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<GeneralResponse<List<Report1DTO>>>(result);
            return View(res.Data);

        }

    }
 
        public async Task<IActionResult> Report2()
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync("http://localhost:64739/api/Reports/Report2");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<GeneralResponse<List<Report2DTO>>>(result);
                return View(res.Data);

            }
        }

        public async Task<IActionResult> Report3()
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync("http://localhost:64739/api/Reports/Report3");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<GeneralResponse<List<Report3DTO>>>(result);
                return View(res.Data);

            }
        }

        public async Task<IActionResult> Report4()  
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync("http://localhost:64739/api/Reports/Report4");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<GeneralResponse<List<Report4DTO>>>(result);
                return View(res.Data);

            }
        }

    }
}
