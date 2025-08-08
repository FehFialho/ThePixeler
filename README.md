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
* Configuramos cada relacionamento no arquivo DBContext.
* Priorizar sempre fazer relacionamento de FILHAS PARA PAIS.