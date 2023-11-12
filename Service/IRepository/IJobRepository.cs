using BusinessObject.DTOs;
using BusinessObject.Models;

namespace Service.IRepository
{
    public interface IJobRepository
    {
        List<Job> GetAllJob();

        JobDTO GetJobById(int jobId);

        void CreateJob(JobDTO jobDTO);

        void UpdateJob(JobDTO jobDTO);

        void DeleteJob(int jobId);
    }
}
