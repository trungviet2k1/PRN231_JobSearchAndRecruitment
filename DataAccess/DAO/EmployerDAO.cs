using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class EmployerDAO
    {
        private readonly PRN231_ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public EmployerDAO(PRN231_ProjectDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public EmployerDTO GetEmployerByEmailAndPassWord(string email, string password)
        {
            var findEmployee = dbContext.Employers.FirstOrDefault(j => j.Email == email && j.Password == password);
            return mapper.Map<EmployerDTO>(findEmployee);
        }

        public List<EmployerDTO> GetAllEmployer()
        {
            var listEmployee = dbContext.Employers.ToList();
            return mapper.Map<List<EmployerDTO>>(listEmployee);
        }

        public EmployerDTO GetEmployerById(int employeeId)
        {
            var employee = dbContext.Employers.FirstOrDefault(j => j.EmployerId == employeeId);
            return mapper.Map<EmployerDTO>(employee);
        }

        public EmployerDTO GetEmployerByEmail(string employeeEmail)
        {
            var employee = dbContext.Employers.FirstOrDefault(j => j.Email == employeeEmail);
            return mapper.Map<EmployerDTO>(employee);
        }

        public void CreateEmployer(EmployerRegisterDTO employeeDTO)
        {
            try
            {
                var employee = mapper.Map<Employer>(employeeDTO);
                dbContext.Employers.Add(employee);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void UpdateEmployer(EmployerDTO employeeDTO)
        {
            var existingEmployee = dbContext.Employers.FirstOrDefault(j => j.EmployerId == employeeDTO.EmployerId);
            if (existingEmployee != null)
            {
                mapper.Map(employeeDTO, existingEmployee);
                dbContext.SaveChanges();
            }
        }
    }
}