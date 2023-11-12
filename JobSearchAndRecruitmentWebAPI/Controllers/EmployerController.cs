using BusinessObject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.IRepository;

namespace JobSearchAndRecruitmentWebAPI.Controllers
{
    public class EmployerController : ODataController
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_employerRepository.GetAllEmployer());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_employerRepository.GetEmployerById(key));
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] EmployerDTO employeeDTO)
        {
            _employerRepository.UpdateEmployer(employeeDTO);
            return Ok();
        }

        [Route("odata/Employer/Login")]
        [HttpPost]
        [EnableQuery]
        public IActionResult Login([FromBody] EmployerLogin employerLogin)
        {
            var _employerLogin = _employerRepository.GetEmployerByEmailAndPassword(employerLogin.Email, employerLogin.Password);

            if (_employerLogin != null)
            {
                return Ok(_employerLogin);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("odata/Employer/Register")]
        [HttpPost]
        [EnableQuery]
        public IActionResult Register([FromBody] EmployerDTO register)
        {
            if (register == null) return BadRequest("Invalid registration data!");

            var existingEmployer = _employerRepository.GetEmployerByEmail(register.Email);
            if (existingEmployer != null) return BadRequest("Email already registered!");

            EmployerRegisterDTO employer = new EmployerRegisterDTO
            {
                CompanyName = register.CompanyName,
                FullName = register.FullName,
                Email = register.Email,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber,
                CompanyWebsite = register.CompanyWebsite
            };
            _employerRepository.CreateEmployer(employer);
            return Ok("Registration successful.");
        }
    }
}
