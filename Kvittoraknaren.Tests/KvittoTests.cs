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
}