# Setup do projeto Unity
1. No Unity Hub: instalar **Unity 6 LTS** (versão LTS atual) com módulos Android e iOS.
2. Criar projeto **Universal 3D (URP)** numa pasta temporária (ex.: `status-da-banda-tmp`).
3. Copiar para o repositório: `ProjectSettings/` e `Packages/manifest.json` + `packages-lock.json` do projeto temporário para `game/` (substituem os `.gitkeep`).
4. A pasta `game/Assets/` deste repositório já tem o código; abrir `game/` no Unity Hub (Add project from disk).
5. Se a Unity avisar sobre Input System: manter. O código funciona com Input antigo (teclado WASD no editor) e novo (joystick de toque).
6. Menu **STATUS DA BANDA > Criar cena protótipo** → gera `Assets/Scenes/Prototype.unity`. Carregar Play.
7. Testes: Window > General > Test Runner > EditMode.
8. Build Android: File > Build Profiles > Android; Scripting Backend IL2CPP, ARM64.
9. Project Settings > Editor: Asset Serialization = Force Text; Version Control = Visible Meta Files.
10. Pacotes a adicionar mais tarde (Fase 3+): Addressables; Photon Fusion/Voice e PlayFab SDK só quando a respetiva fase for autorizada.

Se algum erro de compilação aparecer, enviar a mensagem completa para correção.
