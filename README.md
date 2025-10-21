# QA Candidates API Tests

A comprehensive .NET 9.0 API testing framework built for testing the Ensek QA Candidates API. This project implements a clean architecture pattern with separation of concerns across multiple projects.

## 🏗️ Architecture

The solution follows a layered architecture pattern with the following projects:

- **Tests** - Test project containing all test cases
- **Clients** - HTTP client interfaces and models for API communication
- **Core** - Core functionality, configuration, and shared utilities
- **Services** - Business logic layer and service implementations

## 🛠️ Technologies & Frameworks

### Core Framework
- **.NET 9.0** - Latest .NET framework
- **C#** - Primary programming language

### Testing Framework
- **xUnit v3** - Modern testing framework with latest features
- **FluentAssertions** - Fluent assertion library for readable test assertions
- **Microsoft.NET.Test.Sdk** - Test SDK for .NET
- **Coverlet.Collector** - Code coverage collection

### HTTP Client & API Communication
- **Refit** - Type-safe REST client library for .NET
- **Refit.HttpClientFactory** - HttpClient factory integration for Refit

### Dependency Injection & Configuration
- **Microsoft.Extensions.DependencyInjection** - Built-in DI container
- **Microsoft.Extensions.Configuration** - Configuration management
- **Microsoft.Extensions.Configuration.Json** - JSON configuration provider

### Data Generation & Builders
- **NBuilder** - Fluent test data builder for creating test objects

### Logging
- **Serilog** - Structured logging framework
- **Serilog.Extensions.Logging** - Microsoft.Extensions.Logging integration
- **Serilog.Sinks.Console** - Console logging sink

## 📁 Project Structure

```
sources/
├── Tests/                    # Test project
│   ├── Fixtures/             # Test fixtures and setup
│   ├── BuyTests.cs          # Buy functionality tests
│   ├── EnergyTests.cs       # Energy API tests
│   ├── OrdersTests.cs       # Orders API tests
│   ├── ResetTests.cs        # Reset functionality tests
│   └── ServiceProvider.cs   # DI container setup
├── Clients/                  # HTTP client layer
│   ├── Contracts/           # Data models and DTOs
│   └── QACandidatesClients/ # API client interfaces
├── Core/                    # Core functionality
│   ├── Configuration/       # Configuration models
│   ├── Converters/          # Custom converters
│   └── Extensions/          # Extension methods
└── Services/                # Business logic layer
    ├── QACandidatesServices/ # Service implementations
    └── RequestHandlers/     # HTTP request handlers
```

## 🧪 Test Features

### Test Organization
- **Collection-based test organization** using xUnit collections
- **Global fixture** for shared test setup and dependency injection
- **Service-based test structure** with dedicated test classes per API endpoint

### Test Categories
- **Energy Tests** - Testing energy/fuel retrieval functionality
- **Buy Tests** - Testing energy purchase operations
- **Orders Tests** - Testing order management
- **Reset Tests** - Testing system reset functionality

### Assertion Patterns
- **FluentAssertions** for readable and maintainable assertions
- **AssertionScope** for multiple assertions with detailed failure reporting
- **Theory-based tests** with inline data for parameterized testing

## 🔧 Configuration

The project uses JSON configuration with the following settings:

```json
{
  "baseUrl": "https://qacandidatetest.ensek.io/",
  "userName": "test",
  "password": "testing"
}
```

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or VS Code with C# extension

### Running Tests
```bash
# Navigate to the solution directory
cd sources

# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test --filter "ClassName=BuyTests"
```

### Building the Solution
```bash
# Build the entire solution
dotnet build

# Build in Release mode
dotnet build --configuration Release
```

## 📋 API Endpoints Tested

The framework tests the following API endpoints:

- **Authentication** - Login functionality
- **Energy** - Fuel/energy data retrieval
- **Buy** - Energy purchase operations
- **Orders** - Order management and retrieval
- **Reset** - System reset functionality

## 🏛️ Design Patterns

- **Repository Pattern** - Service layer abstracts data access
- **Dependency Injection** - Loose coupling through DI container
- **Builder Pattern** - Test data generation using NBuilder
- **Factory Pattern** - Service provider factory for test setup
- **Collection Fixture Pattern** - Shared test setup across test classes

## 📊 Code Quality

- **Nullable reference types** enabled in Core project
- **Implicit usings** enabled for cleaner code
- **Structured logging** with Serilog for better debugging
- **Type-safe HTTP clients** with Refit for API communication
- **Fluent test assertions** for maintainable test code

## 🔍 Key Features

- **Type-safe API clients** using Refit interfaces
- **Comprehensive test coverage** across all API endpoints
- **Clean architecture** with separation of concerns
- **Dependency injection** for testable and maintainable code
- **Structured logging** for debugging and monitoring
- **Fluent assertions** for readable test code
- **Parameterized testing** with xUnit theories
