# ThePixeler
**Final project for C# course at ETS.**

## Models  
* Criamos as pastas para cada uma das tabelas MER(Modelo Entidade Relacionamento);
* Colocamos o Namespace e criamos a classe com os atributos de cada tabela;

## Navigations
* Relacionamos as tabelas colocando os objetos de outras tabelas.

## DBContext
* Instalamos o DBContext pelo terminal com os seguintes comandos:
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
* Configuramos cada relacionamento no DBContext priorizando sempre fazer relacionamento de FILHAS PARA PAIS.
* Configurar Variavel de ambiente do SQL
 ```
 $env:SQL_CONNECTION = "Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=ThePixeler;Trust Server Certificate=true;Integrated Security=true"
```
* Configurar Migrations com:
 ```
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialModel
dotnet ef database update
```
## UseCases
* Levantamos UseCases necessários para realizar o projeto.
* Criamos a classe Result<T> no diretório do Projeto.
* Definimos entrada e saída de cada UseCase.