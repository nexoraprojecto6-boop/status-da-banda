# Otimização Mobile
- **Perfis de qualidade:** Baixo/Médio/Alto com deteção inicial e escolha manual; metas de FPS (ex.: 30 baixo, 60 alto — a medir).
- **Gráficos:** URP, LOD, occlusion culling, atlas de texturas, compressão (ASTC), limite de draw calls, sombras simples, GPU instancing.
- **Streaming:** zonas via Addressables, texturas com mipmap streaming, pooling.
- **Animação:** culling de animators distantes, LOD de esqueleto, GPU skinning onde suportado.
- **Rede:** AoI, quantização, taxa adaptativa, compressão; orçamento de dados por minuto (a definir após medição).
- **Memória/Bateria:** orçamento de memória por perfil, limitar FPS em menus, calor/thermal throttling.
- **Dispositivos de teste:** Android baixo/médio/alto e iPhones recentes/antigos.
- Sem promessa de suporte universal: tudo por medições (Profiler, Xcode Instruments, Android Studio).
