@echo off
:: Script de push Git com token automático (com config e branch main)
cd ..

SET REPO_URL=https://github.com/fagnercanto/simulado.git
SET TOKEN=

IF "%1"=="" (
    SET MSG=update
) ELSE (
    SET MSG=%1
)

:: Configura nome e email se ainda não estiverem setados
git config user.name >nul 2>&1
IF ERRORLEVEL 1 (
    git config --global user.name "Fagner Canto"
)
git config user.email >nul 2>&1
IF ERRORLEVEL 1 (
    git config --global user.email "fagnercantosantos@gmail.com"
)

:: Inicia e faz push
git init
git add .
git commit -m "%MSG%"
git branch -M main
git remote remove origin 2>nul
git remote add origin https://%TOKEN%@github.com/fagnercanto/simulado.git
git push -u origin main