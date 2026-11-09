# Estratégia de Testes
- **Unitários:** C# (Unity Test Framework EditMode) para regras locais; backend com testes automatizados.
- **Integração:** login → sessão → ação validada; economia com cenários de concorrência/retry.
- **Playmode:** cenas essenciais.
- **Performance:** perfis por dispositivo, FPS, memória, bateria, dados/minuto.
- **Carga:** instâncias pequenas → aumento gradual; só afirmar capacidade com medições.
- **Segurança:** testes de abuso (replay, duplicação, speed-hack).
- **Distribuição estatística:** nascimento aleatório.
- **Dispositivos reais:** matriz Android baixo/médio/alto + iOS.
- **Critério de saída por fase:** testes definidos na fase passam e estão documentados.
