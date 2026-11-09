# Simulação de Vida
## Necessidades
Fome, sede, energia, sono, higiene, saúde. Valores 0–100, decaimento por tempo de jogo (taxas configuráveis, lentas para não punir jogadores mobile).
## Regras
- Decaimento **calculado pelo servidor** com timestamps (também offline limitado, com teto).
- Ações: comer/beber (inventário), dormir (casa/cama), banho (casa/instalações), hospital (cura, custo).
- Efeitos: abaixo de limiares, penalização de velocidade/estamina e, no limite, desmaio → hospital (sem morte permanente).
## Ligações
Economia (custos), Habitação (descanso), Profissões (saúde/médico), Ambiente (clima afeta sede/energia).
## Riscos
Equilíbrio (frustração), exploração de offline, sobrecarga de dados.
## Conclusão (Fase 14)
Necessidades persistentes e consistentes entre sessões, configuráveis por dados.
