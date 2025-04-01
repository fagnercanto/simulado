@echo off
cd ..
SET MSG=%1
IF "%MSG%"=="" SET MSG=update

echo Inicializando Git e enviando para o GitHub...
git init
git add .
git commit -m "%MSG%"
IF NOT EXIST ".git\refs\remotes\origin" (
    echo Repositorio remoto ainda não configurado.
    echo Use: git remote add origin https://github.com/fagnercanto/simulado.git
    echo Depois: git push -u origin main
) ELSE (
    git push -u origin main
)