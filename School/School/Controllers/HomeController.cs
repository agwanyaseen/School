using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Lib.DAL;
using School.Lib.DAL.Context;
using School.Shared;

namespace School.Controllers
{
    [Route("api/[controller]")]
    
    public class HomeController : BaseAppController
    {
        private readonly UserRepo _repo;
        private SchoolContext _context;

        public HomeController(UserRepo repo,SchoolContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repo.GetAllUsers();
            return base.FromResult(base.Ok());
        }

        [HttpGet("file")]
        public IActionResult Post()
        {
            throw new Exception("USer Not Found");
        }
    }
}