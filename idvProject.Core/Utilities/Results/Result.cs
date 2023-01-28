using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string messsage) : this(success)
        {
            Message = messsage;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
