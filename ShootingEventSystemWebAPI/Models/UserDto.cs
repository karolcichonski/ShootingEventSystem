﻿using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
