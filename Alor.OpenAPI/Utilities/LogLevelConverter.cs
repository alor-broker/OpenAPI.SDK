using Serilog.Events;

namespace Alor.OpenAPI.Utilities
{
    public enum AlorOpenApiLogLevel
    {
        Verbose,
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }

    public static class LogLevelConverter
    {
        public static LogEventLevel ToSerilogLevel(this AlorOpenApiLogLevel alorLogLevel)
        {
            return alorLogLevel switch
            {
                AlorOpenApiLogLevel.Verbose => LogEventLevel.Verbose,
                AlorOpenApiLogLevel.Debug => LogEventLevel.Debug,
                AlorOpenApiLogLevel.Information => LogEventLevel.Information,
                AlorOpenApiLogLevel.Warning => LogEventLevel.Warning,
                AlorOpenApiLogLevel.Error => LogEventLevel.Error,
                AlorOpenApiLogLevel.Fatal => LogEventLevel.Fatal,
                _ => throw new ArgumentException("Неизвестный уровень логгирования", nameof(alorLogLevel))
            };
        }
    }

}
