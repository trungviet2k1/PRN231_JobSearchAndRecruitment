using BusinessObject.DTOs;
using BusinessObject.Models;
using DataAccess.DAO;
using Service.IRepository;

namespace Service.Repository
{
    public class SavedJobsRepository : ISavedJobsRepository
    {
        private readonly SavedJobsDAO _saveJobDAO;

        public SavedJobsRepository(SavedJobsDAO saveJobDAO)
        {
            _saveJobDAO = saveJobDAO;
        }

        public void CreateSaveJob(SavedJobsDTO saveJobDTO) => _saveJobDAO.CreateSaveJob(saveJobDTO);

        public void DeleteSaveJob(int jobId) => _saveJobDAO.DeleteSaveJob(jobId);

        public List<SavedJobs> GetAllJob() => _saveJobDAO.GetAllJob();

        public SavedJobsDTO GetSaveJobById(int saveJobId) => _saveJobDAO.GetSaveJobById(saveJobId);
    }
}
