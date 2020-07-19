using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using School.Dto.DomainModels;
using School.Lib.DAL.Context;
using Newtonsoft.Json;
namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseAppController
    {
        private SchoolContext _schoolContext;

        public ValuesController(SchoolContext context)
        {
            _schoolContext = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var user = new List<UserType>()
            {
                new UserType()
                {
                    TypeId = 1,
                    TypeName = "BAC"
                },
                new UserType()
                {
                    TypeId = 2,
                    TypeName = "BAC"
                },

            };
            var json = JsonConvert.SerializeObject(user,Formatting.Indented);
            var a = CSharpFunctionalExtensions.Result.Success<string>(json);
            return base.FromResult(a);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = new List<UserType>()
            {
                new UserType()
                {
                    TypeId = 1,
                    TypeName = "BAC"
                },
                new UserType()
                {
                    TypeId = 2,
                    TypeName = "BAC"
                },

            };
            var json = JsonConvert.SerializeObject(user);
            var a = CSharpFunctionalExtensions.Result.Failure<string>(json);
            return base.FromResult(a);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
