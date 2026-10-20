using System.Runtime.InteropServices.Marshalling;
using Kvittoraknaren;
using Xunit;

namespace Kvittoraknaren.Tests;

public class KvittoTests
{
    [Fact]
    public void TvaVarorA100KrMed25ProcentMoms_Blir250()
    {
        var varor = new[]
        {
            new Vara("Bok", 100m, 0.25m),
            new Vara("Penna", 100m, 0.25m)
        };

        Assert.Equal(250m, Kvittoraknaren.BeraknaTotal(varor));

    }

    [Fact]
    public void TvaVarorA100KrMed25ProcentMomsOchRabatt10_Blir225()
    {
        var varor = new[]
        {
            new Vara("Bok", 100m, 0.25m),
            new Vara("Penna", 100m, 0.25m)
        };

        Assert.Equal(225m, Kvittoraknaren.BeraknaTotal(varor, "RABATT10"));
    }

    [Fact]
    public void RabattDrasInnanMoms_MedOlikaMomssatser()
    {
        var varor = new[]
        {
            new Vara("Bok", 100m, 0.25m),
            new Vara("Bröd", 100m, 0.12m)
        };

        Assert.Equal(213.3m, Kvittoraknaren.BeraknaTotal(varor, "RABATT10"));
    }

    [Fact]
    public void UtanRabattkod_GerOforandradTotal()
    {
        var varor = new[]
        {
            new Vara("Bok", 100m, 0.25m),
            new Vara("Penna", 100m, 0.25m)
        };

        Assert.Equal(250m, Kvittoraknaren.BeraknaTotal(varor, null));
    }

    [Fact]
    public void OkandRabattkod_KastarArgumentException()
    {
        var varor = new[]
        {
            new Vara("Bok", 100m, 0.25m)
        };

        Assert.Throws<ArgumentException>(() => Kvittoraknaren.BeraknaTotal(varor, "FEL"));
    }
}