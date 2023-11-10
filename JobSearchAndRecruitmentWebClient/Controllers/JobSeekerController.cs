using BusinessObject.Commons;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace JobSearchAndRecruitmentWebClient.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly HttpClient _httpClient;

        public JobSeekerController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:5090/odata/");
        }

        public JobSeekerLogin JobSeekerLogin { get; set; }

        public IActionResult Login()
        {
            return View("Views/JobSeeker/Login.cshtml");
        }

        public IActionResult Register()
        {
            return View("Views/JobSeeker/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(JobSeekerLogin login)
        {
            if (!ModelState.IsValid)
            {
                return Login();
            }

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("JobSeeker/Login", content);
            string strData = await response.Content.ReadAsStringAsync();
            JobSeeker currentJobSeeker = JsonConvert.DeserializeObject<JobSeeker>(strData);
            ViewData["Error"] = "";

            if (currentJobSeeker != null)
            {
                if (currentJobSeeker.IsEmployer == false)
                {
                    HttpContext.Session.SetString(Enums.SESSION_KEY_JOB_SEEKER, System.Text.Json.JsonSerializer.Serialize(currentJobSeeker));
                    return Redirect("/Home/Index");
                }
                ViewData["Error"] = "This is not a \"Job Search\" account!! Please check your account again.";
                return Login();
            }

            ViewData["Error"] = "Email or password is incorrect! Please re-enter!";
            return Login();
        }

        [HttpPost]
        public async Task<IActionResult> Register(JobSeekerRegister registration)
        {
            if (!ModelState.IsValid)
            {
                return Register();
            }

            var json = JsonConvert.SerializeObject(registration);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("JobSeeker/Register", content);

            if (response.IsSuccessStatusCode)
            {
                ViewData["registerSuccess"] = "Registration successful! You can now Sign In";
                return Register();
            }

            ViewData["Error"] = "Registration failed. Please try again.";
            return Register();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}