using Serilog;

namespace PowerUp.Assincronismo.Servicos;

public class CafeteiraServico
{
    public void BuscarXicaras(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} está buscando xicaras", faxineira);
        Task.Delay(500).ConfigureAwait(false).GetAwaiter().GetResult();
        Log.Logger.Information("A faxineira {Faxineira} terminou de buscar xicaras", faxineira);
    }

    public async Task EsquentarAguaAsync(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} colocou a aguá para esquentar", faxineira);
        await Task.Delay(5000).ConfigureAwait(false);
        Log.Logger.Information("A aguá da faxineira {Faxineira} está quente", faxineira);
    }

    public void PassarCafe(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} está passando o cafe", faxineira);
        Task.Delay(2000).ConfigureAwait(false).GetAwaiter().GetResult();
        Log.Logger.Information("A faxineira {Faxineira} terminou de passar o cafe", faxineira);
    }
    
    public void TomarCafe(string faxineira)
    {
        Log.Logger.Information("A faxineira {Faxineira} está tomando o cafe", faxineira);
        Task.Delay(2000).ConfigureAwait(false).GetAwaiter().GetResult();
        Log.Logger.Information("A faxineira {Faxineira} terminou de tomar o cafe", faxineira);
    }
}