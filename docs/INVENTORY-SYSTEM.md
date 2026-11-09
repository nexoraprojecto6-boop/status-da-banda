# Inventário
- Itens definidos por **catálogo** (ID, tipo, empilhável, peso/slots, valor base).
- Instâncias de item pertencem a uma entidade (jogador, casa, veículo, loja) — a posse é validada no servidor.
- Operações: adicionar, remover, mover, usar, trocar, vender — sempre via backend com verificação de capacidade e propriedade.
- Trocas entre jogadores: handshake com confirmação dupla e transação atómica.
- UI mobile: grelha com arrastar/tocar, filtros, indicadores de peso.
- Risco: duplicação por concorrência → versionamento otimista (`etag`/`version`).
- Conclusão (Fase 13): operações idempotentes e testadas; inventário consistente após reconexões.
