using BusinessObject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service.IRepository;
using Service.Repository;

namespace JobSearchAndRecruitmentWebAPI.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_employeeRepository.GetAllEmployee());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_employeeRepository.GetEmployeeById(key));
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] EmployeeDTO employeeDTO)
        {
            _employeeRepository.UpdateEmployee(employeeDTO);
            return Ok();
        }

        [Route("odata/Employee/Login")]
        [HttpPost]
        [EnableQuery]
        public IActionResult Login([FromBody] EmployerLogin employerLogin)
        {
            var _employerLogin = _employeeRepository.GetEmployeeByEmailAndPassword(employerLogin.Email, employerLogin.Password);

            if (_employerLogin != null)
            {
                return Ok(_employerLogin);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("odata/Employee/Register")]
        [HttpPost]
        [EnableQuery]
        public IActionResult Register([FromBody] EmployeeDTO register)
        {
            if (register == null) return BadRequest("Invalid registration data!");

            var existingEmployee = _employeeRepository.GetEmployeeByEmail(register.Email);
            if (existingEmployee != null) return BadRequest("Email already registered!");

            EmployerRegisterDTO employee = new EmployerRegisterDTO
            {
                CompanyName = register.CompanyName,
                FullName = register.FullName,
                Email = register.Email,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber
            };
            _employeeRepository.CreateEmployee(employee);
            return Ok("Registration successful.");
        }
    }
}
