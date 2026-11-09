#!/usr/bin/env sh
# Copia a fonte de dados (infrastructure) para o Resources do Unity.
set -e
cd "$(dirname "$0")/.."
cp infrastructure/database/regions.json game/Assets/Resources/Data/regions.json
echo "regions.json sincronizado"
