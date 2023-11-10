using BusinessObject.DTOs;

namespace Service.IRepository
{
    public interface IEmployeeRepository
    {
        EmployeeDTO GetEmployeeByEmailAndPassword(string email, string password);
        List<EmployeeDTO> GetAllEmployee();
        EmployeeDTO GetEmployeeById(int employeeId);
        EmployeeDTO GetEmployeeByEmail(string email);
        void CreateEmployee(EmployerRegisterDTO employerRegisterDTO);
        void UpdateEmployee(EmployeeDTO employeeDTO);
    }
}