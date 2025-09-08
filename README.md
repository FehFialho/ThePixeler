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
* Quando há FK, criar uma propriedade de navegação para a entidade relacionada.
* Na relacionada, criar uma ICollection<T> com o nome da entidade que contém a FK, representando a relação de um-para-muitos.
* Por exemplo, se existe uma classe Book que tem Author, na classe Author teria: ```public ICollection<Book> Books { get; set; } = new List<Book>();```

## DBContext
* Instalar o DBContext pelo terminal com os seguintes comandos:
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
* Configurar cada relacionamento no DBContext priorizando sempre fazer relacionamento de FILHAS PARA PAIS.
* Uma configuração por flecha do DER.
* Relações N-N não precisam de .OnDelete e FK.
* Abaixo, código para o ```Program.cs```
```
builder.Services.AddDbContext<ThePixelerDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});
```

## Conexão com SQL 
* Criar um novo DataBase no SSMS.
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
* Se algo nas Models for alterado rodar ```add InitialModel``` e ```database update```.

## UseCases
* Definir o que vai ser necessário para o aplicativo e listar.
* Criar a classe Result na raiz do projeto.
* Reparar em código que se repete para criar Serviços.
* Configurar Payloads e Response antes de implementar.

## Payload e Response
* Definir o que vai chegar e sair dos UseCases.
* Listar Namespace corretamente.

## JWT
```dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer```
```$env:JWT_SECRET```

## Endpoints
* Utilizar UseCases para implementar os Endpoints.
* Usar alguns serviços.
* Se necessário, criar DTOs para completar as informçãoes (DTOs são os Payloads do Endpoint).

## Swagger
* Habilitar Swagger com ```dotnet add package Swashbuckle.AspNetCore```
