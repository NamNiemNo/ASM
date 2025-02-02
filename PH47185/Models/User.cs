﻿using System.ComponentModel.DataAnnotations;

namespace PH47185.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }

    }
}
