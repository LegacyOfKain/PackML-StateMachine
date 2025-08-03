using System.Collections.Concurrent;

namespace PackML_StateMachine;
public static class StateMachineLogger
{
    private static ILoggerFactory? _loggerFactory;
    private static readonly ConcurrentDictionary<string, ILogger> _loggers = new();

    public static void Initialize(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public static ILogger For<T>()
    {
        return For(typeof(T));
    }

    public static ILogger For(Type type)
    {
        return For(type.FullName ?? type.Name);
    }

    public static ILogger For(string categoryName)
    {
        if (_loggerFactory == null)
            throw new InvalidOperationException("StaticLogger not initialized. Call Initialize() first.");

        return _loggers.GetOrAdd(categoryName, name => _loggerFactory.CreateLogger(name));
    }
}
