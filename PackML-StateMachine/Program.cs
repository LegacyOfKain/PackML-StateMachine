using PackML_StateMachine.Services;
using Serilog;

namespace PackML_StateMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            // Configure Serilog
            builder.Services.AddSerilog((services, lc) => lc
                .ReadFrom.Configuration(builder.Configuration)
                .ReadFrom.Services(services));

            builder.Services.AddSingleton<IPackMLService, PackMLService>();

            var host = builder.Build();

            StateMachineLogger.Initialize(host.Services.GetRequiredService<ILoggerFactory>());

            host.Run();
        }
    }
}