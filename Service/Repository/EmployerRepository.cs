using BusinessObject.DTOs;
using DataAccess.DAO;
using Service.IRepository;

namespace Service.Repository
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly EmployerDAO _employerDAO;

        public EmployerRepository(EmployerDAO employerDAO)
        {
            _employerDAO = employerDAO;
        }

        public void CreateEmployer(EmployerRegisterDTO employerRegisterDTO) 
            => _employerDAO.CreateEmployer(employerRegisterDTO);

        public List<EmployerDTO> GetAllEmployer() => _employerDAO.GetAllEmployer();

        public EmployerDTO GetEmployerByEmail(string email) => _employerDAO.GetEmployerByEmail(email);

        public EmployerDTO GetEmployerByEmailAndPassword(string email, string password) 
            => _employerDAO.GetEmployerByEmailAndPassWord(email, password);

        public EmployerDTO GetEmployerById(int employerId) => _employerDAO.GetEmployerById(employerId);

        public void UpdateEmployer(EmployerDTO employerDTO) => _employerDAO.UpdateEmployer(employerDTO);
    }
}
