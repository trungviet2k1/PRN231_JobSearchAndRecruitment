using BusinessObject.DTOs;
using DataAccess.DAO;
using Service.IRepository;

namespace Service.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDAO _employeeDAO;

        public EmployeeRepository(EmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }

        public void CreateEmployee(EmployerRegisterDTO employerRegisterDTO) 
            => _employeeDAO.CreateEmployee(employerRegisterDTO);

        public List<EmployeeDTO> GetAllEmployee() => _employeeDAO.GetAllEmployee();

        public EmployeeDTO GetEmployeeByEmail(string email) => _employeeDAO.GetEmployeeByEmail(email);

        public EmployeeDTO GetEmployeeByEmailAndPassword(string email, string password) 
            => _employeeDAO.GetEmployeeByEmailAndPassWord(email, password);

        public EmployeeDTO GetEmployeeById(int employeeId) => _employeeDAO.GetJobSeekerById(employeeId);

        public void UpdateEmployee(EmployeeDTO employeeDTO) => _employeeDAO.UpdateEmployee(employeeDTO);
    }
}
