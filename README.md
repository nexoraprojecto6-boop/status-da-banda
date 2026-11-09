# STATUS DA BANDA

Jogo open world, multiplayer, roleplay e simulador de vida/social para **Android e iOS**, com identidade original inspirada em Angola e Moçambique.

> **Estado:** Fase 1 concluída (raiz, documentação e arquitetura). **Ainda não existe projeto Unity funcional** — será inicializado na Fase 2.

## Estrutura
| Pasta | Conteúdo |
|---|---|
| `game/` | Cliente Unity (estrutura preparada; projeto por inicializar) |
| `backend/` | Lógica de servidor (Azure Functions/PlayFab CloudScript — Fase 4+) |
| `infrastructure/` | Ambientes, base de dados, deploy, monitorização, segurança |
| `docs/` | Documentação técnica e de design (fonte oficial do projeto) |
| `tools/`, `tests/` | Utilitários e testes |

## Por onde começar
1. `docs/AI-CONTEXT.md` — contexto completo do projeto.
2. `docs/DEVELOPMENT-STATE.md` — onde estamos.
3. `docs/NEXT-PHASE.md` — próxima fase.
4. `docs/CLAUDE-INSTRUCTIONS.md` — regras de trabalho com o Claude.

## Como publicar no GitHub
```bash
unzip status-da-banda-phase-01.zip && cd status-da-banda
git init && git add . && git commit -m "Fase 1: raiz, docs e arquitetura"
git branch -M main
git remote add origin https://github.com/<utilizador>/status-da-banda.git
git push -u origin main
```
Nunca submeter credenciais: usar `.env` local (ignorado pelo Git) com base em `.env.example`.

## Licença
Código: ver `LICENSE` (proprietário, a rever). Assets: ver `docs/ASSET-AND-LICENSE-POLICY.md`.
