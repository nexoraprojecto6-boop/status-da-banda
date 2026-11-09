# Changelog
Formato: [Keep a Changelog](https://keepachangelog.com/pt-PT/1.1.0/).

## [0.1.0] - Fase 1
### Adicionado
- Estrutura raiz do repositório, documentação completa de arquitetura e design.
- ADRs 0001–0005 (propostos).
- Documentos de continuidade para Claude (AI-CONTEXT, DEVELOPMENT-STATE, IMPLEMENTATION-PLAN, CLAUDE-INSTRUCTIONS, NEXT-PHASE).

## [0.2.0] - Fundações de código
### Adicionado
- Cliente Unity: assemblies SDB.* (Core, World, Services, Player, UI, Demo, Editor), testes EditMode, construtor de cena protótipo.
- Backend `StatusDaBanda.Rules` (nascimento aleatório, ledger idempotente) + testes xUnit + CI.
- Seed `regions.json`, `tools/sync-regions.sh`, `docs/SETUP-UNITY.md`.
