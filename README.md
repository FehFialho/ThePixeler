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
```$env:JWT_SECRET = "vW9f!2gH7pQ#kLmN4rT8yUvWxZ1aB3cD"```

* Pode ser necessário instalar as seguintes bibliotecas:
```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```
## Endpoints
* Utilizar UseCases para implementar os Endpoints.
* Usar alguns serviços.
* Se necessário, criar DTOs para completar as informçãoes (DTOs são os Payloads do Endpoint).

## Swagger
* Habilitar Swagger com ```dotnet add package Swashbuckle.AspNetCore```

## Uso de JWT e DTOs nos Endpoints
Para extrair o UserID do token JWT diretamente no endpoint, criar um DTO com os dados recebidos pelo front-end e enviar para o UseCase, siga o passo a passo abaixo:

### 1. Criar o Payload do UseCase

Defina um record com os dados que o front-end envia, sem incluir o UserID (que será extraído do JWT). Por exemplo:
```
public record EditProfileDataPayload(
    string? Username,
    string? Password,
    string? Email,
    string? ProfilePicture,
    string? ProfileBio
);
```
### 2. Criar o DTO para o Endpoint

O DTO recebe o UserID extraído do JWT junto com os dados do payload:
```
public record EditProfileDataDTO(
    Guid UserID,
    string? Username,
    string? Password,
    string? Email,
    string? ProfilePicture,
    string? ProfileBio
);
```
### 3. Extrair o UserID no Endpoint

Utilize o serviço EFExtractJWTData (ou pegue a claim diretamente do HttpContext.User) para obter o UserID a partir do HttpContext:
```
// usando serviço
var userID = await extractJWTData.GetUserGuid(http);
if (userID is null)
    return Results.Unauthorized();

// ou pegando a claim diretamente
var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
if (claim is null)
    return Results.Unauthorized();
var userID = Guid.Parse(claim.Value);
```
### 4. Criar o DTO com o UserID e o Payload

Combine os dados do front-end com o UserID extraído:
```
var dto = new EditProfileDataDTO(
    UserID: userID.Value,
    Username: payload.Username,
    Password: payload.Password,
    Email: payload.Email,
    ProfilePicture: payload.ProfilePicture,
    ProfileBio: payload.ProfileBio
);
```
### 5. Passar o DTO para o UseCase
O UseCase recebe apenas o DTO, sem precisar lidar com extração de JWT:

```
var result = await useCase.Do(dto);

if (!result.IsSuccess)
    return Results.BadRequest(result.Reason);

return Results.Ok(result.Data);
```

### Resumo:

Payload: dados enviados pelo front-end

JWT: extraído no endpoint

DTO: combina UserID do JWT + payload

UseCase: recebe apenas o DTO pronto
