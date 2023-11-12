using BusinessObject.DTOs;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.IRepository;
using Service.Repository;

namespace JobSearchAndRecruitmentWebAPI.Controllers
{
    public class JobController : ODataController
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_jobRepository.GetAllJob());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_jobRepository.GetJobById(key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] JobDTO jobDTO)
        {
            _jobRepository.CreateJob(jobDTO);
            return Ok();
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] JobDTO jobDTO)
        {
            _jobRepository.UpdateJob(jobDTO);
            return Ok();
        }

        [EnableQuery]
        public IActionResult Delete(int key)
        {
            _jobRepository.DeleteJob(key);
            return Ok();
        }


    }
}
