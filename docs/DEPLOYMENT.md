# Deploy
- **Ambientes:** dev → staging → prod; configuração por ambiente em `infrastructure/environments/` sem segredos.
- **Cliente:** builds Android (AAB) e iOS (IPA via Xcode/Fastlane); CI com GitHub Actions + Unity builder (avaliar licenciamento e custos).
- **Backend:** deploy de Functions por pipeline; infra como código (Bicep/Terraform — ADR futuro).
- **Conteúdo:** Addressables publicados em CDN, versionados por catálogo.
- **Distribuição:** testes internos (Play Console/TestFlight) antes de aberto.
- **Segredos:** GitHub Secrets/Key Vault.
- **Monitorização:** logs, métricas de sessão, crash reporting.
