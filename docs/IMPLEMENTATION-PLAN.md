# Plano de Implementação
Cada fase: Objetivo · Tarefas · Ficheiros · Dependências · Testes · Critérios de conclusão · Entregáveis · Próxima fase. Só avançar com aprovação.

| # | Fase | Objetivo e tarefas-chave | Dep. | Testes / Conclusão | Próxima |
|---|---|---|---|---|---|
| 1 | Raiz e arquitetura | Docs, estrutura, ADRs | — | Ficheiros presentes, ZIP válido | 2 |
| 2 | Projeto Unity | Criar projeto Unity 6 LTS+URP em `game/`, assemblies, CI básico, **spike** custos/limites | 1 | Abre e compila; build Android vazio | 3 |
| 3 | Config mobile | Perfis de qualidade, Addressables base, settings Android/iOS | 2 | Build em dispositivo; FPS base medido | 4 |
| 4 | Conta/Auth | PlayFab login, perfil, ID permanente, Functions base | 3 | Login/registo/relogin OK; sem segredos no cliente | 5 |
| 5 | Personagem | Criação/personalização, gravação, avatar modular | 4 | Aparência persiste; origem não editável | 6 |
| 6 | Movimento/câmera | Terceira pessoa, animações, controlos mobile | 5 | 30+ FPS em médio; input responsivo | 7 |
| 7 | Bairro de Luanda | Cena vertical slice, LOD, occlusion | 6 | Orçamento de draw calls/memória cumprido | 8 |
| 8 | Multiplayer | Fusion, sessões por zona, AoI | 7 | 2+ clientes sincronizados; largura de banda medida | 9 |
| 9 | Identificação e chat | Nomes, chat proximidade/privado, notificações, painel | 8 | Entrega <1 s; bloquear/denunciar | 10 |
| 10 | Nascimento aleatório | Seleção ponderada no servidor, regiões/spawns | 4,8 | Testes estatísticos e idempotência | 11 |
| 11 | Interações | Objetos, edifícios, interiores | 7 | Entrar/sair sem falhas | 12 |
| 12 | Veículos/transporte | Veículos, bilhetes, rotas, viagem | 8,11,13* | Viagem validada no servidor | 13 |
| 13 | Economia/inventário | Carteira, ledger, inventário | 4 | Sem duplicação/saldo negativo | 14 |
| 14 | Vida quotidiana | Necessidades, hospital | 13 | Persistência consistente | 15 |
| 15 | Habitação | Arrendar/comprar/decorar | 13,11 | Posse validada | 16 |
| 16 | Profissões | 2–3 empregos | 13 | Salários validados | 17 |
| 17 | Relações sociais | Amigos, namoro, família, organizações | 9 | Consentimento e moderação | 18 |
| 18 | Voz | Photon Voice | 8,9 | Latência e custo medidos | 19 |
| 19 | Polícia/justiça | Atividades fictícias, prisão, multas | 16,17 | Fluxos completos com auditoria | 20 |
| 20 | Expansão do mundo | Mais bairros/cidades | 7,10 | Streaming estável | 21 |
| 21 | Moçambique | Maputo/Matola e fronteira | 20,12 | Origem/viagem MZ OK | 22 |
| 22 | Testes e lançamento | Otimização, segurança, loja | todas | Checklists aprovados | — |

\* Nota: a fase 13 (economia) é pré-requisito prático de bilhetes na fase 12; mover o núcleo da carteira para antes da 12 se necessário (ADR).
