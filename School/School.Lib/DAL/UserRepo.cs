using CSharpFunctionalExtensions;
using School.Dto.DomainModels;
using School.Lib.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using School.Lib.Shared;
using System.Linq;

namespace School.Lib.DAL
{
    public class UserRepo : BaseServices
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
    }
}
