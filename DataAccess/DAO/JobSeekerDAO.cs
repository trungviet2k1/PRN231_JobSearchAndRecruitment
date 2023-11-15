using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class JobSeekerDAO
    {
        private readonly PRN231_ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public JobSeekerDAO(PRN231_ProjectDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public JobSeekerDTO GetJobSeekerByEmailAndPassWord(string email, string password)
        {
            var findJobSeeker = dbContext.JobSeekers.FirstOrDefault(j => j.Email == email && j.Password == password);
            return mapper.Map<JobSeekerDTO>(findJobSeeker);
        }

        public List<JobSeeker> GetAllJobSeekers()
        {
            var listJobSeeker = dbContext.JobSeekers.ToList();
            return mapper.Map<List<JobSeeker>>(listJobSeeker);
        }

        public JobSeekerDTO GetJobSeekerById(int jobSeekerId)
        {
            var jobSeeker = dbContext.JobSeekers.FirstOrDefault(j => j.JobSeekerId == jobSeekerId);
            return mapper.Map<JobSeekerDTO>(jobSeeker);
        }

        public JobSeekerDTO GetJobSeekerByEmail(string jobSeekerEmail)
        {
            var jobSeeker = dbContext.JobSeekers.FirstOrDefault(j => j.Email == jobSeekerEmail);
            return mapper.Map<JobSeekerDTO>(jobSeeker);
        }

        public void CreateJobSeeker(JobSeekerRegisterDTO jobSeekerDTO)
        {
            try
            {
                var jobSeeker = mapper.Map<JobSeeker>(jobSeekerDTO);
                dbContext.JobSeekers.Add(jobSeeker);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void UpdateJobSeeker(JobSeekerDTO jobSeekerDTO)
        {
            var existingJobSeeker = dbContext.JobSeekers.FirstOrDefault(j => j.JobSeekerId == jobSeekerDTO.JobSeekerId);
            if (existingJobSeeker != null)
            {
                existingJobSeeker.FullName = jobSeekerDTO.FullName;
                /*existingJobSeeker.Password = jobSeekerDTO.Password;*/
                existingJobSeeker.PhoneNumber = jobSeekerDTO.PhoneNumber;
                existingJobSeeker.Address = jobSeekerDTO.Address;
                existingJobSeeker.ProfileDescription = jobSeekerDTO.ProfileDescription;
                existingJobSeeker.Education = jobSeekerDTO.Education;  

                existingJobSeeker.WorkExperience=jobSeekerDTO.WorkExperience;   
                

                dbContext.JobSeekers.Update(existingJobSeeker);
                dbContext.SaveChanges();
            }
            
        }
      /*  public void CreateJobSeekr(JobSeekerDTO jobSeekerDTO)
        {
            try
            {
                var jobSeeker = mapper.Map<JobSeeker>(jobSeekerDTO);
                dbContext.JobSeekers.Add(jobSeeker);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }*/

    }
}
