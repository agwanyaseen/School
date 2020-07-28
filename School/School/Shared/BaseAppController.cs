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
        //public IActionResult FromResult<T>(Result<T> result)
        //{
        //    if (result.IsSuccess)
        //    {
        //        var resp = new ResultClass()
        //        {
        //            Result = result.Value
        //        };
        //        return Ok(resp);
        //    }
        //    else
        //    {
        //        var resp = new ResultClass()
        //        {
        //            Error = result.Error
        //        };
        //        return BadRequest(resp);
        //    }
        //}

        //public IActionResult FromResult(object result)
        //{
        //    var resp = new ResultClass(result, null);
        //    var a = Ok(resp);
        //    return a;
        //}
        internal IActionResult FromResult(Maybe<object> users)
        {
            return Ok(new ResultClass(users.Value, null));
        }
    }
}
