# Hospital Patient Worklist API

A full-stack **Patient Worklist** web application for managing Patients, Doctors, and their medical Studies. Built with **ASP.NET Core 7.0 Web API** using the **Repository + Service Layer** pattern, **Entity Framework Core** with SQLite, and a **Bootstrap 5 + DataTables** frontend.

---

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [API Response Format](#api-response-format)
- [Frontend](#frontend)
- [Configuration](#configuration)
- [Seed Data](#seed-data)

---

## Features

- **Full CRUD** for Persons, Patients, Doctors, and Studies
- **Service Layer** between Controllers and Repositories for clean separation of concerns
- **Repository Pattern** with a generic `IRepository<T>` base interface
- **Entity/Feature-based folder structure** — everything for an entity lives in one folder
- **FluentValidation** for request validation
- **Custom Middleware** for exception handling and request logging
- **Swagger/OpenAPI** for API testing (Development mode)
- **Bootstrap 5 + DataTables** frontend with search, sort, and pagination
- **Modal-based** Create/Edit forms for all entities
- **Automatic database seeding** with sample data on first run

---

## Architecture

The application follows a **3-layer architecture**:

```
Controller  →  Service  →  Repository  →  DbContext
   │              │              │              │
   │         Business       Data Access     EF Core
   │          Logic          Logic          SQLite
   │
 HTTP Request/Response
```

| Layer | Responsibility |
|---|---|
| **Controller** | Handles HTTP requests, model validation, returns responses. No business logic. |
| **Service** | Contains business logic, orchestrates operations, DTO mapping, validation rules. |
| **Repository** | Handles all database operations via Entity Framework Core. |
| **DbContext** | EF Core database context with entity configurations. |

---

## Tech Stack

| Component | Technology |
|---|---|
| **Backend** | ASP.NET Core 7.0 Web API (C#) |
| **ORM** | Entity Framework Core 7.0.20 |
| **Database** | SQLite (via `Microsoft.EntityFrameworkCore.Sqlite`) |
| **Validation** | FluentValidation 11.x |
| **API Docs** | Swashbuckle / Swagger 6.5.0 |
| **Frontend** | HTML5, CSS3, Bootstrap 5.3.2, DataTables.js 1.13.7 |
| **JS Library** | jQuery 3.7.1 |
| **Icons** | Bootstrap Icons 1.11.3 |

---

## Project Structure

```
HospitalAPI/
│
├── Person/                          # Person entity (feature-based)
│   ├── PersonModel.cs               # Entity model
│   ├── PersonDTO.cs                 # Data Transfer Objects
│   ├── IPersonRepository.cs         # Repository interface
│   ├── PersonRepository.cs          # Repository implementation
│   ├── IPersonService.cs            # Service interface
│   └── PersonService.cs             # Service implementation
│
├── Patient/                         # Patient entity
│   ├── PatientModel.cs
│   ├── PatientDTO.cs                # PatientDTO, PatientWithPersonDTO, CreatePatientRequest
│   ├── IPatientRepository.cs
│   ├── PatientRepository.cs
│   ├── IPatientService.cs
│   └── PatientService.cs
│
├── Doctor/                          # Doctor entity
│   ├── DoctorModel.cs
│   ├── DoctorDTO.cs                 # DoctorDTO, DoctorWithPersonDTO, CreateDoctorRequest
│   ├── IDoctorRepository.cs
│   ├── DoctorRepository.cs
│   ├── IDoctorService.cs
│   └── DoctorService.cs
│
├── Study/                           # Study entity
│   ├── StudyModel.cs
│   ├── StudyDTO.cs                  # StudyDTO, StudyDetailsDTO, CreateStudyRequest
│   ├── IStudyRepository.cs
│   ├── StudyRepository.cs
│   ├── IStudyService.cs
│   └── StudyService.cs
│
├── Shared/                          # Shared / Cross-cutting concerns
│   ├── ApiResponse.cs               # Generic API response wrapper
│   └── IRepository.cs               # Generic repository interface
│
├── Validators/                      # FluentValidation validators
│   └── Validator.cs                 # All DTO validators
│
├── Controllers/                     # API Controllers (thin — delegate to Services)
│   ├── PersonsController.cs
│   ├── PatientsController.cs
│   ├── DoctorsController.cs
│   └── StudiesController.cs
│
├── Data/                            # Database configuration
│   ├── AppDbContext.cs              # EF Core DbContext
│   └── DbInitializer.cs            # Database seeder
│
├── Middleware/                       # Custom middleware
│   ├── ExceptionHandlingMiddleware.cs
│   └── RequestLoggingMiddleware.cs
│
├── wwwroot/                         # Static files (Frontend)
│   ├── index.html                   # Main SPA page
│   ├── script.js                    # JavaScript (AJAX, DataTables, modals)
│   └── style.css                    # Custom styles
│
├── Program.cs                       # Application entry point & DI configuration
├── appsettings.json                 # Configuration
└── HospitalAPI.csproj               # Project file
```

---

## Database Schema

### Entity Relationship Diagram

```
┌──────────────┐       ┌──────────────────┐
│   Person     │       │     Patient      │
├──────────────┤       ├──────────────────┤
│ PersonId (PK)│◄──1:1─│ PatientId (PK)   │
│ FirstName    │       │ PersonId (FK)    │
│ LastName     │       │ MRN              │
│ DateOfBirth  │       │ Status           │
│ Gender       │       └────────┬─────────┘
│ Phone        │                │
│ Email        │                │ 1:N
└──────┬───────┘                │
       │                        │
       │ 1:1                    │
       │                        ▼
       │               ┌──────────────────┐
       │               │     Study        │
       │               ├──────────────────┤
       │               │ StudyId (PK)     │
       │               │ PatientId (FK)   │
       │               │ DoctorId (FK)    │
       │               │ Modality         │
       │               │ StudyDate        │
       │               │ Status           │
       │               └────────┬─────────┘
       │                        │
       │ 1:N                    │ N:1
       ▼                        │
┌──────────────┐       ┌────────┴─────────┐
│   Doctor     │       │                  │
├──────────────┤       │                  │
│ DoctorId (PK)│◄──────┘                  │
│ PersonId (FK)│                          │
│ Specialty    │                          │
└──────────────┘                          │
                                          │
                                          │
```

### Tables

| Table | Columns | Description |
|---|---|---|
| **Persons** | PersonId, FirstName, LastName, DateOfBirth, Gender, Phone, Email | Base person information |
| **Patients** | PatientId, PersonId (FK), MRN, Status | Patient record linked to a Person |
| **Doctors** | DoctorId, PersonId (FK), Specialty | Doctor record linked to a Person |
| **Studies** | StudyId, PatientId (FK), DoctorId (FK), Modality, StudyDate, Status | Medical study linking a Patient and Doctor |

### Relationships

- **Person ↔ Patient**: One-to-One (each Patient has one Person, each Person can be one Patient)
- **Person ↔ Doctor**: One-to-One (each Doctor has one Person, each Person can be one Doctor)
- **Patient ↔ Study**: One-to-Many (a Patient can have many Studies)
- **Doctor ↔ Study**: One-to-Many (a Doctor can have many Studies)

---

## Getting Started

### Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later
- No SQL Server or external database required — uses **SQLite** (auto-created)

### Installation

```bash
# Clone the repository
git clone https://github.com/Anas-Mohamed-Abdelghany/Millensys-Internship.git
cd Millensys-Internship

# Restore dependencies
dotnet restore

# Build the project
dotnet build
```

### Running the Application

```bash
dotnet run
```

The application will start and automatically:
1. Create the SQLite database (`HospitalDB.db`)
2. Seed it with sample data (4 persons, 2 patients, 2 doctors, 2 studies)

### Access

| URL | Description |
|---|---|
| `https://localhost:5001` | Frontend (Patient Worklist) |
| `http://localhost:5000` | Frontend (HTTP) |
| `https://localhost:5001/swagger` | Swagger UI (API testing) |
| `http://localhost:5000/swagger` | Swagger UI (HTTP) |

---

## API Endpoints

### Persons

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/persons` | Get all persons |
| `GET` | `/api/persons/{id}` | Get person by ID |
| `POST` | `/api/persons` | Create a new person |
| `PUT` | `/api/persons/{id}` | Update a person |
| `DELETE` | `/api/persons/{id}` | Delete a person |

**POST /api/persons — Request Body:**
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "dateOfBirth": "1990-01-15",
  "gender": "Male",
  "phone": "01012345678",
  "email": "john.doe@email.com"
}
```

---

### Patients

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/patients` | Get all patients (with person info) |
| `GET` | `/api/patients/{id}` | Get patient by ID |
| `GET` | `/api/patients/status/{status}` | Filter patients by status |
| `POST` | `/api/patients` | Create patient (+ person in one call) |
| `PUT` | `/api/patients/{id}` | Update patient (+ person) |
| `DELETE` | `/api/patients/{id}` | Delete patient |

**POST /api/patients — Request Body:**
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "dateOfBirth": "1990-01-15",
  "gender": "Male",
  "phone": "01012345678",
  "email": "john.doe@email.com",
  "mrn": "MRN-003",
  "status": "Active"
}
```

**GET /api/patients — Response:**
```json
{
  "success": true,
  "message": "Success",
  "data": [
    {
      "patientId": 1,
      "firstName": "Ahmed",
      "lastName": "Ali",
      "dateOfBirth": "2001-05-15T00:00:00",
      "gender": "Male",
      "phone": "01011111111",
      "email": "ahmed.ali@email.com",
      "mrn": "MRN-001",
      "status": "Active"
    }
  ],
  "errors": []
}
```

---

### Doctors

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/doctors` | Get all doctors (with person info) |
| `GET` | `/api/doctors/{id}` | Get doctor by ID |
| `GET` | `/api/doctors/specialty/{specialty}` | Filter doctors by specialty |
| `POST` | `/api/doctors` | Create doctor (+ person in one call) |
| `PUT` | `/api/doctors/{id}` | Update doctor (+ person) |
| `DELETE` | `/api/doctors/{id}` | Delete doctor |

**POST /api/doctors — Request Body:**
```json
{
  "firstName": "John",
  "lastName": "Smith",
  "dateOfBirth": "1980-06-20",
  "gender": "Male",
  "phone": "01098765432",
  "email": "john.smith@email.com",
  "specialty": "Cardiology"
}
```

---

### Studies

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/studies` | Get all studies (with patient & doctor names) |
| `GET` | `/api/studies/{id}` | Get study by ID |
| `GET` | `/api/studies/patient/{patientId}` | Filter studies by patient |
| `GET` | `/api/studies/doctor/{doctorId}` | Filter studies by doctor |
| `POST` | `/api/studies` | Create a new study |
| `PUT` | `/api/studies/{id}` | Update a study |
| `DELETE` | `/api/studies/{id}` | Delete a study |

**POST /api/studies — Request Body:**
```json
{
  "patientId": 1,
  "doctorId": 1,
  "modality": "CT Scan",
  "studyDate": "2026-08-10",
  "status": "Completed"
}
```

**GET /api/studies — Response:**
```json
{
  "success": true,
  "message": "Success",
  "data": [
    {
      "studyId": 1,
      "patientId": 1,
      "doctorId": 1,
      "patientName": "Ahmed Ali",
      "doctorName": "Omar Hassan",
      "modality": "X-Ray",
      "studyDate": "2026-07-20T00:00:00",
      "status": "Completed"
    }
  ],
  "errors": []
}
```

---

## API Response Format

All API endpoints return a consistent response wrapper:

```json
{
  "success": true | false,
  "message": "Success" | "Error message",
  "data": { ... } | [ ... ] | null,
  "errors": [] | ["Error 1", "Error 2"]
}
```

### Success Response
```json
{
  "success": true,
  "message": "Patient created successfully",
  "data": { "patientId": 3, "firstName": "John", ... },
  "errors": []
}
```

### Error Response
```json
{
  "success": false,
  "message": "Validation failed",
  "data": null,
  "errors": ["First name is required", "MRN is required"]
}
```

---

## Frontend

The frontend is a single-page application served from `wwwroot/`:

| File | Purpose |
|---|---|
| `index.html` | Main page with 3 tabs: Studies Worklist, Patients, Doctors |
| `script.js` | JavaScript handling AJAX calls, DataTables initialization, modal forms, CRUD operations |
| `style.css` | Custom styling (gradients, card effects, responsive layout) |

### Features
- **DataTables** for search, sort, and pagination on all tables
- **Bootstrap 5 modals** for Create/Edit forms
- **Tab-based navigation** between Studies, Patients, and Doctors
- **Status badges** with color coding (Active, Completed, Pending, etc.)
- **Edit/Delete buttons** on each row
- **Toast notifications** for success/error feedback
- **Responsive design** — works on desktop and mobile

---

## Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=HospitalDB.db"
  }
}
```

### Switching to SQL Server

To use SQL Server instead of SQLite:

1. Install packages:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.20
   ```

2. Update `Program.cs`:
   ```csharp
   builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   ```

3. Update `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

---

## Seed Data

The database is automatically seeded on first run with:

| Entity | Records | Details |
|---|---|---|
| **Persons** | 4 | Ahmed Ali, Sara Mohamed, Omar Hassan, Mona Adel |
| **Patients** | 2 | MRN-001 (Active), MRN-002 (Active) |
| **Doctors** | 2 | Cardiology, Neurology |
| **Studies** | 2 | X-Ray (Completed), MRI (Pending) |

---

## License

This project is for educational purposes.
