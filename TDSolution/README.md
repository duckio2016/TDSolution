# TDSolution 🧠📦

This project was created as part of my technical test for Sen Vàng Company. It demonstrates core functionalities such as [briefly list some features if you want, e.g., CRUD operations, authentication, dependency injection using Autofac, etc.]. Although the project covers the main requirements, it may still contain minor issues due to time constraints. Thank you for your understanding.

A clean and extensible .NET 8 Web API project with layered architecture (DTOs, Models, Repositories, Services), SQLite database, Swagger UI for API testing, and built-in pagination support.

## 📁 Project Structure

```
TDSolution/
├── Controllers/           # API Controllers (AccountController, CustomerController, OrderController, ProductController.)
├── DTOs/                  # Data Transfer Objects (OrderDto, ProductDto, etc.)
├── Models/                # EF Core Models (Customer, Order, etc.)
├── Repositories/          # Data access layer with base and entity-specific repositories
├── Services/              # Business logic layer with base and entity-specific services
├── Migrations/            # EF Core Migrations
├── db_order.db            # SQLite database file
├── Program.cs             # Entry point and middleware config
├── TDSolution.http        # HTTP request test file (for REST Client or VS extension)
└── README.md              # Project documentation
```

## 🚀 Technologies Used

- **.NET 8**
- **Entity Framework Core**
- **SQLite**
- **Swagger / Swashbuckle**
- **Layered Architecture** (Controllers, Models,DTOs, Repositories, Services)
- **LINQ-based Pagination**
- **Visual Studio 2022 (v17.14)**

---

## Open with Visual Studio

Open `TDSolution.sln` with **Visual Studio 2022** or later.

## 📘 API Documentation

Swagger UI is enabled by default.

- Navigate to: `https://localhost:{PORT}/swagger`
- Use it to test all endpoints (CRUD for Customer, Order, Product, etc.)

---

## 📦 Features

- [x] RESTful controllers with route-based endpoints
- [x] JWT-based authentication via `/api/account/login`
- [x] Modular DTO structure for cleaner APIs
- [x] EF Core with SQLite and migration support (have seed MasterData sample for Customer + Product on Models.TDSolutionEntities)
- [x] Repositories for abstracting data access
- [x] Services for business logic separation
- [x] Dependency injection with Autofac for repositories, services, and their interfaces
- [x] Object mapping with AutoMapper for clean separation between DTOs and domain models
- [x] Pagination support via `FilterDto` and `PaginationDto<T>`
- [x] Swagger auto-generated API documentation

---

## 🔧 Pagination Example

The `FilterDto` and `PaginationDto<T>` are used across endpoints to support paging:

```csharp
public class FilterDto {
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
```

## 🧹 Code Quality Tools

This project uses the following tools to ensure clean, maintainable, and high-quality code:

- ✅ **SonarLint** — Real-time code analysis and issue highlighting for C#
- ✅ **CodeMaid** — Automatic code cleanup and formatting (organize usings, format spacing, etc.)

> ⚠️ Ensure both extensions are installed and enabled in Visual Studio:
> - [SonarLint for Visual Studio](https://www.sonarsource.com/products/sonarlint/)
> - [CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)

## 🧪 Unit Testing (Planned)

Unit testing with **xUnit** is planned but not yet implemented due to time constraints.

> ✅ If completed early, the test code will be committed in an upcoming update.
"""

## 📌 Final Note

This project is a basic product demo and may contain some imperfections or minor issues.  
Thank you for your understanding and feel free to provide feedback or suggestions for improvement.
"""