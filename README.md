# Sistema de Gerenciamento de Clientes (CRUD)

Este projeto consiste em uma API RESTful desenvolvida em C# ASP.NET Core 8.0 e um frontend em AngularJS, com banco de dados SQL Server. O sistema permite realizar operações de CRUD (Create, Read, Update, Delete) em clientes, além de autenticação de usuários via JWT.

## 📋 Pré-requisitos

- SQL Server 2019+ ([Download aqui](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads))
- .NET 8.0 SDK ([Download aqui](https://dotnet.microsoft.com/download))
- Node.js (para executar o servidor frontend) ([Download aqui](https://nodejs.org/))
- Visual Studio 2022 (para o backend) ([Download aqui](https://visualstudio.microsoft.com/pt-br/downloads/))


## 🚀 Como Executar o Projeto

### Backend (API .NET Core)
1. Restaurar o Banco de Dados:
   - Execute o script `ScriptCriacaoAmbiente.sql` (disponível no repositório) no SQL Server Management Studio (SSMS) ou em outra ferramenta de gerenciamento de banco de dados.
   - Atualize a `connection string` no arquivo `appsettings.json` do projeto para apontar para seu SQL Server.

2. Executar a API:
   - Abra o arquivo `VeracidataApi.sln` no Visual Studio.
   - Pressione `F5` para compilar e executar a API.
   - A API estará disponível em `https://localhost:7205` (ou outra porta configurada).

### Frontend (AngularJS)
1. Instalar o http-server (caso não tenha):
   - bash: "npm install -g http-server"
   - Executar o Frontend:
   - Navegue até a pasta do frontend via terminal.
   - Execute:
   - bash: "http-server -o"
   - O frontend estará disponível em http://localhost:8080.

## 🛠 Como Usar
API (Endpoints Principais)
Método	Endpoint		Descrição			Autenticação Requerida
POST	/api/auth/login		Login (gera token JWT)		Não
POST	/api/auth/register	Registrar novo usuário		Não
GET	/api/customers		Listar todos os clientes	Sim
POST	/api/customers		Criar novo cliente		Sim
PUT	/api/customers/{id}	Atualizar cliente		Sim
DELETE	/api/customers/{id}	Excluir cliente (lógico)	Sim


### Exemplo de Requisição (Login):
bash
curl -X POST "https://localhost:7205/api/auth/login" \
-H "Content-Type: application/json" \
-d '{"email": "root@root.com", "password": "1234567890"}'

### Frontend
Login: Acesse http://localhost:8080/login e use as credenciais:
Email: root@root.com
Senha: 1234567890

### Funcionalidades:
Listagem de Clientes: Visualize todos os clientes cadastrados.
Criação/Edição: Formulários com validação para adicionar ou editar clientes.
Exclusão Lógica: Clientes marcados como Inactive não aparecem na listagem.

## 🔧 Decisões Técnicas

### Backend (C# ASP.NET Core 8.0)
Arquitetura:
DDD (Domain-Driven Design): Separação em camadas (Domain, Application, Infrastructure).
SOLID e Clean Code: Services com responsabilidades únicas e injeção de dependência.
Autenticação: JWT (JSON Web Tokens) para segurança dos endpoints.

### Frontend (AngularJS)
Simplicidade: Uso de controllers e services para separação de lógica.
Roteamento: angular-route para navegação entre páginas.
Autenticação: Token JWT armazenado no localStorage.

### Banco de Dados (SQL Server)
Modelagem: Tabela Customers com campos como Email (único) e Active (controle lógico).
Performance: Índices em campos de busca frequente (e.g., Email).

## 📁 Estrutura do Projeto
backend/
├── VeracidataApi.Domain/     		# Entidades, interfaces e regras de negócio
├── VeracidataApi.Application 		# Casos de uso, serviços e DTOs
├── VeracidataApi.Infrastructure 	# EF Core, repositórios, autenticação
└── VeracidataApi.API/        		# Controllers, middlewares e configurações

frontend/
├── app/                      		# Controllers, services e views
├── assets/                   		# Imagens e estilos
└── index.html                		# Página principal
