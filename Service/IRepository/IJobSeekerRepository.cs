using BusinessObject.DTOs;
using BusinessObject.Models;

namespace Service.IRepository
{
    public interface IJobSeekerRepository
    {
        JobSeekerDTO GetJobSeekerDTOByEmailAndPassword(string email, string password);
        List<JobSeeker> GetAllJobSeekers();
        JobSeekerDTO GetJobSeekerById(int jobSeekerId);
        JobSeekerDTO GetJobSeekerByEmail(string email);
        void CreateJobSeeker(JobSeekerRegisterDTO jobSeekerDTO);
        void UpdateJobSeeker(JobSeekerDTO jobSeekerDTO);

    //    void CreateJobSeekr(JobSeekerDTO jobSeekerDTO);

    
    }
}
