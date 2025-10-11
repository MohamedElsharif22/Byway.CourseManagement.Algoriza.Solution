# 🎓 Byway Course Management API

<div align="center">

A comprehensive online learning platform API built with ASP.NET 9.0, featuring robust authentication, course management, shopping cart functionality, and secure checkout processes.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=for-the-badge&logo=swagger)](https://swagger.io/)
[![Entity Framework](https://img.shields.io/badge/EF_Core-9.0-purple?style=for-the-badge)](https://docs.microsoft.com/en-us/ef/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-2019+-CC2927?style=for-the-badge&logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)

</div>

---

## 📋 Table of Contents

- [🚀 Getting Started](#-getting-started)
- [✨ Features](#-features)
- [🧪 Testing with Postman](#-testing-with-postman)
- [📚 API Documentation](#-api-documentation)
- [⚠️ Error Handling](#️-error-handling)
- [🛠️ Development](#️-development)

---

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

| Requirement   | Version | Download                                                              |
| ------------- | ------- | --------------------------------------------------------------------- |
| .NET SDK      | 9.0+    | [Download](https://dotnet.microsoft.com/download)                     |
| SQL Server    | 2019+   | [Download](https://www.microsoft.com/sql-server/sql-server-downloads) |
| Visual Studio | 2022+   | [Download](https://visualstudio.microsoft.com/)                       |

### 📦 Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/MohamedElsharif22/algoriza-internship2025-EXFS47-BE-byway
   cd Byway.CourseManagement.Algoriza.Solution
   ```

2. **Update appsetting connection**

   Edit `DefaultConnection` with your SQL Server connection string
   Edit `EmailSettings:FromEmail` with your Email
   Edit `EmailSettings:Password` with your App password from your mail provieder
   Edit `Authentication:Google` with your your Secrets from google authentication service provieder

3. **Run migrations**

   ```bash
   dotnet ef database update
   ```

4. **Start the application**
   ```bash
   dotnet run
   ```

### 🔐 Admin Access

Use these credentials to access admin features:

```json
{
  "email": "admin@byway.com",
  "password": "Admin@123"
}
```

> ⚠️ **Important:** Change the default admin password in production!

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 🔒 Security

- JWT Authentication
- Google Sign-in Integration
- Role-based Authorization
- Input Validation & Sanitization

</td>
<td width="50%">

### 🎯 Core Features

- Course Catalog with Filtering
- Shopping Cart Management
- Secure Checkout Process
- Instructor Management

</td>
</tr>
<tr>
<td width="50%">

### 📦 Technical

- File Upload Support
- Global Error Handling
- CORS Configuration
- RESTful API Design

</td>
<td width="50%">

### 📊 Data Management

- Advanced Search & Filtering
- Pagination Support
- AutoMapper Integration
- EF Core Migrations

</td>
</tr>
</table>

---

## 🧪 Testing with Postman

I provide a comprehensive Postman collection to help you test all API endpoints quickly and easily.

### 📥 Get the Collection

**[Download Postman Collection](https://github.com/MohamedElsharif22/byway-postman-collection)**

This collection includes:

- ✅ Pre-configured requests for all endpoints
- ✅ Collection variables setup
- ✅ Authentication token management
- ✅ Sample request bodies
- ✅ Test scripts for validation

### 🔧 Quick Setup

1. Import the collection into Postman
2. Set your API base URL in Collection variables
3. Run the authentication request first
4. Start testing other endpoints!

---

## 📚 API Documentation

### 🔐 Authentication

#### Register New User

<details>
<summary><code>POST</code> <code>/api/Account/register</code></summary>

##### Request Body

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "phone": "+1234567890",
  "email": "john@example.com",
  "password": "P@ssw0rd123"
}
```

##### Success Response `200 OK`

```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

##### Error Response `400 Bad Request`

```json
{
  "statusCode": 400,
  "message": "Validation Error",
  "errors": [
    "Password must have at least 1 Uppercase",
    "Email is already taken"
  ]
}
```

</details>

---

### 📖 Courses

#### List Courses

<details>
<summary><code>GET</code> <code>/api/Courses</code></summary>

##### Query Parameters

| Parameter   | Type    | Default | Description                        |
| ----------- | ------- | ------- | ---------------------------------- |
| `pageSize`  | int     | 30      | Results per page                   |
| `pageIndex` | int     | 1       | Page number (1-based)              |
| `search`    | string  | -       | Search in title and description    |
| `category`  | int     | -       | Filter by category ID              |
| `minPrice`  | decimal | -       | Minimum price filter               |
| `maxPrice`  | decimal | -       | Maximum price filter               |
| `sort`      | string  | -       | Sort by: `price`, `rating`, `name` |

##### Success Response `200 OK`

```json
{
  "pageIndex": 1,
  "pageSize": 20,
  "count": 50,
  "data": [
    {
      "id": 1,
      "title": "Complete C# Programming Bootcamp",
      "description": "Master C# programming from basics to advanced topics",
      "price": 99.99,
      "rating": 5,
      "categoryName": "Programming",
      "instructorName": "John Smith",
      "coverPictureUrl": "https://api.byway.com/images/courses/1.jpg"
    }
  ]
}
```

</details>

---

### 🛒 Shopping Cart

#### Get Cart

<details>
<summary><code>GET</code> <code>/api/Cart?id={cartId}</code></summary>

##### Path Parameters

| Parameter | Type          | Description            |
| --------- | ------------- | ---------------------- |
| `cartId`  | string (GUID) | Unique cart identifier |

##### Success Response `200 OK`

```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "items": [
    {
      "courseId": 1,
      "title": "Complete C# Programming Bootcamp",
      "price": 99.99
    }
  ],
  "totalItems": 1,
  "subTotal": 99.99
}
```

</details>

---

### 💳 Checkout

#### Process Checkout

<details>
<summary><code>POST</code> <code>/api/Checkout/process/{cartId}</code></summary>

##### Request Body

```json
{
  "paymentMethod": "CreditCard",
  "paymentTransactionId": "ch_1234567890"
}
```

##### Success Response `200 OK`

```json
{
  "orderId": 123,
  "status": "Completed",
  "totalAmount": 99.99,
  "purchasedCourses": [
    {
      "courseId": 1,
      "title": "Complete C# Programming Bootcamp",
      "enrollmentStatus": "Active"
    }
  ]
}
```

</details>

---

### 👨‍🏫 Instructor Management

#### Create Instructor

<details>
<summary><code>POST</code> <code>/api/Instructors</code></summary>

##### Request (Form Data)

| Field            | Type   | Description                            |
| ---------------- | ------ | -------------------------------------- |
| `name`           | string | Instructor full name                   |
| `jopTitle`       | int    | Job title ID (e.g., 2 = DataScientist) |
| `about`          | string | Biography/description                  |
| `profilePicture` | file   | Profile image file                     |

##### Success Response `200 OK`

```json
{
  "statusCode": 200,
  "message": "Sarah Johnson Added Successfully!"
}
```

</details>

---

## ⚠️ Error Handling

The API implements a consistent error response format across all endpoints.

### Standard Error Response

```json
{
  "statusCode": 400,
  "message": "Error message describing what went wrong"
}
```

### Validation Error Response

```json
{
  "statusCode": 400,
  "message": "Validation Error",
  "errors": [
    "Field1 is required",
    "Field2 must be a valid email address",
    "Field3 must be at least 8 characters"
  ]
}
```

### HTTP Status Codes

| Code   | Status       | Description                             |
| ------ | ------------ | --------------------------------------- |
| 🟢 200 | OK           | Request succeeded                       |
| 🟢 204 | No Content   | Request succeeded, no content to return |
| 🟡 400 | Bad Request  | Invalid request format or parameters    |
| 🔴 401 | Unauthorized | Authentication required or failed       |
| 🔴 403 | Forbidden    | Insufficient permissions                |
| 🔴 404 | Not Found    | Resource not found                      |
| 🔴 500 | Server Error | Internal server error                   |

---

## 🛠️ Development

### Tech Stack

<div align="center">

| Category           | Technologies              |
| ------------------ | ------------------------- |
| **Framework**      | ASP.NET Core 9.0          |
| **ORM**            | Entity Framework Core 9.0 |
| **Database**       | SQL Server 2019+          |
| **Mapping**        | AutoMapper                |
| **Documentation**  | Swagger/Scaler/OpenAPI    |
| **Authentication** | JWT Bearer Tokens         |

</div>

### 🔒 Security Features

- **JWT Authentication** - Secure token-based authentication
- **Role-based Authorization** - Granular access control
- **Input Validation** - Comprehensive request validation
- **CORS Configuration** - Cross-origin security policies
- **Global Exception Handling** - Centralized error management
- **Password Hashing** - Secure password storage

### 🏗️ Project Structure

```
External/
├──Byway.API/
├──├── Controllers/        # API endpoints
├──├── Middleware/        # Custom middleware
├──└── appsettings.json   # Configuration
├──Byway.Infrastructure/
├──├── DbContext/      # Data access layer
├──├── Repositories/      # Data access layer
├──├── UnitOfWork/      # Data access layer
├──├── Migrations/        # EF Core migrations
├──├── Specification Evaluator/        # EF Core migrations
Core/
├──Byway.Domain/
├──├── Models/            # Domain models
├──├── Repositories.Contracts/            # Repository and UnitOfWork Contracts
├──├── BaseSpecifications/            # Specification DP
├──Byway.Application/
├──├── Services/          # Business logic
├──├── DTOs/              # Data transfer objects
├──├── Mapping/              # Datatypes Convertions
├──├── Specifications/              # Specification Implementation

```

---

<div align="center">

### 🌟 Star this repository if you find it helpful!

Made with ❤️ by the Muhammad Kamal Alsharif

</div>
