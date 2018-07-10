# Welcome to LocalDB
### .NET oriented database with ACID properties

LocalDB **will be** super fast NoSQL (document based) database with ACID properties running as part as .NET application.

## Best for: 
* .NET applications (Web apps, services or console/windows apps)
* **One instance** applications

## Features: 
* Simple integration and usage
* Lambda Expressions support
* Unbelievable speed (multiple times faster than common databases which comunicate by network layer (e.g. TCP))
* Delivered as Nuget package

## Motivation: 
Many smaller projects (web apps or services) running as one instance and need to store some kind of data in **persistent storage**. 
For this purpose we are using services like:
* **document** databases: MongoDB, RavenDB, CosmosDB ...
* **key value par** databases: DynamoDB, LevelDB ...
* **relation** databases: MsSQL, PostgreSQL, MySQL ...
but many times it is like a big hammer to small nail. 

What about to have really **simple** and **super fast** solution which will be used comfortable as e.g. Entity Framework and runs as part as .NET application.
