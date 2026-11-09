# Próxima fase: Auth real + Personagem + primeiro bairro
1. **Dono:** seguir `SETUP-UNITY.md`, rodar protótipo e `dotnet test`, reportar erros.
2. **Auth (Fase 4):** PlayFab SDK, `PlayFabAuthService : IAuthService`, Functions para `AssignBirth` usando `StatusDaBanda.Rules`. Trocar o registo em `GameBootstrap`.
3. **Personagem (Fase 5):** `CharacterAppearance` (dados), peças modulares, gravação via backend.
4. **Bairro de Luanda (Fase 7):** cena real com LOD/occlusion; spawns reais por bairro.
Critérios: login/relogin OK, origem atribuída pelo servidor e imutável, aparência persistida, 30+ FPS em Android médio.
