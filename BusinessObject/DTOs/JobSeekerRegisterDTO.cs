using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class JobSeekerRegisterDTO : LoginDTO
    {
        [Required(ErrorMessage = ("Full Name is required!"))]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = ("Phone Number is required!"))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        public bool IsEmployer { get; set; } = false;
    }
}