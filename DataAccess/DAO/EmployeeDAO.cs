using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class EmployeeDAO
    {
        private readonly PRN231_ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public EmployeeDAO(PRN231_ProjectDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public EmployeeDTO GetEmployeeByEmailAndPassWord(string email, string password)
        {
            var findEmployee = dbContext.Employers.FirstOrDefault(j => j.Email == email && j.Password == password);
            return mapper.Map<EmployeeDTO>(findEmployee);
        }

        public List<EmployeeDTO> GetAllEmployee()
        {
            var listEmployee = dbContext.Employers.ToList();
            return mapper.Map<List<EmployeeDTO>>(listEmployee);
        }

        public EmployeeDTO GetJobSeekerById(int employeeId)
        {
            var employee = dbContext.Employers.FirstOrDefault(j => j.EmployerId == employeeId);
            return mapper.Map<EmployeeDTO>(employee);
        }

        public EmployeeDTO GetEmployeeByEmail(string employeeEmail)
        {
            var employee = dbContext.Employers.FirstOrDefault(j => j.Email == employeeEmail);
            return mapper.Map<EmployeeDTO>(employee);
        }

        public void CreateEmployee(EmployerRegisterDTO employeeDTO)
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

        public void UpdateEmployee(EmployeeDTO employeeDTO)
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