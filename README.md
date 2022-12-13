# ProductManager

## :pencil: Descrição

A solução consiste em uma **Rest API construída em camadas** que realiza o gerenciamento de produtos listados em um banco SQL Server.

O projeto é realizado seguindo as abordagens de [Domain-Driven Design](https://engsoftmoderna.info/artigos/ddd.html#:~:text=DDD%20%C3%A9%20uma%20abordagem%20para,mas%20dentro%20de%20um%20contexto) e [Clean Architecture](https://medium.com/luizalabs/descomplicando-a-clean-architecture-cf4dfc4a1ac6).

### Projetos
* ProductManager.Presentation
* ProductManager.Domain
* ProductManager.Application
* ProductManager.Infraestructure

## :file_folder: Acesso ao projeto

Você pode [acessar o código fonte do projeto](https://github.com/pedro-h-soares/ProductManager.git) ou [baixá-lo](https://github.com/pedro-h-soares/ProductManager/archive/refs/heads/master.zip).

## :hammer_and_wrench: Abrir e rodar o projeto

* Abra o projeto no [Visual Studio](https://visualstudio.microsoft.com/free-developer-offers/); 
* Defina o 'ProductManager.Presentation' como projeto de inicialização;
* [Adicione uma fonte de dados SQL Server](https://learn.microsoft.com/visualstudio/data-tools/create-a-sql-database-by-using-a-designer?view=vs-2022)
* Troque a string de conexão com o banco em 'appsettings.json';
* Abra o [Package Manager Console](https://learn.microsoft.com/nuget/consume-packages/install-use-packages-powershell) Console no projeto 'ProductManager.Infraestructure.Data';
* Execute o comando [Update-Database](https://learn.microsoft.com/ef/core/cli/powershell).

## :hammer: Funcionalidades

* Listagem de produtos: com **paginação** e **filtragem dos resultados**
* Inserção de produto: **validação** de data de fabricação e data de expiração
* Atualização de produto: **validação** de data de fabricação e data de expiração
* Remoção de produto: coloca produto como **inativo**
