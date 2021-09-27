# SimpleEventTicketingSystem
A simple event management application.
Create events, set up ticket pools.
Book tickets and return them on demand.
## Getting started
### Prerequisites
+ .NET 5
+ MySQL Database
### Configuration
First step is to build the project solution. It can be done with the dotnet command tool or with an IDE, like Visual Studio. Because a connection with a database is necessary, database connection string must be properly set in appsettings.json file. Currently, there is only support for a MySQL database. Connection string must be set in the ConnectionStrings section. The last step is to run the app. App entry point is in SimpleEventTicketingSystem.API project.
## Architecture overview
The design follows the principles of onion architecture. That means it is divided into four layers, each in separate project. It also tries to incorporate domain-oriented design principles.
### SimpleEventTicketingSystem.API
### SimpleEventTicketingSystem.Application
### SimpleEventTicketingSystem.Domain
### SimpleEventTicketingSystem.Infrastructure