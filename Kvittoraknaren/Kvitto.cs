using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kvittoraknaren;

public record Vara(string Namn, decimal PrisExklMoms, decimal Momsstas);

public static class Kvittoraknaren
{
    public static decimal BeraknaTotal(IEnumerable<Vara> varor, string? rabattkod = null)
    {
        var rabattsats = HamtaRabattsats(rabattkod);
        return varor.Sum(v => v.PrisExklMoms * (1 - rabattsats) * (1 + v.Momsstas));
    }

    private static decimal HamtaRabattsats(string? rabattkod)
    {
        return rabattkod switch
        {
            null => 0m,
            "RABATT10" => 0.10m,
            _ => throw new ArgumentException($"Okänd rabattkod: {rabattkod}", nameof(rabattkod))
        };
    }
}