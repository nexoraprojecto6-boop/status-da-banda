# game/ — Cliente Unity
**Estado:** estrutura preparada; **projeto Unity ainda não inicializado** (Fase 2).
Na Fase 2 será criado o projeto com Unity 6 LTS (versão confirmada nessa altura) e URP, com `Packages/manifest.json` e `ProjectSettings/` reais, gerados pelo Unity Editor. Os ficheiros `.meta` serão gerados pelo Unity e commitados.

Organização planeada de `Assets/Scripts/`: `Core/`, `Net/`, `Player/`, `World/`, `UI/`, `Services/`, usando Assembly Definitions por módulo.
Regra: o cliente **nunca** é autoridade sobre economia, inventário ou propriedades.
