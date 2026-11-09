# AI-CONTEXT — STATUS DA BANDA
Ler este ficheiro no início de qualquer nova conversa.
## O que é
Jogo open world multiplayer, roleplay e simulador de vida/social para Android e iOS, inspirado em Angola e Moçambique. Identidade original (não copiar GTA ou outras IPs). Estilo: mobile-first, servidor autoritativo, desenvolvimento por fases.
## Regras centrais do design
- O jogador escolhe **só o país** (Angola ou Moçambique). O servidor atribui província, cidade, bairro e spawn de forma aleatória e equilibrada. Origem **permanente**.
- Mudar de residência = viajar no mundo (bilhete, dinheiro virtual, terminal, horário, fronteira em viagens internacionais).
- Economia, inventários, compras, propriedades e ações importantes validados no servidor.
- Moedas: Kwanza (Kz) e Metical (MT).
- Política/crime são simulação fictícia, claramente separada de eventos reais.
- Mensagens: notificação no topo + painel lateral minimizável, sem bloquear controlos.
## Stack proposta (a validar por spikes)
Unity 6 LTS, C#, URP, Blender, Addressables, Photon Fusion + Voice, PlayFab (+ Azure Functions), Git/GitHub (+LFS). Ver `TECH-STACK.md` e ADRs.
## Estrutura do repositório
`game/` (Unity, por inicializar) · `backend/` · `infrastructure/` · `docs/` · `tools/` · `tests/`.
## Regras de trabalho
Ver `CLAUDE-INSTRUCTIONS.md`. Fase atual e próxima tarefa: `DEVELOPMENT-STATE.md` e `NEXT-PHASE.md`.
## Preferências do dono do projeto
Comunica em português europeu; quer respostas económicas em tokens; não testar nada pesado no ambiente do Claude; entregar código em ZIP para enviar para o GitHub; não iniciar fases sem aprovação.
