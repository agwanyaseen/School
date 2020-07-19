using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using School.Middlewares;

namespace School.Shared
{
    public class BaseAppController : ControllerBase
    {
        public IActionResult FromResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                var resp = new ResultClass<T>()
                {
                    Result = result.Value
                };
                return Ok(resp);
            }
            else
            {
                var resp = new ResultClass<string>()
                {
                    Error = result.Error
                };
                return BadRequest(resp);
            }
        }

        public IActionResult FromResult(Maybe<object> result)
        {
            var resp = new ResultClass<object>()
            {
                Result = result.Value
            };
            return Ok(resp);
        }
    }
}
