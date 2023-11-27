using PowerUp.Assincronismo.Uteis;
using Serilog;

namespace PowerUp.Assincronismo.Servicos;

public class FaxineiraFachada
{
    private readonly LavadouraServico lavadouraServico;
    private readonly CafeteiraServico cafeteiraServico;

    public FaxineiraFachada(LavadouraServico lavadouraServico, CafeteiraServico cafeteiraServico)
    {
        this.lavadouraServico = lavadouraServico;
        this.cafeteiraServico = cafeteiraServico;
    }

    public void Faxineira(string nome)
    {
        var metrica = new Metrica();
        cafeteiraServico.BuscarXicaras(nome);
        cafeteiraServico.EsquentarAguaAsync(nome).ConfigureAwait(false).GetAwaiter().GetResult();
        cafeteiraServico.PassarCafe(nome);

        lavadouraServico.ColocarRoupaParaLavar(nome);
        lavadouraServico.EncherMaquinaDeAguaAsync(nome).ConfigureAwait(false).GetAwaiter().GetResult();
        lavadouraServico.LavarRoupaAsync(nome).ConfigureAwait(false).GetAwaiter().GetResult();

        cafeteiraServico.TomarCafe(nome);

        Log.Logger.Information("A faxineira {Nome} levou {Metrica} para realizar as operações", nome, metrica.TempoDecorrido());
    }

    public async Task FaxineiraAsync(string nome)
    {
        var metrica = new Metrica();
        cafeteiraServico.BuscarXicaras(nome);
        var esquentarAgua = cafeteiraServico.EsquentarAguaAsync(nome);

        lavadouraServico.ColocarRoupaParaLavar(nome);
        var encherMaquina = lavadouraServico.EncherMaquinaDeAguaAsync(nome);

        await esquentarAgua;
        cafeteiraServico.PassarCafe(nome);

        await encherMaquina;
        var lavarRoupa = lavadouraServico.LavarRoupaAsync(nome);

        cafeteiraServico.TomarCafe(nome);

        await lavarRoupa;

        Log.Logger.Information("A faxineira {Nome} levou {Metrica} para realizar as operações",nome, metrica.TempoDecorrido());
    }
}