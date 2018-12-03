using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.lib
{
    public class ErrorLogger
    {
        public ErrorLevel level;
        public String Message;
        public ErrorLogger(ErrorLevel _level, string _message)
        {
            level = _level;
            Message = _message;
            //Logger.Write(Logger.LogTypes.Info, "[{0}] {1}", level.ToString(), message); TODO
        }
    }
    internal class Error
    {
        private ErrorLevel level;
        private string message;

        internal Error(ErrorLevel level, string message)
        {
            this.level = level;
            this.message = message;
        }
    }

    public enum ErrorLevel
    {
        ObjectDisposedException,//已释放对象访问异常
        Exception,//普通异常
    }
}
