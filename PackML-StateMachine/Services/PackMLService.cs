namespace PackML_StateMachine.Services;

public class PackMLService : IPackMLService
{
    private readonly ILogger _logger = StateMachineLogger.For<PackMLService>();

    public async Task RunAsync()
    {
        _logger.LogInformation("PackML State Machine service started");
        
        // Your PackML state machine logic will go here
        _logger.LogInformation("Initializing PackML State Machine...");
        
        // Simulate some work
        await Task.Delay(1000);
        
        _logger.LogInformation("PackML State Machine initialized successfully");
        
        _logger.LogInformation("PackML State Machine service completed");
    }
}