﻿using JWTtoken.Enums;

namespace JWTtoken.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
