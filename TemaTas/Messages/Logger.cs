using System;
using System.Collections.Generic;
using System.Text;


namespace TemaTasCasapu.Messages
{
    public static class Logger
    {
        public static MessageHandler log = new MessageHandler();
        public static void AddLog(string Message)
        {
            log.Log(Message);
        }
    }
}
