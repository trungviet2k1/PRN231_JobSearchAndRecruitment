﻿using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = ("Email is required!"))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ("Password is required!"))]
        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;
    }
}