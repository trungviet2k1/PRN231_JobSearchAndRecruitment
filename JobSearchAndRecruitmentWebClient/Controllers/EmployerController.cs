using BusinessObject.Commons;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace JobSearchAndRecruitmentWebClient.Controllers
{
    public class EmployerController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployerController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:5090/odata/");
        }

        public EmployerLogin EmployerLogin { get; set; }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Manager()
        {
            var employerSession = HttpContext.Session.GetString(Enums.SESSION_KEY_EMPLOYER);

            if (string.IsNullOrEmpty(employerSession))
            {
                return RedirectToAction("Login", "Employer");
            }

            return View();
        }

        public ActionResult NewJobPost()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult EditJob()
        {
            return View("Views/Employer/EditJob.cshtml");
        }

        public IActionResult Login()
        {
            return View("Views/Employer/Login.cshtml");
        }

        public IActionResult Register()
        {
            return View("Views/Employer/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmployerLogin login)
        {
            if (!ModelState.IsValid)
            {
                return Login();
            }

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("Employer/Login", content);
            string strData = await response.Content.ReadAsStringAsync();
            Employer currentEmployer = JsonConvert.DeserializeObject<Employer>(strData);
            ViewData["Error"] = "";

            if (currentEmployer != null)
            {
                if (currentEmployer.IsEmployer == true)
                {
                    HttpContext.Session.SetString(Enums.SESSION_KEY_EMPLOYER, System.Text.Json.JsonSerializer.Serialize(currentEmployer));
                    return Redirect("/Employer/Manager");
                }
            }

            ViewData["Error"] = "Email or password is incorrect! Please re-enter!";
            return Login();
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployerRegister registration)
        {
            if (!ModelState.IsValid)
            {
                return Register();
            }

            var json = JsonConvert.SerializeObject(registration);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("Employer/Register", content);

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
            return RedirectToAction("Home", "Employer");
        }
    }
}