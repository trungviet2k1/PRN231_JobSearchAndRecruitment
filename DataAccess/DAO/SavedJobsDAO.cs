using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class SavedJobsDAO
    {
        private readonly PRN231_ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public SavedJobsDAO(PRN231_ProjectDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public List<SavedJobs> GetAllJob()
        {
            var listJobe = dbContext.SavedJobs.ToList();
            return mapper.Map<List<SavedJobs>>(listJobe);
        }

        public SavedJobsDTO GetSaveJobById(int saveJobId)
        {
            var saveJob = dbContext.SavedJobs.FirstOrDefault(a => a.JobId == saveJobId);
            return mapper.Map<SavedJobsDTO>(saveJob);
        }

        public void CreateSaveJob(SavedJobsDTO saveJobDTO)
        {
            try
            {
                var saveJob = mapper.Map<SavedJobs>(saveJobDTO);
                dbContext.SavedJobs.Add(saveJob);
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

        public void DeleteSaveJob(int saveJobId)
        {
            var job = dbContext.SavedJobs.FirstOrDefault(a => a.SavedJobId == saveJobId);

            if(job != null)
            {
                dbContext.SavedJobs.Remove(job);
                dbContext.SaveChanges();
            }
        }
    }
}
