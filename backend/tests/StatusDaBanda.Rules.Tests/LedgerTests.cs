using StatusDaBanda.Rules;
using Xunit;

namespace StatusDaBanda.Rules.Tests;

public class LedgerTests
{
    [Fact]
    public void Debito_SemSaldo_Falha()
    {
        var l = new InMemoryLedger();
        Assert.Equal(LedgerStatus.InsufficientFunds, l.Debit("t1", "a", 10).Status);
        Assert.Equal(0, l.Balance("a"));
    }

    [Fact]
    public void TransacaoRepetida_NaoDuplica()
    {
        var l = new InMemoryLedger();
        l.Credit("t1", "a", 100);
        Assert.Equal(LedgerStatus.Duplicate, l.Credit("t1", "a", 100).Status);
        Assert.Equal(100, l.Balance("a"));
    }

    [Fact]
    public void Transferencia_EAtomica()
    {
        var l = new InMemoryLedger();
        l.Credit("t1", "a", 100);
        Assert.Equal(LedgerStatus.Applied, l.Transfer("t2", "a", "b", 60).Status);
        Assert.Equal(LedgerStatus.InsufficientFunds, l.Transfer("t3", "a", "b", 60).Status);
        Assert.Equal(40, l.Balance("a"));
        Assert.Equal(60, l.Balance("b"));
    }

    [Fact]
    public void ValoresInvalidos_Rejeitados()
    {
        var l = new InMemoryLedger();
        Assert.Equal(LedgerStatus.Invalid, l.Credit("t1", "a", 0).Status);
        Assert.Equal(LedgerStatus.Invalid, l.Credit("t2", "a", -5).Status);
        Assert.Equal(LedgerStatus.Invalid, l.Transfer("t3", "a", "a", 1).Status);
    }

    [Fact]
    public void Concorrencia_SomaCorreta_ELedgerReconcilia()
    {
        var l = new InMemoryLedger();
        Parallel.For(0, 1000, i => l.Credit($"t{i}", "a", 10));
        Assert.Equal(10000, l.Balance("a"));
        Assert.Equal(l.Balance("a"), l.Entries().Where(e => e.Account == "a").Sum(e => e.Delta));
    }
}
