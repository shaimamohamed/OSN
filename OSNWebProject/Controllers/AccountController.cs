using OSNWebProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Data.Authentication;

namespace OSNWebProject.Controllers
{
    public class AccountController : Controller
    {
        //Sample Users Data, it can be fetched with the use of any ORM
        public List<UserModel> users = null;
        public AccountController()
        {
            users = new List<UserModel>();
            users.Add(new UserModel() { UserId = 1, Username = "Anoop", Password = "123", Role = "Admin" });
            users.Add(new UserModel() { UserId = 2, Username = "Other", Password = "123", Role = "User" });
        }

        public IActionResult Login(string ReturnUrl = "/")
        {
            LoginModel objLoginModel = new LoginModel();
            objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                // call api to get token
                //var user = users.Where(x => x.Username == objLoginModel.UserName && x.Password == objLoginModel.Password).FirstOrDefault();
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("http://localhost:64739/api/Authenticate/login");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(objLoginModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://localhost:64739/api/Authenticate/login", content);
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var result = await response.Content.ReadAsStringAsync();
                    //    var res = JsonConvert.DeserializeObject<GeneralResponse<ApplicationUser>>(result);                        
                    //}                 
                //}

                if (!response.IsSuccessStatusCode)
                //if (user == null)
                    {
                    //Add logic here to display some message to user
                    ViewBag.Message = "Invalid Credential";
                    return View(objLoginModel);
                }
                else
                {
                        var result = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<GeneralResponse<ApplicationUser>>(result);
                        //A claim is a statement about a subject by an issuer and
                        //represent attributes of the subject that are useful in the context of authentication and authorization operations.
                        var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,objLoginModel.UserName),
                    new Claim("FavoriteDrink","Tea")
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal, new AuthenticationProperties() { IsPersistent = objLoginModel.RememberLogin });
                        
                    return LocalRedirect(objLoginModel.ReturnUrl);
                }
            }
            }
            return View(objLoginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page
            return LocalRedirect("/");
        }


        public IActionResult Register(string ReturnUrl = "/")
        {
            RegisterModel model = new RegisterModel();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://localhost:64739/api/Authenticate/register", content);
                   
                    if (!response.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Invalid Credential";
                        return View(model);
                    }
                    else
                    {
                        ViewBag.Message = "User Created Is Successed";
                        return RedirectToAction("Login");

                    }
                }
            }
            return View(model);
        }

    }
}
