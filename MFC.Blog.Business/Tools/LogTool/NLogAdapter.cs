using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MFC.Blog.Business.Tools.LogTool
{
    public class NLogAdapter:ICustomLogger
    {
        public void LogError(string message)
        {
            var logger =LogManager.GetLogger("fileLogger");
            logger.Log(LogLevel.Error, message);
        }
    }
}
