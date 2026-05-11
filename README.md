# Gerenciador de Endereços - Processo Seletivo AEC

Este projeto é uma aplicação web desenvolvida em ASP.NET Core 9.0 MVC para gerenciamento de endereços. O sistema permite autenticação de usuários, gerenciamento completo de endereços, integração com a API ViaCEP e exportação dos dados para CSV.

A aplicação foi construída com foco em organização, usabilidade, arquitetura MVC e facilidade de execução.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 9.0 MVC
- Entity Framework Core
- SQLite
- Bootstrap 5
- JavaScript (Fetch API)
- API ViaCEP

---

## 🛠️ Funcionalidades

### ✅ Tela de Login

- Autenticação de usuário
- Validação de credenciais
- Controle de acesso
- Redirecionamento após login bem-sucedido

### ✅ CRUD de Endereços

A aplicação permite:

- Adicionar endereços
- Visualizar endereços
- Editar endereços
- Excluir endereços

Todas as operações são realizadas utilizando modais Bootstrap sem recarregamento de página.

### ✅ Integração ViaCEP

O sistema realiza consulta automática de CEP utilizando a API:

```txt
https://viacep.com.br/
```

Ao informar um CEP válido, os seguintes campos são preenchidos automaticamente:

- Logradouro
- Bairro
- Cidade
- UF

### ✅ Exportação CSV

Os endereços cadastrados podem ser exportados para arquivo CSV.

O arquivo é gerado com suporte a BOM (Byte Order Mark), garantindo compatibilidade correta de acentuação no Microsoft Excel.

### ✅ Seed Automática

Na primeira execução da aplicação:

- O banco SQLite é criado automaticamente
- Um usuário mockado é inserido automaticamente

---

## 📦 Como Executar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/SEU_USUARIO/NOME_DO_REPOSITORIO.git
cd NOME_DO_REPOSITORIO
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Execute a aplicação

```bash
dotnet run
```

### 4. Acesse no navegador

```txt
http://localhost:5000
```

ou

```txt
https://localhost:5001
```

---

## 🔐 Credenciais de Acesso

| Campo | Valor |
|---|---|
| Usuário | testeAec |
| Senha | aec |

---

## 🗄️ Banco de Dados

O projeto utiliza SQLite para facilitar a execução e garantir portabilidade sem necessidade de configuração externa.

O banco é criado automaticamente através do método:

```csharp
context.Database.EnsureCreated();
```

Arquivo gerado automaticamente:

```txt
GerenciadorEnderecos.db
```

---

## 📂 Estrutura das Tabelas

### Usuarios

| Campo | Tipo |
|---|---|
| Id | INTEGER |
| Nome | TEXT |
| Usuario | TEXT |
| Senha | TEXT |

### Enderecos

| Campo | Tipo |
|---|---|
| Id | INTEGER |
| Cep | TEXT |
| Logradouro | TEXT |
| Complemento | TEXT |
| Bairro | TEXT |
| Cidade | TEXT |
| UF | TEXT |
| Numero | TEXT |
| UsuarioId | INTEGER |

---

## 📜 Scripts SQL

Os scripts de criação das tabelas estão disponíveis no repositório conforme solicitado no teste técnico.

---

## 📂 Organização do Projeto

O sistema segue o padrão arquitetural MVC (Model-View-Controller).

### Controllers

#### EnderecosController

Responsável por:

- Cadastro de endereços
- Edição
- Exclusão
- Persistência de dados
- Integração com ViaCEP
- Exportação CSV

#### AccountController

Responsável por:

- Autenticação mockada
- Validação de login
- Controle de acesso

---

### Models

#### Endereco

Entidade principal contendo:

- CEP
- Logradouro
- Complemento
- Bairro
- Cidade
- UF
- Número

Além das validações obrigatórias e regras de consistência.

#### Usuario

Entidade utilizada para autenticação e integridade referencial.

---

### Views e Partial Views

O projeto utiliza Partial Views para modularização da interface:

- _ModalCriar
- _ModalEditar
- _ModalExcluir

Isso mantém a Index.cshtml mais limpa e organizada.

---

### Scripts

Os scripts JavaScript ficam centralizados na Index.cshtml utilizando:

- Delegação de eventos
- Fetch API
- Manipulação dinâmica de modais Bootstrap

---

## 📌 Boas Práticas Aplicadas

- Arquitetura MVC
- Separação de responsabilidades
- Código modularizado
- Partial Views
- Validação de dados
- Interface responsiva
- Integração com API externa
- Banco local portátil
- Experiência de usuário otimizada

---

## ✅ Atendimento aos Requisitos do Teste

| Requisito | Status |
|---|---|
| Login de usuário | ✅ |
| Validação de credenciais | ✅ |
| Redirecionamento após login | ✅ |
| CRUD de endereços | ✅ |
| Integração ViaCEP | ✅ |
| Exportação CSV | ✅ |
| Banco de dados | ✅ |
| Estrutura MVC | ✅ |
| Entity Framework | ✅ |
| Frontend HTML/CSS/JS | ✅ |
| README completo | ✅ |

---

## 📌 Observações

- O teste sugeria SQL Server, porém foi utilizado SQLite para facilitar execução e portabilidade do projeto.
- O projeto foi desenvolvido com foco em simplicidade, organização e facilidade de avaliação.
- Cada funcionalidade do sistema pode ser organizada em commits separados conforme solicitado no desafio técnico.

---

## ✅ Status do Projeto

- CRUD funcional
- Login funcional
- Integração ViaCEP ativa
- Exportação CSV funcional
- Banco SQLite automático
- Interface responsiva com Bootstrap
- Seed automática implementada

