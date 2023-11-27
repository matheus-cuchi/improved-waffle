using System.Diagnostics;

namespace PowerUp.Assincronismo.Uteis;

public readonly struct Metrica
{
    private readonly long tempoInicial;

    public Metrica()
    {
        tempoInicial = Stopwatch.GetTimestamp();
    }

    public string TempoDecorrido() => Stopwatch.GetElapsedTime(tempoInicial).ToString("g");
}