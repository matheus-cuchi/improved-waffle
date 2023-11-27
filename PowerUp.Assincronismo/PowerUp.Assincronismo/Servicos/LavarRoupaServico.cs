using Serilog;

namespace PowerUp.Assincronismo.Servicos;

public class LavadouraServico
{
    public void ColocarRoupaParaLavar(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} foi colocou a roupa para lavar", faxineira);
        Task.Delay(500).ConfigureAwait(false).GetAwaiter().GetResult();
        Log.Logger.Information("A faxineira {Faxineira} terminou de colocar a roupa para lavar", faxineira);
    }

    public async Task EncherMaquinaDeAguaAsync(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} está enchendo a maquina de agua", faxineira);
        await Task.Delay(4000).ConfigureAwait(false);
        Log.Logger.Information("A faxineira {Faxineira} terminou de encher a maquina de agua", faxineira);
    }

    public async Task LavarRoupaAsync(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} colocou a mauqina para lavar a roupa", faxineira);
        await Task.Delay(4000).ConfigureAwait(false);
        Log.Logger.Information("A faxineira {Faxineira} terminou de lavar a roupa", faxineira);
    }
}