using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.ConfigHelper.Enricher;
using Serilog.Events;

namespace PowerUp.Assincronismo.Uteis;

public static class Ambiente
{
    private const string TempleteLog = "[{Timestamp:HH:mm:ss} {ThreadId:0000}] {Message:lj}{NewLine}{Exception}";
    private static readonly IServiceCollection servicos;

    public static IServiceProvider Provedor { get; private set; }

    static Ambiente()
    {
        servicos = new ServiceCollection();
        servicos.AddLogging();
        Provedor = servicos.BuildServiceProvider();

        Log.Logger = new LoggerConfiguration()
            .Enrich.With(new ThreadIdEnricher())
            .WriteTo.Console(outputTemplate: TempleteLog, restrictedToMinimumLevel: LogEventLevel.Debug)
            .CreateLogger();
    }

    public static void ConfigurarServicos(Action<IServiceCollection> colecao)
    {
        ArgumentNullException.ThrowIfNull(colecao);
        colecao(servicos);
        Provedor = servicos.BuildServiceProvider();
    }
}