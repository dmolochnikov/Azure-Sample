using System;
using System.Reflection;
using log4net;

namespace BookStore
{
    public static class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message)
        {
            Log.Info(message);
        }

        public static void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }
    }
}