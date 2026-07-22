# Student Management System API

A Student Management System developed using ASP.NET Core Web API, SQL Server and Entity Framework Core.

## Technologies Used

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server
- JWT Authentication
- Serilog Logging
- Swagger API Documentation
- Repository Pattern
- Service Layer Architecture

---

# Project Architecture

```
StudentManagement.API

├── Controllers
│   ├── AuthController
│   └── StudentController
│
├── Services
│   ├── Interfaces
│   └── StudentService
│
├── Repositories
│   ├── Interfaces
│   └── StudentRepository
│
├── Models
├── DTOs
├── Data
├── Middleware
├── Helpers
└── Migrations
```

---

# Features

## Authentication

JWT based authentication implemented.

Protected APIs require JWT token.

## Student Management

Available operations:

- Get all students
- Get student by id
- Add student
- Update student
- Delete student

---

# Database Setup

## Requirements

Install:

- SQL Server 2025
- SQL Server Management Studio 22

---

## Database Configuration

Update:

```
StudentManagement.API/appsettings.json
```

Connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

# Run Database Migration

Open PowerShell inside project folder:

```
cd StudentManagement.API
```

Run:

```
dotnet ef database update
```

Database will be created automatically.

---

# Run Application

Navigate to API folder:

```
cd StudentManagement.API
```

Run:

```
dotnet run
```

---

# Swagger Documentation

After running application:

Open:

```
https://localhost:5072/swagger
```

---

# JWT Login

Use:

```
POST /api/Auth/login
```

Example:

```json
{
  "username":"admin",
  "password":"admin123"
}
```

Copy generated token.

Click:

```
Authorize
```

in Swagger.

Enter:

```
Bearer YOUR_TOKEN
```

---

# Student API Endpoints

## Get Students

```
GET /api/Student
```

---

## Add Student

```
POST /api/Student
```

Example:

```json
{
"name":"John",
"email":"john@gmail.com",
"age":22,
"course":"Computer Science"
}
```

---

## Update Student

```
PUT /api/Student/{id}
```

---

## Delete Student

```
DELETE /api/Student/{id}
```

---

# Error Handling

Global exception handling middleware implemented.

All exceptions return standard API responses.

---

# Logging

Serilog is configured.

Logs are stored in:

```
Logs/
```

---

# Author

UserShivam09