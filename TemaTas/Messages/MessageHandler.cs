using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TemaTasCasapu.Messages;

namespace TemaTasCasapu
{
    public class MessageHandler : ILogger
    {
        List<String> performedLogActions = new List<string>();
        List<String> expectedLogActions = new List<string>();
        int expectedNumberOfCalls = 0;

        public void Log(String message)
        {
            performedLogActions.Add("method " + MethodBase.GetCurrentMethod().Name + " was called with message : " + message);
        }

        public void AddExpectedLogMessage(String message)
        {
            expectedLogActions.Add(message);
        }

        public bool Verify()
        {
            if (GetNumberOfCalls() != expectedNumberOfCalls)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<String> GetActions()
        {
            return performedLogActions;
        }

        public int GetNumberOfCalls()
        {
            return performedLogActions.Count;
        }

        public void ExpectedNumberOfCalls(int p)
        {
            expectedNumberOfCalls = p;
        }
    }
}
