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
        private readonly IDocumentHandler _docHandler;

        public HomeController(UserRepo repo, IDocumentHandler docHandler)
        {
            _repo = repo;
            _docHandler = docHandler;
        }

        [HttpGet]
        public IActionResult Get(IFormFile file)
        {
            var path = _docHandler.UploadImage(file);
            var users = _repo.GetAllUsers();
            return base.FromResult(base.Ok());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var users = _repo.GetUser(id);
            return base.FromResult(users);
        }

        [HttpGet("file")]
        public IActionResult Post()
        {
            throw new Exception("User Not Found");
        }

        [HttpGet("login")]
        public IActionResult login(string email, string password)
        {
            var userId = _repo.LoginUser(email, password);
            return base.FromResult(userId);
        }
    }
}