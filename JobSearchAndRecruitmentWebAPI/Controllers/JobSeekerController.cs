using BusinessObject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.IRepository;

namespace JobSearchAndRecruitmentWebAPI.Controllers
{
    public class JobSeekerController : ODataController
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;

        public JobSeekerController(IJobSeekerRepository repository)
        {
            _jobSeekerRepository = repository;
        }

        [EnableQuery]
        public IActionResult Get()  
        {
            return Ok(_jobSeekerRepository.GetAllJobSeekers());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_jobSeekerRepository.GetJobSeekerById(key));
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] JobSeekerDTO jobSeekerDTO)
        {
           jobSeekerDTO.JobSeekerId = key;

            _jobSeekerRepository.UpdateJobSeeker(jobSeekerDTO);
            return Ok();
        }

        [Route("odata/JobSeeker/Login")]
        [HttpPost]
        [EnableQuery]
        public IActionResult Login([FromBody] JobSeekerLogin jobSeekerLogin)
        {
            var _jobSeekerLogin = _jobSeekerRepository.GetJobSeekerDTOByEmailAndPassword(jobSeekerLogin.Email, jobSeekerLogin.Password);

            if (_jobSeekerLogin != null)
            {
                return Ok(_jobSeekerLogin);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("odata/JobSeeker/Register")]
        [HttpPost]
        [EnableQuery]
        public IActionResult Register([FromBody] JobSeekerDTO register)
        {
            if (register == null) return BadRequest("Invalid registration data!");

            var existingJobSeeker = _jobSeekerRepository.GetJobSeekerByEmail(register.Email);
            if (existingJobSeeker != null) return BadRequest("Email already registered!");

            JobSeekerRegisterDTO jobSeeker = new JobSeekerRegisterDTO
            {
                FullName = register.FullName,
                Email = register.Email,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber
            };
            _jobSeekerRepository.CreateJobSeeker(jobSeeker);
            return Ok("Registration successful.");
        }
    }
}
