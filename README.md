# API de Gerenciamento de Tarefas

Esta é uma API RESTful desenvolvida em ASP.NET Core para gerenciar tarefas em um sistema de gerenciamento de tarefas.

## Funcionalidades

- Adicionar uma nova tarefa.
- Excluir uma tarefa existente.
- Atualizar uma tarefa existente.
- Obter informações sobre uma tarefa específica.
- Obter uma lista de todas as tarefas.
- Pesquisar tarefas por título.
- Filtrar tarefas por data.
- Filtrar tarefas por status.

## Configuração

Antes de executar a API, certifique-se de ter o .NET Core SDK instalado em seu sistema. Você também precisará configurar um banco de dados compatível, como SQL Server, MySQL ou SQLite, e atualizar a string de conexão no arquivo `appsettings.json`.

## Endpoints

Aqui estão os principais endpoints disponíveis na API:

- **POST /Task**: Adiciona uma nova tarefa.
- **DELETE /Task/{id}**: Exclui uma tarefa existente.
- **PUT /Task/{id}**: Atualiza uma tarefa existente.
- **GET /Task/{id}**: Obtém informações sobre uma tarefa específica.
- **GET /Task/ObterTodos**: Obtém uma lista de todas as tarefas.
- **GET /Task/ObterPorTitulo?title={title}**: Pesquisa tarefas por título.
- **GET /Task/ObterPorData?date={date}**: Filtra tarefas por data.
- **GET /Task/ObterPorStatus?status={status}**: Filtra tarefas por status.

## Executando a API

Para executar a API, navegue até o diretório raiz do projeto e execute o seguinte comando:

-Dotnet run



A API será iniciada e estará disponível em `https://localhost:5001`.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request com melhorias, correções de bugs, ou novos recursos.




