using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BvnValidationAPInew.LogService
{
   public interface ILogWriter
    {
        string LogWrite(string message, string type);

        string LogWarn(string message, string type);
    }
}
