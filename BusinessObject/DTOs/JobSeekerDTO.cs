namespace BusinessObject.DTOs
{
    public class JobSeekerLogin : LoginDTO { }

    public class JobSeekerRegister : JobSeekerRegisterDTO { }

    public class JobSeekerDTO
    {
        public int JobSeekerId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsEmployer { get; set; } = false;

        public string? Address { get; set; } 

        public string? ProfileDescription { get; set; } 

        public string? Education { get; set; } 

        public string? WorkExperience { get; set; } 
    }
}