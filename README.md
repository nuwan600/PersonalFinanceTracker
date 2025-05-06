# Personal Finance Tracker

A full-stack personal finance tracking application built with Blazor WebAssembly and ASP.NET Core Web API.

## Features

- Track income and expenses
- View financial summary (total income, expenses, and savings)
- Add, edit, and delete transactions
- Form validation
- Responsive UI with MudBlazor components

## Technologies

### Backend
- ASP.NET Core 8 Web API
- Entity Framework Core (Code First)
- SQL Server (LocalDB)
- Repository Pattern
- AutoMapper
- Swagger for API documentation

### Frontend
- Blazor WebAssembly
- MudBlazor component library
- Responsive design


## Architecture

The application follows a clean architecture with separation of concerns:

1. **API Layer**: Handles HTTP requests and responses
2. **Service Layer**: Contains business logic
3. **Repository Layer**: Handles data access
4. **Domain Layer**: Contains entities and DTOs

The frontend communicates with the backend via RESTful API calls.

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