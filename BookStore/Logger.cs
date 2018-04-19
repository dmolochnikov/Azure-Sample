using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore
{
    public static class Logger
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message)
        {
            Log.Info(message);
        }

        public static void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }
    }
}