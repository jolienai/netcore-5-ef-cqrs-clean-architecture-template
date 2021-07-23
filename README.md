# Asp.Net core 5.0 clean architecture template

This is a solution for a simple API following the principles of clean architecture. 

## What is included?
- AutoMapper
- FluentValidation
- Entity Framework core
- MsSQL
- Swagger
- MediatR
- Grpc client

## Getting Started
1. Clone this repository
2. Navigate to the ```netcore-5-ef-cqrs-clean-architecture-template\src``` and in your terminal and run the command ```$ dotnet new -i ./ ```

The result will be something like as follows, which is a list of all templates you have installed, and a new one that has netcore-microservice-ca as a short name.

```bash
Templates                                         Short Name                   Language          Tags                                 
--------------------------------------------------------------------------------------------------------------------------------------
Console Application                               console                      [C#], F#, VB      Common/Console                       
Class library                                     classlib                     [C#], F#, VB      Common/Library                       
....                
CleanArchitectureTemplate                         CleanArchitectureTemplate    [C#]              Custom template    
```

3. Create new project using this template, just run the commnad below
```
dotnet new CleanArchitectureTemplate -n [service name] -o [folder]
```
for example if I want to create a .net core api called MyService in the Myservice folder I should run inside the directory you of your choice.
```
dotnet new CleanArchitectureTemplate -n MyService -o MyService
```
As a result you will see this message in your terminal : ```The template "CleanArchitectureTemplate" was created successfully.```

4. Go to MyService/src/MyService.Api
5. ```dotnet restore```
6. ```dotnet build ```
7. ```dotnet run```
8. Open your browser and go to http://localhost:5000/swagger/index.html

9. Environment variables:
To use your local server:

```bash
$env:DATABASE_CONNECTION = 'Data Source=localhost,11433;Initial Catalog=ServiceDb;User Id=sa;Password=Pa$$w0rd;MultipleActiveResultSets=True'
```
In memory database

```bash
$env:USE_INMEMORY_DATABASE='true'
```

10. To unistall the custom template

```bash
 dotnet new -u
```
The result will be a list of all templates installed, so find the CleanArchitectureTemplate and run the uninstall commmand.

## HealthCheck 
### endpoint 
https://localhost:5001/healthz

- Response example
```
{
   "status":"Healthy",
   "totalDuration":"00:00:00.0033869",
   "entries":{
      "sqlserver":{
         "data":{
            
         },
         "duration":"00:00:00.0031359",
         "status":"Healthy",
         "tags":[
            
         ]
      }
   }
}
```
### UI
https://localhost:5001/show-health-ui
