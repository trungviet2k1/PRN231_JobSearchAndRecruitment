using BusinessObject.DTOs;
using BusinessObject.Models;

namespace Service.IRepository
{
    public interface ISavedJobsRepository
    {
        List<SavedJobs> GetAllJob();

        SavedJobsDTO GetSaveJobById(int saveJobId);

        void CreateSaveJob(SavedJobsDTO saveJobDTO);

        void DeleteSaveJob(int saveJobId);
    }
}
