namespace Kvittoraknaren;

public record Vara(string Namn, decimal PrisExklMoms, decimal Momsstas);

public static class Kvittoraknaren
{
    public const string RabattkodTioProcent = "RABATT10";

    public static decimal BeraknaTotal(IEnumerable<Vara> varor, string? rabattkod = null)
    {
        var rabattfaktor = rabattkod == RabattkodTioProcent ? 0.90m : 1m;

        return varor.Sum(v => v.PrisExklMoms * rabattfaktor * (1 + v.Momsstas));
    }
}