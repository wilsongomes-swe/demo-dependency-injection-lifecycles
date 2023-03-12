namespace Api;

public interface ILogger
{
    void Log(object service, string log);
}

public class Logger : ILogger, IDisposable
{
    public Logger(bool showLog = true)
    {
        if(showLog)
            Log(this, "🟡 **** ###  Logger constructor (new instance)");
    }

    public void Log(object service, string log)
    {
        var type = service.GetType().Name;
        var hash = service.GetHashCode();

        Console.WriteLine($"{type}({hash})");
        Console.WriteLine($"  -> {log}");
    }

    public void Dispose() => Log(this, "Disposing...");
}