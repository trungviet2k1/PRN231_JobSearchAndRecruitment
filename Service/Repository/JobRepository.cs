using BusinessObject.DTOs;
using BusinessObject.Models;
using DataAccess.DAO;
using Service.IRepository;

namespace Service.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly JobDAO _jobDAO;
        private readonly PRN231_ProjectDbContext _dbContext;

        public JobRepository(JobDAO jobDAO, PRN231_ProjectDbContext dbContext)
        {
            _jobDAO = jobDAO;
            _dbContext = dbContext;
        }

        public void CreateJob(JobDTO jobDTO) => _jobDAO.CreateJob(jobDTO);

        public void DeleteJob(int jobId) => _jobDAO.DeleteJob(jobId);

        public List<Job> GetAllJob() => _jobDAO.GetAllJob();

        public JobDTO GetJobById(int jobId) => _jobDAO.GetJobById(jobId);
        public void UpdateJob(JobDTO jobDTO) => _jobDAO.UpdateJob(jobDTO);
    }
}
