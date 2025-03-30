# Library Management System

## Overview

This is a simple C# .NET 8 console application that manages a library of books using the Repository Pattern. It supports adding, updating, deleting, and retrieving books while ensuring ISBN validation. The application is structured to allow easy expansion by replacing the in-memory repository with a different data storage solution.

## Features

- 📚 CRUD operations (Create, Read, Update, Delete) for books
- ✅ ISBN format validation
- 🔌 Dependency injection for repository management
- 🧪 Unit tests for service and repository layers

## Dependency Injection & Expandability

The `IBookRepository` interface abstracts the data access layer, allowing easy replacement of `InMemoryBookRepository` with other data sources (e.g., a database repository).

### Replacing the In-Memory Repository

1. Create a new repository class (e.g., `DatabaseBookRepository`).
2. Implement `IBookRepository` methods using a database like SQL.
3. Inject the new repository into `BookService` in `Program.cs`:

```csharp
IBookRepository repository = new DatabaseBookRepository();
BookService bookService = new BookService(repository);
```

## Requirements

- 🛠 .NET 8 SDK installed
- 🖥 Visual Studio (2022 or any C# IDE)
- 📦 Moq & xUnit for testing

## Running the Application

1. Clone the repository.
2. Open the project in Visual Studio.
3. Build the project.
4. Run the application.

## Running Unit Tests

1. Open Test Explorer in Visual Studio.
2. Click **Run All Tests** to verify functionality.

## Future Enhancements

- 🗄 Implement database persistence
- 🌍 Add API endpoints for a web-based UI
- 🔐 Introduce user authentication and permissions

---

This project is designed to be **modular, scalable, and easy to extend**. 🚀

