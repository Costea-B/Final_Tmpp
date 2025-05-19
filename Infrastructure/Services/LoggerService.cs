using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
     public sealed class LoggerService: ILoggerService
     {
          private static readonly Lazy<LoggerService> _instance = new(() => new LoggerService());
          private readonly string _logFilePath;

          private LoggerService()
          {
               var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
               Directory.CreateDirectory(logDir);
               _logFilePath = Path.Combine(logDir, $"log_{DateTime.Now:yyyyMMdd}.txt");
          }

          public static LoggerService Instance => _instance.Value;

          public void LogInfo(string message) => WriteLog("INFO", message);
          public void LogWarning(string message) => WriteLog("WARN", message);
          public void LogError(string message, Exception ex = null)
          {
               WriteLog("ERROR", $"{message} {ex?.ToString()}");
          }

          private void WriteLog(string level, string message)
          {
               var logEntry = $"[{DateTime.Now:HH:mm:ss}] [{level}] {message}";
               File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
          }
     }
}
