using CSharpFunctionalExtensions;
using School.Dto.DomainModels;
using School.Lib.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Lib.DAL
{
    public class TeachersRepo
    {
        private SchoolContext _context;
        private readonly string teachernotfound = "Teacher Not Found";
        private readonly string teacheradded = "Teacher Added";

        public TeachersRepo(SchoolContext context)
        {
            _context = context;
        }

        public Result<List<Teachers>> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Result<Teachers> GetTeacher(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.TeacherId == id);

            if (teacher == null)
            {
                return Result.Failure<Teachers>(teachernotfound);
            }
            return Result.Success(teacher);
        }

        public Result<string> AddNewTeacher(Teachers teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Result.Success(teacheradded);
        }
    }
}
