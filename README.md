# ProtocolSystem

Este projeto é um sistema básico de **cadastro e gerenciamento de protocolos**, desenvolvido utilizando **.NET Core 8**, **SQL Server**, **MVC** e **Entity Framework Core**.

## 📌 Funcionalidades
- **Cadastro de Clientes** (Nome, E-mail, Telefone, Endereço);
- **Cadastro de Protocolos** (Título, Descrição, Data de Abertura/Fechamento, Status e Cliente relacionado);
- **Cadastro de Status de Protocolo** (Aberto, Em andamento, Fechado);
- **Acompanhamento de Protocolos** (Registro de ações realizadas em um protocolo);
- **Autenticação Básica** (Proteção de todas as páginas);
- **Listagem de protocolos com paginação e ordenação** (Opcional);
- **Busca por título ou cliente** (Opcional).

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

## ⚠️ Dificuldades Encontradas
Durante o desenvolvimento, houve dificuldades para fazer a criação de protocolo e acompanhamento de protocolo funcionar corretamente. O problema não foi identificado, mas houve grande empenho na tentativa de solução.
