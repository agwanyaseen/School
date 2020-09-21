using Microsoft.AspNetCore.Mvc;
using School.Dto.DomainModels;
using School.Lib.DAL;
using School.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : BaseAppController
    {
        private readonly TeachersRepo _teachersrepo;

        public TeachersController(TeachersRepo teachers)
        {
            _teachersrepo = teachers;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _teachersrepo.GetTeachers();
            return base.FromResult(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacher(int id)
        {
            var teacher = _teachersrepo.GetTeacher(id);
            return base.FromResult(teacher);
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody]Teachers teacher)
        {
            var result = _teachersrepo.AddNewTeacher(teacher);
            return base.FromResult(result);
        }

    }
}
