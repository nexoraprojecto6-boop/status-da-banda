# Design do Mundo
## Hierarquia geográfica
`País → Província → Cidade → Bairro → Zona (cell de streaming) → Local (POI)`
Cada nível tem ID estável (`AO`, `AO-LUA`, `AO-LUA-LUANDA`, `AO-LUA-LUANDA-B001`).

## Expansão progressiva
1. Um bairro de Luanda (vertical slice). 2. Luanda alargada. 3. Outras cidades de Angola. 4. Maputo/Matola. 5. Restantes províncias.
Não se cria o mapa completo na Fase 1.

## Dados e licenças
Fontes candidatas: OpenStreetMap (ODbL — exige atribuição e partilha de bases derivadas; avaliar impacto), dados públicos, levantamentos próprios. Ver `ASSET-AND-LICENSE-POLICY.md`. Locais reais: preferir interpretação artística; evitar marcas e pessoas reais sem autorização.

## Streaming por zonas
Zonas de ~200–400 m carregadas via Addressables conforme proximidade; interiores como cenas/prefabs aditivos. LOD e occlusion por zona.

## Pesos de nascimento
Cada bairro tem `birth_weight` e `capacity_cap` (ver `RANDOM-BIRTH-SYSTEM.md`); só bairros ativados no mundo são elegíveis.

## Riscos
Custo de produção de conteúdo, precisão cultural, direitos de dados geográficos, tamanho de build.
