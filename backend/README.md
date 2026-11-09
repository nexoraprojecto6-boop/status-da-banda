# backend/
- `src/StatusDaBanda.Rules` — regras autoritativas puras (.NET 8, sem dependências): nascimento aleatório, ledger idempotente. Serão chamadas por Azure Functions/PlayFab (ADR-0002).
- `tests/StatusDaBanda.Rules.Tests` — xUnit. Correr: `dotnet test backend/tests/StatusDaBanda.Rules.Tests`.
Sem segredos no repositório.
