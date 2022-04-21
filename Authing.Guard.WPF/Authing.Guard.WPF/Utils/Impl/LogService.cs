using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Utils.Impl
{
    public class LogService : Logger, ILogService
    {
        private readonly Logger m_Logger = LogManager.GetCurrentClassLogger();
        public void ErrorMessage(Exception ex)
        {
            m_Logger.Error(ex);
        }

        public void InfoMessage(string info)
        {
            m_Logger.Info(info);
        }
    }
}
