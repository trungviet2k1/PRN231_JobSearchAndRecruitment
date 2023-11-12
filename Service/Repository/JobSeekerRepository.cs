using BusinessObject.DTOs;
using BusinessObject.Models;
using DataAccess.DAO;
using Service.IRepository;

namespace Service.Repository
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        private readonly JobSeekerDAO _jobSeekerDAO;

        public JobSeekerRepository(JobSeekerDAO jobSeekerDAO)
        {
            _jobSeekerDAO = jobSeekerDAO;
        }

        public void CreateJobSeeker(JobSeekerRegisterDTO jobSeekerDTO) => _jobSeekerDAO.CreateJobSeeker(jobSeekerDTO);

        public List<JobSeeker> GetAllJobSeekers() => _jobSeekerDAO.GetAllJobSeekers();

        public JobSeekerDTO GetJobSeekerByEmail(string email) => _jobSeekerDAO.GetJobSeekerByEmail(email);

        public JobSeekerDTO GetJobSeekerById(int jobSeekerId) => _jobSeekerDAO.GetJobSeekerById(jobSeekerId);

        public JobSeekerDTO GetJobSeekerDTOByEmailAndPassword(string email, string password) 
            => _jobSeekerDAO.GetJobSeekerByEmailAndPassWord(email, password);

        public void UpdateJobSeeker(JobSeekerDTO jobSeekerDTO) => _jobSeekerDAO.UpdateJobSeeker(jobSeekerDTO);
    }
}
