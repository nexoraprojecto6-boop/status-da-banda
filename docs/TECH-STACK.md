# Stack Tecnológica (proposta — a validar na Fase 2)
| Área | Escolha | Justificação | Riscos / Alternativas |
|---|---|---|---|
| Motor | Unity 6 LTS (confirmar versão LTS vigente) | Mobile maduro, URP, ecossistema | Licença/custos Unity; alternativa: Unreal (pesado em mobile baixo) |
| Linguagem | C# | Nativa Unity | — |
| Render | URP | Perfil mobile | Menos recursos que HDRP (ok) |
| 3D | Blender | Gratuito, pipeline FBX/glTF | — |
| Conteúdo | Addressables | Streaming/zonas, builds leves | Complexidade de configuração |
| Multiplayer | Photon Fusion 2 (modo Server/Host a avaliar) | Netcode integrado Unity, lag compensation | Custo por CCU; lock-in; alternativas: Netcode for GameObjects, Mirror, servidor próprio |
| Voz | Photon Voice 2 | Integra com Fusion | Custo por CCU; alternativa: Vivox/Agora |
| Backend | PlayFab (auth, dados, economia) + Azure Functions | Auth/anónimo/social login, Economy v2, CloudScript | Limites de API/tamanho de dados; custo; lock-in Azure |
| Versionamento | Git + GitHub + Git LFS | Padrão | Repositório grande: LFS obrigatório para binários |

## Quem é responsável por quê
- **Autenticação:** PlayFab Login (conta própria + provedores sociais).
- **Dados persistentes:** PlayFab (Entity/Data/Economy). Uma única fonte de verdade; sem base de dados paralela na fase inicial.
- **Sessões multiplayer:** Photon Fusion (servidor autoritativo).
- **Validação económica/inventário/propriedades:** Azure Functions/CloudScript com PlayFab.
- **Movimento/ações:** servidor de sessão Fusion valida.
- **Comunicação:** cliente → Fusion (tempo real) e cliente → PlayFab/Functions (HTTPS); servidor de sessão → backend via API autenticada.

## Critério de aceitação da stack (spike na Fase 2–4)
Custos por 100/1k CCU estimados, limites verificados, protótipo de login + sessão com 2 clientes.
