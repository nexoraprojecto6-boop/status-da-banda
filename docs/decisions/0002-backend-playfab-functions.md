# ADR-0002: PlayFab + Azure Functions como backend de registo
**Estado:** Proposto. **Contexto:** evitar duplicar bases de dados e serviços. **Decisão:** PlayFab como fonte única de auth/dados/economia; Functions para regras autoritativas. **Consequências:** rapidez de arranque; lock-in e limites de API a validar por spike (Fases 2–4). **Alternativas:** backend próprio + PostgreSQL, Nakama.
