using BusinessObject.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchAndRecruitmentWebClient.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:5090/odata/");
        }

        public EmployerLogin EmployerLogin { get; set; }

        public IActionResult Home()
        {
            return View();
        }
    }
}