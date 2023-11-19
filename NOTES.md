# NOTES

Application - WebAPI - Responsável pelas rotas e comunica com Service que será chamado.

Service - Faz as validações do conteúdo e executa a regra de negócio. Trabalha com a Domain e Implementa a Infrastructure, faz a comunicação com o Data.

Infrastructure - Responsável pela comunicação dos dados. Divida em 2:

- Data: Possui o Entity Framework que vai comunicar diretamente com o banco fazendo o crud;
- CrossCutting: Faz a Injeção de dependência para a Application, e deixar ela desconectada da camada de Data e chama o UserService. Pode ser utilizada para chamar ouras APIs e concentra os métodos genéricos.

Domain - Onde se concentra as Interfaces, domínio e entidades, para as ouras camadas poderem fazer a injeção de dependência. Passa os parâmetros da aplicação.

## Commands starting

dotnet new sln --name Api

dotnet new webapi -n application -o Api.Application --no-https -f
dotnet sln add .\Api.Application\

dotnet new classlib -n Domain -o Api.Domain -f netcoreapp3.1
dotnet sln add .\Api.Domain\

dotnet new classlib -n CrossCutting -o Api.CrossCutting -f netcoreapp3.1
dotnet sln add .\Api.CrossCutting\

dotnet new classlib -n Data -f netcoreapp3.1 -o Api.Data
dotnet sln add .\Api.Data\

dotnet new classlib -n Service -f netcoreapp3.1 -o Api.Service
dotnet sln add .\Api.Service\

dotnet build

## Commands used

dotnet add .\Api.Data\ reference .\Api.Domain\

dotnet build

dotnet add .\Api.Service\ reference .\Api.Data\
dotnet add .\Api.Service\ reference .\Api.CrossCutting\

dotnet build

dotnet add .\Api.Application\ reference .\Api.Domain\
dotnet add .\Api.Application\ reference .\Api.Service\
dotnet add .\Api.Application\ reference .\Api.CrossCutting\

dotnet build

dotnet add .\Api.CrossCutting\ reference .\Api.Domain\
dotnet add .\Api.CrossCutting\ reference .\Api.Service\
dotnet add .\Api.CrossCutting\ reference .\Api.Data\

dotnet build
