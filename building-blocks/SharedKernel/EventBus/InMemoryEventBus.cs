using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace SharedKernel.EventBus;

public class InMemoryEventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, List<Delegate>> _handlers = new();
    private readonly ILogger<InMemoryEventBus> _logger;

    public InMemoryEventBus(ILogger<InMemoryEventBus> logger)
    {
        _logger = logger;
    }

    public async Task PublishAsync<T>(T @event) where T : class
    {
        var eventType = typeof(T);

        _logger.LogInformation("Publishing event {EventType}", eventType.Name);

        if (!_handlers.TryGetValue(eventType, out var handlers))
        {
            _logger.LogDebug("No handlers registered for {EventType}", eventType.Name);
            return;
        }

        foreach (var handler in handlers)
        {
            try
            {
                await ((Func<T, Task>)handler)(@event);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling event {EventType}", eventType.Name);
            }
        }
    }

    public void Subscribe<T>(Func<T, Task> handler) where T : class
    {
        var eventType = typeof(T);
        var handlers = _handlers.GetOrAdd(eventType, _ => new List<Delegate>());
        handlers.Add(handler);

        _logger.LogInformation("Subscribed handler for {EventType}", eventType.Name);
    }
}
