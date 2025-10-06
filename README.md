# Byway Course Management API

A comprehensive course management system built with ASP.NET 9.0, featuring robust authentication, course management, cart functionality, and secure checkout processes.

## Table of Contents
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Admin Credentials](#admin-credentials)
- [Authentication](#authentication)
  - [Register](#register)
  - [Login](#login)
  - [Google Authentication](#google-authentication)
- [Courses](#courses)
- [Cart](#cart)
- [Checkout](#checkout)
- [Instructors](#instructors)
- [Error Handling](#error-handling)

## Getting Started

### Prerequisites
- .NET 9.0
- SQL Server
- Visual Studio 2022 or later

### Admin Credentials
Use these credentials to access admin features:Email: admin@byway.com
Password: P@ssw0rd
## Authentication

### Register
POST `/api/Account/register`

Register a new user account.

**Request Body:**{
  "firstName": "string", // Min length: 3
  "lastName": "string",  // Min length: 3
  "phone": "string",     // Valid phone number
  "email": "string",     // Valid email address
  "password": "string"   // Must have: 1 Uppercase, 1 Lowercase, 1 number, 1 special character, min 6 chars
}
**Responses:**
- 200: Successful registration
- 400: Validation errors

### Login
POST `/api/Account/login`

**Request Body:**{
  "email": "string",
  "password": "string"
}
**Responses:**
- 200: Successfully logged in with JWT token
- 400: Invalid credentials

### Google Authentication
POST `/api/Account/google-auth`

Login or register using Google authentication.

**Request Body:**{
  "idToken": "string"
}
## Courses

### List Courses
GET `/api/Courses`

**Query Parameters:**
- pageSize (default: 20)
- pageIndex (default: 1)
- search
- category
- instructor
- minPrice
- maxPrice
- sort

**Responses:**
- 200: List of courses
- 204: No courses found

### Get Course Details
GET `/api/Courses/{id}`

**Responses:**
- 200: Course details
- 404: Course not found

## Cart

### Get Cart
GET `/api/Cart?id={cartId}`

**Responses:**
- 200: Cart details
- 503: Service unavailable

### Update Cart
PUT `/api/Cart`

**Request Body:**{
  "id": "string",
  "items": [
    {
      "courseId": 0
    }
  ]
}
**Responses:**
- 200: Updated cart
- 503: Service unavailable

### Delete Cart
DELETE `/api/Cart?id={cartId}`

**Responses:**
- 200: Cart deleted
- 400: Bad request

## Checkout

### Get Checkout Summary
GET `/api/Checkout/summary/{cartId}`

**Responses:**
- 200: Checkout summary
- 404: Cart not found

### Process Checkout
POST `/api/Checkout/process/{cartId}`
[Requires Authentication]

**Request Body:**{
  "paymentMethod": "string",
  "paymentTransactionId": "string"
}
**Responses:**
- 200: Successful checkout
- 400: Invalid request
- 401: Unauthorized

## Instructors

### List Instructors
GET `/api/Instructors`

**Query Parameters:**
- pageSize (default: 20)
- pageIndex (default: 1)
- search

**Responses:**
- 200: List of instructors
- 204: No instructors found

### Create Instructor
POST `/api/Instructors`
[Requires Admin Role]

**Request Body (Form Data):**name: string (min length: 5)
jopTitle: number (1-12)
about: string (min length: 10)
profilePicture: file
**Responses:**
- 200: Instructor created
- 400: Invalid request
- 401: Unauthorized
- 403: Forbidden (non-admin)

## Error Handling

The API implements global error handling with consistent response formats:

### Standard Error Response{
  "statusCode": number,
  "message": "string"
}
### Validation Error Response{
  "statusCode": 400,
  "message": "Validation Error",
  "errors": [
    "Error message 1",
    "Error message 2"
  ]
}
### Status Codes
- 200: Success
- 204: No Content
- 400: Bad Request
- 401: Unauthorized
- 403: Forbidden
- 404: Not Found
- 500: Internal Server Error
- 503: Service Unavailable

## Security Features
- JWT Authentication
- Role-based Authorization
- Input Validation
- CORS Support
- Model State Validation
- Global Exception Handling