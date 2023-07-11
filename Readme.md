# Teste Técnico - Sistema MVC de Cadastro de Clientes

Este é um projeto de teste técnico onde é montado um sistema MVC simples utilizando .NET, C#, MySQL e InputMask. O sistema consiste em um cadastro de clientes que possui regras internas de validações, incluindo iterações com JavaScript e Razor para aprimorar a experiência do usuário. Além disso, são aplicadas validações de duplicação de documentos e e-mails.

## Como Utilizar

### Pré-requisitos

- Git: [Download Git](https://git-scm.com/downloads)
- .NET: [Download .NET](https://dotnet.microsoft.com/download)
- MySQL: [Download MySQL](https://dev.mysql.com/downloads/installer/)

### Passo a Passo

1. Configurando o Banco de Dados:

Instale o MySQL em seu sistema e crie um banco de dados para o projeto.
Abra o arquivo appsettings.json do projeto e insira as informações de conexão com o banco de dados, conforme o exemplo abaixo:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=nome-do-host;Port=porta-do-host;Database=nome-do-banco;Uid=nome-de-usuario;Pwd=senha-do-usuario;"
  }
}
```

2. Executando as Migrações do Banco de Dados:

No terminal, navegue até o diretório raiz do projeto e execute os seguintes comandos:

```
# Restaure as dependências do projeto
dotnet restore

# Execute as migrações do banco de dados
dotnet ef database update
```

3. Rodando o Projeto:

No terminal, execute o seguinte comando para iniciar o servidor:

```
dotnet run
```

## Funcionalidades
O sistema de cadastro de clientes possui as seguintes funcionalidades:

1. Cadastro de Clientes
Os usuários podem cadastrar novos clientes fornecendo as informações necessárias, como nome, documento, e-mail, telefone, endereço, entre outros. O sistema realiza diversas validações para garantir que os dados inseridos sejam corretos e atendam às regras internas de validações.

2. Validações Internas
Ao cadastrar um cliente, o sistema realiza uma série de validações internas para garantir a integridade dos dados. Essas validações podem incluir:

- Verificação de duplicação de documentos: O sistema verifica se o documento informado já está cadastrado para outro cliente. Caso haja duplicação, uma mensagem de erro é exibida, e o usuário é solicitado a corrigir o documento.
- Validação de e-mails: O sistema verifica se o e-mail fornecido está em um formato válido e se não está duplicado em outro cadastro de cliente. Se o e-mail for inválido ou duplicado, uma mensagem de erro é exibida para o usuário.

3. Atualização e Exclusão de Clientes
Além do cadastro, o sistema também permite a atualização e exclusão dos clientes registrados. Os usuários podem modificar as informações dos clientes, como endereço, telefone ou e-mail, garantindo que os dados estejam sempre atualizados. Também é possível excluir um cliente caso não seja mais necessário.

4. Listagem de Clientes
O sistema oferece uma funcionalidade de listagem de clientes, permitindo aos usuários visualizarem todos os clientes cadastrados. Essa listagem pode ser filtrada e ordenada por critérios específicos, como nome, documento ou data de cadastro.

5. Pesquisa de Clientes
O sistema disponibiliza uma função de pesquisa que permite aos usuários localizarem clientes com base em critérios específicos. Isso facilita a recuperação rápida e precisa de informações de clientes específicos.

O sistema de cadastro de clientes apresenta um conjunto completo de funcionalidades CRUD (Create, Read, Update, Delete), permitindo aos usuários realizar todas as operações essenciais de gerenciamento de clientes. Essas funcionalidades são implementadas com regras internas de validações, garantindo a consistência e a integridade dos dados.

## Tecnologias Utilizadas
- .NET
- C#
- MySQL
- InputMask
- Toastify
- JavaScript
- Razor