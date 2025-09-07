# ThePixeler
**Final project for C# course at ETS.**
## Inicio
* Criar um novo reposítório.
* Rodar o comando ``` dotnet new web ``` para criar a estrutura inicial do projeto.
  
## Models  
* Criar as pastas para cada uma das tabelas MER(Modelo Entidade Relacionamento);
* Colocar o Namespace e criamos a classe com os atributos de cada tabela;

## Navigations
* Relacionar as tabelas colocando os objetos de outras tabelas.
* Devem estar sempre em par.

## DBContext
* Instalar o DBContext pelo terminal com os seguintes comandos:
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
* Configurar cada relacionamento no DBContext priorizando sempre fazer relacionamento de FILHAS PARA PAIS.
* Criar um novo DataBase no SQL.
* Configurar Variavel de ambiente do SQL.
 ```
 $env:SQL_CONNECTION = "Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=ThePixeler;Trust Server Certificate=true;Integrated Security=true"
```
## Migrations
* Configurar Migrations com:
 ```
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialModel
dotnet ef database update
```
