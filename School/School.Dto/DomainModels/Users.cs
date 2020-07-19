using System;
using System.Collections.Generic;
using System.Text;

namespace School.Dto.DomainModels
{
    public class Users
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public int Type { get; set; }

        public Users()
        {

        }

        private Users(string firstName, string lastname, string email, string number, string password, int role, int type)
        {
            FirstName = firstName;
            LastName = lastname;
            Email = email;
            ContactNumber = number;
            Password = password;
            Role = role;
            Type = type;
        }

        public static Users Create(string firstName, string lastname, string email, string number, string password, int role, int type)
        {
            return new Users(firstName, lastname, email, number, password, role, type);
        }
    }
}
