@echo off
echo Executando projeto .NET...
cd ..
dotnet restore
dotnet build
dotnet run