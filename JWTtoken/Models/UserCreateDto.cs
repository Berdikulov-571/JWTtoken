﻿using JWTtoken.Enums;

namespace JWTtoken.Models
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
