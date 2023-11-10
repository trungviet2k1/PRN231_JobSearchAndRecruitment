using BusinessObject.DTOs;

namespace Service.IRepository
{
    public interface IJobSeekerRepository
    {
        JobSeekerDTO GetJobSeekerDTOByEmailAndPassword(string email, string password);
        List<JobSeekerDTO> GetAllJobSeekers();
        JobSeekerDTO GetJobSeekerById(int jobSeekerId);
        JobSeekerDTO GetJobSeekerByEmail(string email);
        void CreateJobSeeker(JobSeekerRegisterDTO jobSeekerDTO);
        void UpdateJobSeeker(JobSeekerDTO jobSeekerDTO);
    }
}
