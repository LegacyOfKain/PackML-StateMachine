using PackML_StateMachine.Services;

namespace PackML_StateMachine
{
    public class Worker : BackgroundService
    {
        private static readonly ILogger _logger = StateMachineLogger.For<Worker>();
        private readonly IPackMLService _packMLService;

        public Worker(IPackMLService packMLService)
        {
            _packMLService = packMLService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
                }
                await _packMLService.RunAsync();
            //}
        }
    }
}
