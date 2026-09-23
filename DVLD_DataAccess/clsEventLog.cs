using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsEventLog
    {
        private static string _source = "DVLDApp";

        
        static clsEventLog()
        {
            Initialize();
        }
        private static void Initialize()
        {
            try
            {
                if (!EventLog.SourceExists(_source))
                {
                    EventLog.CreateEventSource(_source, "Application");
                }
            }
            catch (Exception ex)
            {
                // Handle exception if needed
                Console.WriteLine($"Error initializing event log: {ex.Message}");
            }
        }
        private static void _WriteLog(string Message, EventLogEntryType type)
        {
            try
            {
                EventLog.WriteEntry(_source, Message, type);

            }
            catch (Exception ex)
            {
                // Handle exception if needed
                Console.WriteLine($"Error writing to event log: {ex.Message}");
            }
        }
        private static void BuildAndWriteLog(string UserMessage,EventLogEntryType type, Exception ex) 
        {
            StackTrace stackTrace = new StackTrace(2,true);
            StackFrame frame = stackTrace.GetFrame(0);
            
            MethodBase CallingMethod = frame?.GetMethod();

            string ClassName = CallingMethod?.DeclaringType?.FullName ?? "UnknownClass";
            string MethodName = CallingMethod?.Name ?? "UnknownMethod";
            string LineNumber = frame?.GetFileLineNumber().ToString() ?? "UnknownLine";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("=========================================\n" +
                "\n[Location] Class : {0} -> Method {1}" +
                "\nAt Line {2} " +
                "\nDate : {3}" +
                "\n[Message] : " +
                "\n\t\t {4}", 
                ClassName,MethodName, LineNumber,DateTime.Now, UserMessage);

            if (ex != null)
            {
                sb.AppendFormat("\n[Exception] : \n\t\t {0}" +
                    "[Stack Trace] {1}", 
                    ex.Message.ToString(),ex.StackTrace);
            }
            sb.Append("\n=========================================");
            _WriteLog(sb.ToString(),type);
        }



        //<summary>
        // Logs an informational message to the event log.
        //</summary>
        //<param name="message">The message to log.</param>
        public static void LogInfo(string message)
        {
            BuildAndWriteLog(message, EventLogEntryType.Information, null);
        }
        //<summary>
        // Logs a warning message to the event log.
        //</summary>
        //<param name="message">The message to log.</param>
        public static void LogWarning(string message)
        {
            BuildAndWriteLog(message, EventLogEntryType.Warning,null);
        }
        //<summary>
        // Logs a Error message to the event log.
        //</summary>
        //<param name="message">The message to log.</param>
        public static void LogError(string message,Exception ex)
        {
            BuildAndWriteLog(message, EventLogEntryType.Error, ex);
        }
    }
}
