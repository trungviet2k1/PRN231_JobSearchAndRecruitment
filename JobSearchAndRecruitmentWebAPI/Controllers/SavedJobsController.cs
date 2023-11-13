using BusinessObject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.IRepository;

namespace JobSearchAndRecruitmentWebAPI.Controllers
{
    public class SavedJobsController : ODataController
    {
        private readonly ISavedJobsRepository _saveJobRepository;

        public SavedJobsController(ISavedJobsRepository saveJobRepository)
        {
            _saveJobRepository = saveJobRepository;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_saveJobRepository.GetAllJob());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_saveJobRepository.GetSaveJobById(key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] SavedJobsDTO saveJobDTO)
        {
            _saveJobRepository.CreateSaveJob(saveJobDTO);
            return Ok();
        }

        [EnableQuery]
        public IActionResult Delete(int key)
        {
            _saveJobRepository.DeleteSaveJob(key);
            return Ok();
        }
    }
}
