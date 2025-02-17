# ProtocolSystem

Este projeto é um sistema básico de **cadastro e gerenciamento de protocolos**, desenvolvido utilizando **.NET Core 8**, **SQL Server**, **MVC** e **Entity Framework Core**.

- Para melhor entendimento, por favor leia todo este documento.

## 📌 Funcionalidades
- **Cadastro de Clientes**
- **Cadastro de Protocolos**
- **Cadastro de Status de Protocolo**
- **Acompanhamento de Protocolos**
- **Autenticação Básica**
- **Listagem de protocolos com paginação e ordenação**
- **Busca por título ou cliente**

## 🛠️ Tecnologias Utilizadas
- **.NET Core 8**
- **Entity Framework Core** (EF Core)
- **SQL Server**
- **MVC (Model-View-Controller)**
- **HTML, CSS**

## 🚀 Como Executar o Projeto Localmente

### 1️⃣ **Pré-requisitos**
Certifique-se de ter instalado:
- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### 2️⃣ **Configurar o Banco de Dados**
1. No SQL Server, crie um banco de dados chamado **CadastroProtocolos**;
2. Altere a string de conexão no `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=ProtocolSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

3. Abra o terminal e rode os seguintes comandos para criar as tabelas:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3️⃣ **Rodando o Projeto**
No terminal, dentro da pasta do projeto, execute:
```sh
dotnet run
```
O projeto será iniciado e estará disponível em:
```
http://localhost:5179/
```

### 4️⃣ **Login no Sistema**
O sistema possui autenticação básica. Para testar, use:
```
Usuário: admin
Senha: 123
```

## 🔥 Funcionalidades Extras implementadas
- **Paginação e ordenação na listagem de protocolos**: Implementada usando `skip()` e `take()`.
- **Busca por título ou cliente**: Implementada com filtros na query do EF Core.
- **Proteção do sistema com autenticação**.

## 📋 Gerenciamento com Trello

Para organizar as tarefas do projeto, utilizei o Trello seguindo o modelo Kanban. As tarefas são divididas nas seguintes colunas:

- Backlog → Lista de tarefas a serem feitas
- A fazer → Tarefas priorizadas aguardando para iniciar
- Em andamento → Tarefas sendo desenvolvidas
- Concluído → Tarefas finalizadas

Também foi adicionado etiquetas coloridas nos cards, separando em:
- Configuração: Azul
- Banco de dados: Laranja
- Backend: Roxo
- Frontend: Verde
- Extra: Amarelo

🔗 Link do Trello: [ProtocolSytem: Kanban](https://trello.com/invite/b/67af52d5ad7a821c233a5bca/ATTI398aa1be5e7330720fae43806322c4329BA3A313/kanban-protocolsystem)

## ⚠️ Dificuldades Encontradas
Durante o desenvolvimento, houve dificuldades para fazer a criação de protocolo e acompanhamento de protocolo funcionar corretamente. O problema não foi identificado, mas houve grande empenho na tentativa de solução.


