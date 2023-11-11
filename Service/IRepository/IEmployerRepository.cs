using BusinessObject.DTOs;

namespace Service.IRepository
{
    public interface IEmployerRepository
    {
        EmployerDTO GetEmployerByEmailAndPassword(string email, string password);
        List<EmployerDTO> GetAllEmployer();
        EmployerDTO GetEmployerById(int employeeId);
        EmployerDTO GetEmployerByEmail(string email);
        void CreateEmployer(EmployerRegisterDTO employerRegisterDTO);
        void UpdateEmployer(EmployerDTO employeeDTO);
    }
}