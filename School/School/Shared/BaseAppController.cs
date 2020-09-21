using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using School.Middlewares;
using School.Dto.DomainModels;

namespace School.Shared
{
    public class BaseAppController : ControllerBase
    {
        internal IActionResult FromResult(Maybe<object> users)
        {
            return Ok(new ResultClass(users.Value, null));
        }
        internal IActionResult FromResult<T>(Maybe<T> users)
        {
            return Ok(new ResultClass(users.Value, null));
        }

        internal IActionResult FromResult<T>(Result<T> result)
        {
            if (result.IsFailure)
            {
                return BadRequest(new ResultClass(null,result.Error));
            }
            return Ok(new ResultClass(result.Value, null));
        }
    }
}
