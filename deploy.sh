#!/bin/bash
set -e

echo "🔨 Building backend..."
dotnet publish AlblueMES.API/AlblueMES.API.csproj -c Release -o ./publish

echo "📦 Uploading to server..."
rsync -az --delete --exclude='appsettings.Production.json' --exclude='uploads/' ./publish/ root@46.101.166.137:/opt/alblue/api/

echo "🔄 Restarting API..."
ssh root@46.101.166.137 "systemctl restart alblue-api"

echo "✅ Backend deployed!"
