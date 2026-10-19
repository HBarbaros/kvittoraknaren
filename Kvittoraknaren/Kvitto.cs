using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kvittoraknaren;

public record Vara(string Namn, decimal PrisExklMoms, decimal Momsstas);

public static class Kvittoraknaren
{
    public static decimal BeraknaTotal(IEnumerable<Vara> varor)
    {
        return varor.Sum(v => v.PrisExklMoms * (1 + v.Momsstas));
    }
}