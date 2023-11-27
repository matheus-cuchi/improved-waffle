using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PowerUp.Assincronismo;
using PowerUp.Assincronismo.Servicos;
using PowerUp.Assincronismo.Uteis;

Ambiente.ConfigurarServicos(
    servicos =>
    {
        servicos.TryAddTransient<CafeteiraServico>();
        servicos.TryAddTransient<FaxineiraFachada>();
        servicos.TryAddTransient<LavadouraServico>();
    });

var fachada = Ambiente.Provedor.GetRequiredService<FaxineiraFachada>();

fachada.Faxineira("Faxineira 1");
await fachada.FaxineiraAsync("Faxineira 2");