namespace BusinessObject.DTOs
{
    public class EmployerLogin : LoginDTO { }

    public class EmployerRegister : EmployerRegisterDTO { }

    public class EmployeeDTO 
    {
        public int EmployerId { get; set; }

        public string CompanyName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsEmployer { get; set; } = true;
    }
}