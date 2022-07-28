using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Behaviors
{
    public interface IValidationExceptionHandler
    {
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get;
            set;
        }
    }
}
