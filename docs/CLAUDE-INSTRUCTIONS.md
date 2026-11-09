# Instruções para o Claude neste repositório
1. **Ler primeiro:** `AI-CONTEXT.md`, `DEVELOPMENT-STATE.md`, `NEXT-PHASE.md` e a documentação do módulo a tocar.
2. Respeitar decisões anteriores (ADRs). Não alterar tecnologias sem ADR e justificação.
3. Não apagar funcionalidades existentes nem substituir código sem necessidade.
4. Trabalhar **só** no escopo da fase autorizada; não iniciar a fase seguinte sem aprovação.
5. Verificar dependências antes de alterar módulos concluídos; preservar compatibilidade.
6. Servidor autoritativo: nunca implementar lógica de economia/inventário/propriedades só no cliente.
7. Sem credenciais no repositório; usar `.env.example`.
8. Escrever o código com cuidado e validar leve (sintaxe, estrutura). **Não executar testes pesados no ambiente do Claude**; testes reais correm no PC/CI do dono.
9. Poupar tokens: respostas concisas, sem repetir documentação.
10. No fim de cada fase atualizar `DEVELOPMENT-STATE`, `NEXT-PHASE`, `IMPLEMENTATION-PLAN`, `CHANGELOG` e entregar ZIP `status-da-banda-phase-NN.zip`.
11. Responder em português europeu.
12. Não afirmar capacidades (dispositivos, nº de jogadores) sem medições.
