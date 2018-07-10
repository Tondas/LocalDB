# Welcome to LocalDB
### .NET oriented database with ACID properties

LocalDB **will be** super fast NoSQL (document based) database with ACID properties running as part as .NET application.

## Best for: 
* .NET applications (Web apps, serivices or windows apps)
* **One instance** applications

## Features: 
* Super simple integration and usage
* Lambda Expressions support
* Unbelievable speed (multiple times faster than common document database which comunicates by network layer (e.g. TCP))
* Delivered as Nuget package

## Motivation: 
Many smaller projects (web apps or services) running as one instance need to store some kind of data in **persistent storage**. 
For this purpose we are using services like:
* **document** databases: MongoDB, RavenDB, CosmosDB ...
* **key value par** databases: DynamoDB, Redis ...
* **relation** databases: MsSQL, PostgreSQL, MySQL ...
but many times it is like a big hammer to small nail. 

What about to have really **simple** and **super fast** solution which will be used comfortable as e.g. Entity Framework.
