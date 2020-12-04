using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TemaTasCasapu.Messages
{
    public class LogSpy : ILogger
    {
        List<String> actions = new List<string>();
        public void Log(String message)
        {
            actions.Add(MethodBase.GetCurrentMethod().Name + "(" + DateTime.Now + ") " + message);
        }


        public List<String> GetActions()
        {
            return actions;
        }

        public int GetNumberOfCalls()
        {
            return actions.Count;
        }
    }
}
