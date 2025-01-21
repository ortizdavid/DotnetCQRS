# DotnetCQRS

A project implementing the CQRS pattern using .NET.

## Architecture
![CQRS Pattern](_Docs/CQRS-Single-Database.png)

## Tools
- ASP.NET Core
- C#
- SQL Server 2019

## Problem
- Management of various entities such as products, suppliers, categories, and users.

## Features
- Products Management
- Suppliers Management
- Categories Management
- Users Management

## How to Run
1. Download or clone the repository:
    ```sh
    git clone https://github.com/ortizdavid/DotnetCQRS
    ```
2. Navigate to the project directory:
    ```sh
    cd DotnetCQRS/DotnetCQRS
    ```
3. Copy the database scripts from the [_Database](DotnetCQRS/_Database) folder to SQL Server.
4. Update the **DefaultConnection** string in the [appsettings.json](DotnetCQRS/appsettings.json) file with your SQL Server details.
5. Import the Postman Collections from the [_Api_Collections](DotnetCQRS/_Api_Collections) folder.
6. Install the required packages:
    ```sh
    dotnet restore
    ```
7. Run the application:
    ```sh
    dotnet run
    ```

## Endpoints

### Products

#### Commands

- **Create Product**
    ```http
    POST /api/ProductsCommand
    ```
    ```json
    {
        "categoryId": 2,
        "supplierId": 21,
        "productName": "string",
        "code": "string",
        "unitPrice": 0.01,
        "description": "string"
    }
    ```
- **Update Product**
    ```http
    PUT /api/ProductsCommand
    ```
    ```json
    {
        "productId": 1,
        "categoryId": 1,
        "supplierId": 2,
        "productName": "string",
        "code": "string",
        "unitPrice": 80.01,
        "description": "string"
    }
    ```
- **Delete Product**
    ```http
    DELETE /api/ProductsCommand?productId=98
    ```

#### Queries

- **Get All Products**
    ```http
    GET /api/ProductsQuery?pageIndex=0&pageSize=10
    ```
- **Get Product By ID**
    ```http
    GET /api/ProductsQuery/by-id?id=1
    ```
- **Get Product By Unique ID**
    ```http
    GET /api/ProductsQuery/by-uuid?uniqueId=237e9877-e79b-12d4-a765-321741963000
    ```
