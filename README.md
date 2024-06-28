# DotnetCQRS

Dotnet CQRS Pattern

## Tools
- ASP .NET Core
- C#
- SQL Server 2019

## Problem
- Products Management

## Features
- Products Management
- Supplilers Management
- Categories Management
- Users Management


## How to run
- Download or clone repository: `git clone https://github.com/ortizdavid/BankCoreApi`
- Open project directory `cd BankCoreApi`
- Copy database scripts from [_Database](_Database) folder to SQL Server
- Change **__DefaultConnection__** from [appsettings.json](appsettings.json) file
- Import Postman Collections from [_Api_Collections](_Api_Collections)
- Install Packages: `dotnet restore`
- Run Application: `dotnet run`

## Enpoints
1. Products
 - Commands
    - Create Products
    ```http
    POST /api/ProductsCommand
    ```
    - Update Products
    ```http
    PUT /api/ProductsCommand
    ```
    - Delete Products
    ```http
    DELETE /api/ProductsCommand
    ```

 - Queries
    - Get All
    ```http
    GET /api/ProductsQuery?pageIndex=0&pageSize=10
    ```
    - Get By Id
    ```http
    GET /api/ProductsCommand/by-id?id=1
    ```
     - Get By Unique Id
    ```http
    GET /api/ProductsCommand/by-uuid?uniqueId=237e9877-e79b-12d4-a765-321741963000
    ```