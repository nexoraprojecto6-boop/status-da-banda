# DEVELOPMENT-STATE
**Fase atual:** aceleração — fundações reais (Fases 2, 5-parcial, 6-parcial e 10-parcial em modo offline) sobre a Fase 1 aprovada.
## Concluído
- Fase 1: raiz, docs, ADRs, continuidade.
- Cliente Unity (código): Core, World, Services offline (login local + nascimento aleatório), Player (movimento + câmera 3ª pessoa), UI de toque, HUD de protótipo, construtor de cena, testes EditMode.
- Dados: `infrastructure/database/regions.json` (Angola/Luanda, Moçambique/Maputo — pesos e spawns **placeholder**), cópia em `game/Assets/Resources/Data/`.
- Backend: `backend/src/StatusDaBanda.Rules` (BirthSelector, BirthService idempotente, InMemoryLedger idempotente) + testes xUnit. CI GitHub Actions (`dotnet test`).
## Não validado (escrito sem compilar/executar, por escolha do dono)
Todo o código Unity e .NET. Primeiro passo: abrir no Unity/rodar `dotnet test` e reportar erros.
## Falta
Projeto Unity real (Hub), cena com bairro de Luanda, avatar, PlayFab/Functions (substituir serviços offline), multiplayer, chat, restante roadmap.
## Problemas conhecidos
- `.meta` serão gerados pelo Unity ao importar.
- Pacotes/versões (URP, Addressables) a fixar quando o projeto for criado.
- `BirthService.SecureRng` é simples (RandomNumberGenerator.GetInt32); rever precisão ao ligar ao backend real.
## Próxima tarefa autorizada
Corrigir erros do primeiro build/teste e avançar para a próxima fase em `NEXT-PHASE.md`.
