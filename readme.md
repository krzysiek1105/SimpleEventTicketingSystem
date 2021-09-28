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

Database passed in the connection string should be empty. It will be populated with tables on application startup. 
## Architecture overview
The design follows the principles of onion architecture. That means it is divided into four layers, each in separate project. It also tries to incorporate domain-oriented design principles. In addition to the ASP.Net Core framework, the project was built using libraries: MediatR and Entity Framework.

![dependencies](https://user-images.githubusercontent.com/33417214/135132118-c33b1182-4ff3-4ccc-8da3-ec54508d1c85.png)

### SimpleEventTicketingSystem.API
SimpleEventTicketingSystem.API is a standard ASP.Net Core application which provides REST API and Swagger UI for better testability. It contains two controllers that provide actions for the client to interact with the system. There is no logic in controllers. Due to the use of the mediator pattern, in controller method, an query/command object is created and then is sent to its handler, which is implemented in the application layer.
### SimpleEventTicketingSystem.Application
This layer contains commands and queries and their corresponding handlers. There are several commands/queries in the project that are responsible for encapsulating individual business cases. In command/query handler, all necessary entities are retrieved from repositories that are required to perform business action. Business logic is then executed on the entities, resulting in the final storage of the results in the database. 
### SimpleEventTicketingSystem.Domain
This layer contains entities, value objects and repository interfaces. It also contains custom domain exceptions and repository interfaces that implementation can be found in the infrastructure layer.
### SimpleEventTicketingSystem.Infrastructure
This layer is responsible for providing implementations for interfaces from the domain layer. Entity Framework was used in this project as an ORM framework, so this layer contains entities configurations as well as the implementations of the various repositories.
 