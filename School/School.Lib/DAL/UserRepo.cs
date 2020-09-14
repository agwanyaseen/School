using CSharpFunctionalExtensions;
using School.Dto.DomainModels;
using School.Lib.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace School.Lib.DAL
{
    public class UserRepo
    {
        private readonly SchoolContext _schoolContext;

        public UserRepo(SchoolContext context)
        {
            _schoolContext = context;
        }

        public List<Users> GetAllUsers()
        {
            var result = _schoolContext.Users.ToList();
            return result;
        }

        public void AddNewUser(Users user)
        {
            _schoolContext.Users.Add(user);
            _schoolContext.SaveChanges();
        }

        public Users GetUser(int id)
        {
            var user = _schoolContext.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            return user;
        }

        public string LoginUser(string email, string password)
        {
            var userId = _schoolContext.Users.Where(x => x.Email == email && x.Password == password)
                                                .Select(x => x.UserId).FirstOrDefault();

            if (userId == 0)
            {
                throw new Exception("User Not Found");
            }

            return userId.ToString();
        }

        public void UpdateUser(Users user)
        {
            var updateuser = _schoolContext.Users.Find(user.UserId);
            if (updateuser == null)
            {
                throw new Exception("User Not Found");
            }

            _schoolContext.Users.Update(updateuser);
            _schoolContext.SaveChanges();
        }
    }
}
