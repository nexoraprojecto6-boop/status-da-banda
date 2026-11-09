# Desenho de Dados (conceptual)
Fonte única inicial: PlayFab (Entity Objects/Files, Economy v2). Se limites forem insuficientes, ADR para base de dados dedicada (ex.: PostgreSQL) com migração planeada.
## Entidades principais
`players`, `characters`, `origins`, `regions (país/província/cidade/bairro)`, `spawn_points`, `wallets`, `ledger_entries`, `items`, `item_instances`, `properties`, `vehicles`, `jobs`, `relationships`, `organizations`, `routes`, `tickets`, `moderation_reports`.
## Regras
IDs estáveis (UUID/ULID), `version` para concorrência otimista, `created_at/updated_at`, soft delete quando aplicável, ledger append-only.
## Dados estáticos
Catálogos (itens, profissões, rotas, regiões) em ficheiros versionados no repositório (`infrastructure/database/`) e publicados por pipeline.
## Riscos
Limites de tamanho de objetos, consultas complexas no PlayFab, migrações.
