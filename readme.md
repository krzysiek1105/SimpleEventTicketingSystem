# SimpleEventTicketingSystem
A simple event management application.
Create events, set up ticket pools.
Book tickets and return them on demand.
## Getting started
### Prerequisites
+ .NET 5
+ MySQL Database
### Configuration
The first step is to build the project solution. It can be done with the dotnet command tool. Commands below assume present working directory being set to the root directory of the project.
#### Build action
```
dotnet build
```

#### Run action
```
dotnet run --project SimpleEventTicketingSystem.API
```
#### MySQL connection configuration


Since connection with a database is necessary, database connection string must be properly set in `appsettings.json` file. Currently, there is only support for a MySQL database. Sample connection string is presented below and it establishes connection with database `ev` on `127.0.0.1` host, using user `root` with no password.
```
  "ConnectionStrings": {
    "Default": "Server=127.0.0.1;Database=ev;Uid=root;AllowUserVariables=True;"
  }
```
Connection strings may vary, but it is crucial to set `AllowUserVariables` flag to `true`.
## Architecture overview
The design follows the principles of onion architecture. That means it is divided into four layers, each in separate project. It also tries to incorporate domain-oriented design principles.
### SimpleEventTicketingSystem.API
SimpleEventTicketingSystem.API is a standard ASP.Net Core application which provides REST API and Swagger UI for better testability. It contains 
### SimpleEventTicketingSystem.Application
Command/query separation 
### SimpleEventTicketingSystem.Domain
### SimpleEventTicketingSystem.Infrastructure
 