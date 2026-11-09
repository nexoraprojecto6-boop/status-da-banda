# Economia e Banca
## Moedas
Kwanza (Kz) em Angola, Metical (MT) em Moçambique, como moedas virtuais por região. Câmbio interno regulado pelo servidor (se/quando existir).
## Princípios
- Servidor autoritativo; cliente só pede.
- Transações **atómicas e idempotentes** (`transaction_id`), com livro-razão (ledger) imutável.
- Sem dinheiro real nesta fase (sem compra/venda por moeda real) — qualquer monetização exige ADR e revisão legal.
## Componentes
Carteira, conta bancária virtual (depósito/levantamento/transferência), salários, lojas (NPC e jogador), mercado, poupança, negócios, impostos simulados (opcional).
## Anti-exploração
Limites por tempo, deteção de padrões, auditoria, rollback por ledger, monitorização de inflação (sinks e faucets balanceados).
## Dados
`wallets`, `ledger_entries`, `accounts`, `transactions` — ver `DATABASE-DESIGN.md`.
## Riscos
Inflação, duplicação, colusão entre jogadores, limites de API do backend.
## Conclusão (Fase 13)
Testes provam: sem saldo negativo, sem duplicação com retries, ledger reconcilia saldo.
