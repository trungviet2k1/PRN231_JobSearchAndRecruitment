using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DataAccess.DAO
{
    public class JobDAO
    {
        private readonly PRN231_ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public JobDAO(PRN231_ProjectDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public List<Job> GetAllJob()
        {
            var listJobe = dbContext.Jobs.ToList();
            return mapper.Map<List<Job>>(listJobe);
        }

        public JobDTO GetJobById(int jobId)
        {
            var job = dbContext.Jobs.FirstOrDefault(a => a.JobId == jobId);
            return mapper.Map<JobDTO>(job);
        }

        public void CreateJob(JobDTO jobDTO)
        {
            try
            {
                var job = mapper.Map<Job>(jobDTO);
                dbContext.Jobs.Add(job);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception("An unknown error occurred.", ex);
                }
            }
        }

        public void UpdateJob(JobDTO jobDTO)
        {
            var existingJob = dbContext.Jobs.FirstOrDefault(j => j.JobId == jobDTO.JobId);

            if (existingJob != null)
            {
                var update = mapper.Map(jobDTO, existingJob);
                dbContext.Jobs.Update(update);
                dbContext.SaveChanges();
            }
        }

        public void DeleteJob(int jobId)
        {
            var job = dbContext.Jobs.FirstOrDefault(a => a.JobId == jobId);

            if (job != null)
            {
                var saveJov = dbContext.SavedJobs.Where(j => j.JobId == jobId).ToList();
                var jobApplicant = dbContext.JobApplicants.Where(j => j.JobId == jobId).ToList();

                dbContext.SavedJobs.RemoveRange(saveJov);
                dbContext.JobApplicants.RemoveRange(jobApplicant);
                dbContext.Jobs.Remove(job);

                dbContext.SaveChanges();
            }
        }
    }
}
