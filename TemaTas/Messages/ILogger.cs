using System;
using System.Collections.Generic;
using System.Text;

namespace TemaTasLC.Messages
{
    public interface ILogger
    {
        void Log(String message);
        List<String> GetActions();
        int GetNumberOfCalls();
    }
}
