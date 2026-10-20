using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kvittoraknaren;

public record Vara(string Namn, decimal PrisExklMoms, decimal Momsstas);

public static class Kvittoraknaren
{
    private const string Rabattkod = "RABATT10";

    public static decimal BeraknaTotal(IEnumerable<Vara> varor, string? rabattkod = null)
    {
        var rabattfaktor = rabattkod == Rabattkod ? 0.90m : 1m;

        return varor.Sum(v => v.PrisExklMoms * rabattfaktor * (1 + v.Momsstas));
    }
}
