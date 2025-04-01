# Simulado Técnico - Localiza&Co (.NET 8 + SQLite + Swagger)

Este é um projeto base para testes técnicos com foco em API RESTful usando .NET 8, SQLite e documentação Swagger.

## Tecnologias

- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core (SQLite)
- Swagger
- Docker (opcional)

## Executando o projeto

### Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) (opcional)

### Rodando localmente

```bash
dotnet restore
dotnet build
dotnet run
```

Acesse a API via: `http://localhost:5000/swagger`

### Rodando com Docker

```bash
docker build -t simulado-api .
docker run -p 5000:5000 simulado-api
```

### Usando docker-compose

```bash
docker-compose up --build
```

## Endpoints

- `GET /pessoas`
- `GET /pessoas/{id}`
- `POST /pessoas`
- `PUT /pessoas/{id}`
- `DELETE /pessoas/{id}`

## Estrutura da API

CRUD simples com SQLite e documentação automática via Swagger.

Ideal para simular desafios técnicos de curta duração (30 minutos).