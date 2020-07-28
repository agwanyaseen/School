using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
namespace School.Lib.Shared
{
    public class BaseServices
    {
        public Maybe<T> Result<T>(T obj)
        {
            return Maybe<T>.From(obj);
        }
    }
}
