namespace StatusDaBanda.Rules;

public enum LedgerStatus { Applied, Duplicate, InsufficientFunds, Invalid }
public record LedgerResult(LedgerStatus Status, long Balance);
public record LedgerEntry(long Seq, string TxId, string Account, long Delta, string Reason);

/// <summary>Livro-razão em memória (referência de regras). Valores em unidades mínimas (inteiros). Idempotente por txId.</summary>
public sealed class InMemoryLedger
{
    readonly object _gate = new();
    readonly Dictionary<string, long> _balances = new();
    readonly Dictionary<string, LedgerResult> _processed = new();
    readonly List<LedgerEntry> _entries = new();

    public long Balance(string account) { lock (_gate) return _balances.GetValueOrDefault(account); }
    public IReadOnlyList<LedgerEntry> Entries() { lock (_gate) return _entries.ToList(); }

    public LedgerResult Credit(string txId, string account, long amount, string reason = "credit")
    {
        lock (_gate)
        {
            if (_processed.TryGetValue(txId, out var prev)) return prev with { Status = LedgerStatus.Duplicate };
            if (amount <= 0 || string.IsNullOrWhiteSpace(account)) return new(LedgerStatus.Invalid, Balance(account));
            return Commit(txId, new LedgerResult(LedgerStatus.Applied, 0), (account, amount, reason));
        }
    }

    public LedgerResult Debit(string txId, string account, long amount, string reason = "debit")
    {
        lock (_gate)
        {
            if (_processed.TryGetValue(txId, out var prev)) return prev with { Status = LedgerStatus.Duplicate };
            if (amount <= 0 || string.IsNullOrWhiteSpace(account)) return new(LedgerStatus.Invalid, Balance(account));
            if (Balance(account) < amount) return new(LedgerStatus.InsufficientFunds, Balance(account));
            return Commit(txId, new LedgerResult(LedgerStatus.Applied, 0), (account, -amount, reason));
        }
    }

    public LedgerResult Transfer(string txId, string from, string to, long amount)
    {
        lock (_gate)
        {
            if (_processed.TryGetValue(txId, out var prev)) return prev with { Status = LedgerStatus.Duplicate };
            if (amount <= 0 || from == to || string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                return new(LedgerStatus.Invalid, Balance(from));
            if (Balance(from) < amount) return new(LedgerStatus.InsufficientFunds, Balance(from));
            return Commit(txId, new LedgerResult(LedgerStatus.Applied, 0), (from, -amount, "transfer-out"), (to, amount, "transfer-in"));
        }
    }

    // Chamado sempre dentro do lock.
    LedgerResult Commit(string txId, LedgerResult _, params (string Account, long Delta, string Reason)[] legs)
    {
        foreach (var (account, delta, reason) in legs)
        {
            _balances[account] = _balances.GetValueOrDefault(account) + delta;
            _entries.Add(new LedgerEntry(_entries.Count + 1, txId, account, delta, reason));
        }
        var result = new LedgerResult(LedgerStatus.Applied, _balances[legs[0].Account]);
        _processed[txId] = result;
        return result;
    }
}
