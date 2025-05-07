## Setup Instructions

### Prerequisites

- .NET 8 SDK
- SQL Server (or SQL Server Express LocalDB)
- Visual Studio 2022 or VS Code with C# extensions

### Backend Setup

1. Clone the repository
2. Navigate to the `FinanceTracker.API` folder
3. Update the connection string in `appsettings.json` if needed
4. Run the following commands:
    select Persistence
    add-Migration inital
    Update-Migration

## Technologies

### Backend
- ASP.NET Core 8 Web API
- Entity Framework Core (Code First)
- SQL Server (LocalDB)
- Repository Pattern
- AutoMapper
- Swagger for API documentation

### Technology Choices and Reasoning

### Backend Technology	Reasoning (PFT.API)
- ASP.NET Core 8	Latest LTS version with performance improvements, minimal APIs, and native AOT support. Ideal for building scalable RESTful APIs.
- Entity Framework Core	ORM simplifies database operations with Code-First approach, migrations, and LINQ support. Reduces boilerplate SQL code.
- SQL Server	Robust relational database with ACID compliance. LocalDB used for development simplicity; easily upgradable to full SQL Server.
- Repository Pattern	Abstracts data access, making it easier to swap databases (e.g., to PostgreSQL) or mock for unit testing.
- Swagger/OpenAPI	Automatic API documentation with testing UI, improving developer experience.

### Frontend
- Blazor WebAssembly
- MudBlazor component library
- Responsive design

### Frontend Technology	Reasoning (PFT.Web)
- Blazor WebAssembly	Enables full-stack C# development (no JavaScript). Client-side execution reduces server load. Offline-capable with PWA support.
- MudBlazor	Material Design-based component library with built-in responsiveness, theming, and accessibility. Faster UI development than raw CSS.

## Architecture

The application follows a clean architecture with separation of concerns:

1. **API Layer**: Handles HTTP requests and responses
2. **Service Layer**: Contains business logic
3. **Repository Layer**: Handles data access
4. **Domain Layer**: Contains entities and DTOs

### Choice	Reasoning
- Layered Architecture (Core/Infrastructure/API)	Separation of concerns. Core contains business logic, Infrastructure handles external dependencies (DB), API exposes endpoints.
- Clean Architecture	Domain-centric design. Business rules are independent of frameworks/databases.

The frontend communicates with the backend via RESTful API calls.

