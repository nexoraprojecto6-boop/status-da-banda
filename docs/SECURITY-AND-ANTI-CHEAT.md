# Segurança e Anti-Batota
## Modelo
Nunca confiar no cliente. Validar no servidor: economia, inventário, propriedades, movimento (velocidade/teleporte), ações importantes.
## Controlos
- Autenticação com tokens curtos; rate limiting; idempotência.
- Segredos só em cofre/variáveis de ambiente do servidor (nunca no cliente/repo).
- Validação de integridade da build (Play Integrity / App Attest) — Fase posterior.
- Deteção: speed-hack, teleporte, duplicação, anomalias económicas; sanções graduais.
- Auditoria: ledger imutável, logs estruturados, alertas.
- Privacidade: minimização de dados, retenção, direitos do utilizador (RGPD/lei angolana de proteção de dados — rever com assessoria jurídica).
## Ameaças principais
Modificação de cliente, replay de pedidos, bots, abuso de chat, fuga de chaves, DDoS.
## Conclusão
Checklist em `infrastructure/security/` por fase; testes de abuso antes de cada lançamento.
