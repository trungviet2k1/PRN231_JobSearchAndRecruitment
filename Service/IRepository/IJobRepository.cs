using BusinessObject.DTOs;
namespace Service.IRepository
{
    public interface IJobRepository
    {
        List<JobDTO> GetAllJob();

        JobDTO GetJobById(int jobId);

        void CreateJob(JobDTO jobDTO);

        void UpdateJob(JobDTO jobDTO);

        void DeleteJob(int jobId);
    }
}
