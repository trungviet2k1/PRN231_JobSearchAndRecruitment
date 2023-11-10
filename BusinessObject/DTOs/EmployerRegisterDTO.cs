﻿using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class EmployerRegisterDTO : LoginDTO
    {
        [Required(ErrorMessage = ("Full Name is required!"))]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = ("Phone Number is required!"))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = ("Company Name is required!"))]
        public string CompanyName { get; set; } = null!;
    }
}