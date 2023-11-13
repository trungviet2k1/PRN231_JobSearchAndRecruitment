using BusinessObject.DTOs;
using BusinessObject.Models;
using DataAccess.DAO;
using Service.IRepository;

namespace Service.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly JobDAO _jobDAO;

        public JobRepository(JobDAO jobDAO)
        {
            _jobDAO = jobDAO;
        }

        public void CreateJob(JobDTO jobDTO) => _jobDAO.CreateJob(jobDTO);

        public void DeleteJob(int jobId) => _jobDAO.DeleteJob(jobId);

        public List<Job> GetAllJob() => _jobDAO.GetAllJob();

        public JobDTO GetJobById(int jobId) => _jobDAO.GetJobById(jobId);
        public void UpdateJob(JobDTO jobDTO) => _jobDAO.UpdateJob(jobDTO);
    }
}
