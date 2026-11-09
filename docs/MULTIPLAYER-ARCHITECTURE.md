# Arquitetura Multiplayer
```mermaid
sequenceDiagram
  participant C as Cliente
  participant PF as PlayFab
  participant FN as Functions
  participant FU as Fusion (sessão)
  C->>PF: Login
  PF-->>C: Sessão/Ticket
  C->>FN: Pedir entrada na zona (ticket)
  FN->>PF: Validar jogador/estado
  FN-->>C: Token de sessão + região/zona
  C->>FU: Ligar à sessão da zona
  FU->>FN: Validar token
  loop Gameplay
    C->>FU: Input/intenção
    FU-->>C: Estado replicado (interesse por proximidade)
  end
  FU->>FN: Eventos persistentes (ex.: compra)
  FN->>PF: Gravar
```
## Decisões
- **Sessão por zona/instância** (shard), com limite inicial pequeno e testes progressivos.
- **Area of Interest:** replicar apenas jogadores/objetos próximos; taxa de atualização adaptativa.
- **Modo:** servidor autoritativo (Fusion Server/dedicado) para economia e combate; Shared mode só se justificado em ADR.
- **Reconexão:** estado de personagem recuperado do backend.
- **Dados móveis:** compressão, quantização de posições, delta updates.

## Riscos
CCU e custos, anti-batota em modo partilhado, sincronização de veículos, latência regional.
## Critérios de conclusão (Fase 8)
2+ clientes em Android/iOS reais na mesma zona, movimento sincronizado, medições de largura de banda registadas.
