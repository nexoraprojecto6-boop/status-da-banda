# Próxima fase: FASE 2 — Inicialização funcional do projeto Unity
**Só começar após aprovação explícita da Fase 1.**
## Objetivos
Projeto Unity válido em `game/` com URP, estrutura de Assembly Definitions e build Android de teste; spike de custos/limites da stack.
## Tarefas
1. Confirmar versão Unity 6 LTS suportada à data.
2. Criar projeto no Unity Hub dentro de `game/` (o dono executa; Unity gera `Packages/`, `ProjectSettings/`, `.meta`).
3. Configurar URP, Linear color space, IL2CPP/ARM64, Force Text, Visible Meta Files.
4. Claude fornece: scripts base (`Core/`), asmdefs, cena `Bootstrap`, workflow GitHub Actions (opcional), `ASSET-REGISTER.md`.
5. Spike (documento): custos e limites Photon/PlayFab; atualizar ADRs.
## Critérios de conclusão
Projeto abre sem erros; build Android vazio instala e abre; ADRs atualizados; docs de continuidade atualizados.
## Entregável
`status-da-banda-phase-02.zip` (ficheiros de código/documentação a juntar ao projeto).
