using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Infrastructures
{
    internal class Result
    {
        public int Code { get;protected set; }
        public string Message { get;protected set; }
    }

    internal class Result<T>:Result
    { 
        public T Data { get; set; }
    }
}
