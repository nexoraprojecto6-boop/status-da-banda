# game/ — Cliente Unity
**Estado:** código base pronto (Core, World, Services offline, Player, UI, Demo, Editor, testes). O projeto Unity em si (`ProjectSettings/`, `Packages/manifest.json`) é gerado pelo Unity Hub — ver `docs/SETUP-UNITY.md`.

## Assemblies (`Assets/Scripts`)
| Assembly | Conteúdo |
|---|---|
| `SDB.Core` | ServiceLocator, Result, IMoveInput/TouchInput, CryptoRng |
| `SDB.World` | Modelos de regiões, BirthSelector |
| `SDB.Services` | IAuthService/IBirthService, implementações offline, GameBootstrap (composition root) |
| `SDB.Player` | PlayerController (terceira pessoa), ThirdPersonCamera |
| `SDB.UI` | VirtualJoystick, LookPad |
| `SDB.Demo` | BirthDemoHud (protótipo) |
| `SDB.Editor` | Menu **STATUS DA BANDA > Criar cena protótipo** |

Regra: o cliente nunca é autoridade sobre economia, inventário ou propriedades. Os serviços *Offline* só existem para desenvolvimento; serão trocados por PlayFab/Functions em `GameBootstrap`.
