<div align="center">

# 🏥 Millensys Healthcare Technology — Internship Projects

A collection of projects completed during the **Software Engineering Internship** at **Millensys Healthcare IT Solutions**.

Covering **Web Development**, **Database Design**, **API Development**, and **.NET Backend Engineering**.

![Millensys Logo](logo.png)

![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)

<br>

</div>

---

## 📋 Projects Overview

| # | Project | Description | Tech Stack |
|---|---------|-------------|------------|
| 1 | [Personal Portfolio](#1-personal-portfolio) | Responsive intern portfolio website | HTML5, CSS3 |
| 2 | [Patient Management System](#2-patient-management-system) | Client-side CRUD patient records app | HTML5, CSS3, JavaScript, Bootstrap 5 |
| 3 | [Hospital Database System](#3-hospital-database-system) | SQL Server schema + .NET console app | SQL Server, C#, .NET |
| 4 | [HospitalDB](#4-hospitaldb) | SQL Server database with T-SQL views/procs/functions | SQL Server, T-SQL |
| 5 | [Hospital Appointment System](#5-hospital-appointment-system) | C# OOP console app for appointment management | C#, .NET Console |
| 6 | [Hospital Patient Worklist API](#6-hospital-patient-worklist-api) | Full-stack REST API with frontend | ASP.NET Core 7.0, EF Core, SQLite, Bootstrap 5 |

---

## 1. Personal Portfolio

<div align="center">

![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat&logo=css3&logoColor=white)

</div>

A **responsive personal portfolio website** showcasing the intern profile, technical skills, projects, and achievements at Millensys Healthcare IT Solutions.

### Features

- Responsive design with mobile-friendly layout
- Card-based UI with smooth hover animations
- Interactive skill tags with hover effects
- Clean typography using Inter font (Google Fonts)
- Gradient background with elevated card components

### Sections

| Section | Content |
|---------|---------|
| Header | Logo and professional title |
| About Me | Technical summary and skill tags |
| Education | Academic background and GPA |
| Projects | Portfolio of 8+ AI/ML and full-stack projects |
| Programs & Competitions | Hackathons, certifications, and awards |

### What I Learned

- Semantic HTML5 structure and accessibility
- CSS3 Flexbox layout and responsive design
- Modern UI patterns (cards, gradients, shadows)
- Mobile-first design principles

### How to Run

```bash
# Simply open index.html in any browser
start index.html
```

**Directory:** [`1st Task/`](./1st%20Task/)

---

## 2. Patient Management System

<div align="center">

![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat&logo=javascript&logoColor=black)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=flat&logo=bootstrap&logoColor=white)

</div>

A **client-side CRUD application** for managing patient records with form validation, inline editing, and real-time table updates — all without a backend.

### Features

| Operation | Description |
|-----------|-------------|
| **Create** | Register new patients with name, age, gender, and condition |
| **Read** | View all patient records in a responsive table |
| **Update** | Edit existing patient information inline |
| **Delete** | Remove patient records with confirmation dialog |

### Additional Features

- Form validation with Bootstrap's built-in validation
- Auto-incrementing patient IDs
- Real-time UI updates without page reload
- Responsive layout for desktop and mobile

### What I Learned

- DOM manipulation and event handling in vanilla JavaScript
- Bootstrap 5 components (forms, tables, modals, badges)
- Client-side form validation techniques
- State management in a single-page application
- CRUD operations without a backend

### How to Run

```bash
# Simply open index.html in any browser
start index.html
```

**Directory:** [`2nd Task/`](./2nd%20Task/)

---

## 3. Hospital Database System

<div align="center">

![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)

</div>

A **complete hospital management database** featuring SQL Server schema design with views, stored procedures, and functions, alongside a **C# .NET console application** demonstrating object-oriented entity modeling.

### Database Schema

```
┌──────────────┐       ┌──────────────┐
│    Person    │       │   Patient    │
├──────────────┤       ├──────────────┤
│ PersonID (PK)│◀──┐   │ PatientID(PK)│
│ FullName     │   └──▶│ PersonID (FK)│
│ Age          │       │ Disease      │
│ Gender       │       └──────────────┘
│ Phone        │
└──────────────┘       ┌──────────────┐
       │               │   Doctor     │
       │               ├──────────────┤
       │               │ DoctorID(PK) │
       └──────────────▶│ PersonID (FK)│
                       │ Specialization│
                       └──────────────┘
                              │
                       ┌──────────────┐
                       │    Study     │
                       ├──────────────┤
                       │ StudyID (PK) │
                       │ DoctorID(FK) │
                       │ PatientID(FK)│
                       │ StudyDate    │
                       │ Result       │
                       └──────────────┘
```

### SQL Components

| Type | Components |
|------|------------|
| **Views** | `PatientInfo`, `DoctorInfo` |
| **Procedures** | `GetPatientsByDisease`, `AddPatient` |
| **Functions** | `GetPatientCount`, `GetDoctorSpecialization`, `GetPatientStudies` |

### .NET Classes

| Class | Properties |
|-------|------------|
| `Patient` | PatientID, Name, Disease |
| `Doctor` | DoctorID, Name, Specialization |
| `Study` | StudyID, StudyType, Result |
| `Appointment` | Patient, Doctor, Date, Branch, StudyType, Notes |

### What I Learned

- Relational database design and normalization
- SQL views, stored procedures, and scalar/table-valued functions
- Entity relationships (1:1, 1:N, N:M)
- C# object-oriented programming (classes, encapsulation, composition)
- Entity modeling and data access patterns

### How to Run

```bash
# SQL Server — Execute scripts 01-07 in order using SSMS

# .NET Console Application
cd "3rd Task/.Net Task"
dotnet run
```

**Directory:** [`3rd Task/`](./3rd%20Task/)

---

## 4. HospitalDB

<div align="center">

![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)
![T-SQL](https://img.shields.io/badge/T--SQL-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)

</div>

A **comprehensive relational database management system** for tracking medical personnel, patients, medical specializations, and patient diagnostic studies, built using **T-SQL (MS SQL Server)** with full database programmability including **Views**, **Stored Procedures**, and **Functions**.

### Database Architecture

```
                       ┌──────────────┐
                       │    Person    │
                       ├──────────────┤
                       │ PersonID(PK) │
                       │ FullName     │
                       │ Age          │
                       │ Gender       │
                       │ Phone        │
                       └──────┬───────┘
                              │
               ┌──────────────┴──────────────┐
             1 │                             │ 1
               ▼ *                           ▼ *
        ┌──────────────┐              ┌──────────────┐
        │    Doctor    │              │   Patient    │
        ├──────────────┤              ├──────────────┤
        │ DoctorID(PK) │              │ PatientID(PK)│
        │ PersonID(FK) │              │ PersonID(FK) │
        │Specialization│              │ Disease      │
        └──────┬───────┘              └──────┬───────┘
               │ 1                           │ 1
               │                             │
               └──────────────┬──────────────┘
                              │ *
                       ┌──────▼───────┐
                       │    Study     │
                       ├──────────────┤
                       │ StudyID(PK)  │
                       │ DoctorID(FK) │
                       │ PatientID(FK)│
                       │ StudyDate    │
                       │ Result       │
                       └──────────────┘
```

### SQL Components

| Type | Components |
|------|------------|
| **Views** | `PatientInfo`, `DoctorInfo` |
| **Procedures** | `GetPatientsByDisease`, `AddPatient` |
| **Functions** | `GetPatientCount`, `GetDoctorSpecialization`, `GetPatientStudies` |

### What I Learned

- Normalized database design with referential integrity
- SQL Views for data abstraction and simplified reporting
- Stored Procedures for parameterized business logic
- Scalar and Table-Valued Functions for reusable calculations
- Verification test suite for database objects

### How to Run

1. Open **SQL Server Management Studio (SSMS)** or **Azure Data Studio**.
2. Connect to your local or remote **SQL Server Instance**.
3. Execute the SQL scripts sequentially in the following exact order:

```bash
1. 01_CreateDatabase.sql
2. 02_CreateTables.sql
3. 03_InsertData.sql
4. 04_Views.sql
5. 05_Procedures.sql
6. 06_Functions.sql
7. 07_TestQueries.sql
```

**Directory:** [`4th Task/`](./4th%20Task/)

---

## 5. Hospital Appointment System

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)

</div>

An **Object-Oriented C# console application** designed to model and manage medical appointments, diagnostic studies, patients, and doctors using fundamental **Object-Oriented Programming (OOP)** principles.

### Class Relationship Diagram

```
       ┌───────────────────┐               ┌───────────────────┐
       │      Patient      │               │      Doctor       │
       ├───────────────────┤               ├───────────────────┤
       │ - patientID: int  │               │ - doctorID: int   │
       │ - name: string    │               │ - name: string    │
       │ - disease: string │               │ - specialization  │
       └─────────▲─────────┘               └─────────▲─────────┘
                 │ 1                                 │ 1
                 │         ┌───────────┐             │
                 └─────────┤Appointment├─────────────┘
                           ├───────────┤
                           │ - date    │
                           │ - branch  │
                           │ - study   │
                           │ - reason  │
                           └─────▲─────┘
                                 │ 1
                           ┌─────┴─────┐
                           │   Study   │
                           ├───────────┤
                           │ - studyID │
                           │ - type    │
                           │ - result  │
                           └───────────┘
```

### OOP Concepts Demonstrated

| Concept | Description |
|---------|-------------|
| **Encapsulation** | Private backing fields with explicit getter/setter methods |
| **Aggregation** | `Appointment` class integrates `Patient` and `Doctor` objects |
| **Separation of Concerns** | Separate `.cs` files for each class entity |

### What I Learned

- C# object-oriented programming (encapsulation, aggregation)
- Domain object modeling for healthcare entities
- Console application formatting and structured output
- Decoupled architecture with modular class organization

### How to Run

```bash
cd "5th Task"
dotnet run
```

**Directory:** [`5th Task/`](./5th%20Task/)

---

## 6. Hospital Patient Worklist API

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET%207.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=flat&logo=sqlite&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=flat&logo=bootstrap&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat&logo=swagger&logoColor=black)

</div>

A **full-stack Patient Worklist** web application for managing Patients, Doctors, and their medical Studies. Built with **ASP.NET Core 7.0 Web API** using the **Repository + Service Layer** pattern, **Entity Framework Core** with SQLite, and a **Bootstrap 5 + DataTables** frontend.

### Architecture

```
Controller  →  Service  →  Repository  →  DbContext
   │              │              │              │
   │         Business       Data Access     EF Core
   │          Logic          Logic          SQLite
   │
 HTTP Request/Response
```

### Features

- **Full CRUD** for Persons, Patients, Doctors, and Studies
- **3-Layer Architecture** — Controller, Service, Repository
- **Repository Pattern** with generic `IRepository<T>` base interface
- **FluentValidation** for request validation
- **Custom Middleware** for exception handling and request logging
- **Swagger/OpenAPI** for API testing (Development mode)
- **Bootstrap 5 + DataTables** frontend with search, sort, and pagination
- **Modal-based** Create/Edit forms for all entities
- **Automatic database seeding** with sample data on first run

### API Endpoints

| Entity | Endpoints |
|--------|-----------|
| **Persons** | `GET /api/persons`, `GET /api/persons/{id}`, `POST`, `PUT`, `DELETE` |
| **Patients** | `GET /api/patients`, `GET /api/patients/{id}`, `GET /api/patients/status/{status}`, `POST`, `PUT`, `DELETE` |
| **Doctors** | `GET /api/doctors`, `GET /api/doctors/{id}`, `GET /api/doctors/specialty/{specialty}`, `POST`, `PUT`, `DELETE` |
| **Studies** | `GET /api/studies`, `GET /api/studies/{id}`, `GET /api/studies/patient/{patientId}`, `POST`, `PUT`, `DELETE` |

### Tech Stack

| Component | Technology |
|-----------|------------|
| Backend | ASP.NET Core 7.0 Web API (C#) |
| ORM | Entity Framework Core 7.0.20 |
| Database | SQLite (auto-created) |
| Validation | FluentValidation 11.x |
| API Docs | Swashbuckle / Swagger 6.5.0 |
| Frontend | HTML5, CSS3, Bootstrap 5.3.2, DataTables.js |
| JS Library | jQuery 3.7.1 |

### What I Learned

- **ASP.NET Core Web API** development and RESTful design
- **Repository + Service Layer** architecture pattern
- **Entity Framework Core** with Code-First approach
- **Dependency Injection** and Scoped lifetime management
- **FluentValidation** for clean request validation
- **Custom Middleware** for cross-cutting concerns (logging, exception handling)
- **Swagger/OpenAPI** for API documentation
- **Database Seeding** and migration strategies
- **AJAX** and **DataTables.js** for dynamic frontend rendering
- **Modal-based forms** for CRUD operations

### How to Run

```bash
cd HospitalAPI

# Restore and run
dotnet restore
dotnet run

# Access
# Frontend: https://localhost:5001
# Swagger:  https://localhost:5001/swagger
```

**Directory:** [`HospitalAPI/`](./HospitalAPI/)

---

## 🛠️ Technologies Used

<div align="center">

| Category | Technologies |
|----------|-------------|
| **Frontend** | HTML5, CSS3, JavaScript (ES6+), Bootstrap 5, DataTables.js, jQuery |
| **Backend** | ASP.NET Core 7.0, C#, .NET 7.0 |
| **Database** | SQL Server, SQLite, Entity Framework Core 7.0 |
| **Tools** | Swagger/OpenAPI, FluentValidation, Git |
| **Patterns** | Repository Pattern, Service Layer, 3-Layer Architecture, DI |

</div>

---

## 📁 Repository Structure

```
Millensys/
│
├── 1st Task/                    # Personal Portfolio Website
│   ├── index.html
│   ├── style.css
│   └── image.png
│
├── 2nd Task/                    # Patient Management System
│   ├── index.html
│   ├── style.css
│   └── script.js
│
├── 3rd Task/                    # Hospital Database System
│   ├── 01_CreateDatabase.sql
│   ├── 02_CreateTables.sql
│   ├── 03_InsertData.sql
│   ├── 04_Views.sql
│   ├── 05_Procedures.sql
│   ├── 06_Functions.sql
│   ├── 07_TestQueries.sql
│   └── .Net Task/
│       ├── Main.cs
│       ├── Patient.cs
│       ├── Doctor.cs
│       ├── Study.cs
│       └── Appointment.cs
│
├── HospitalAPI/                 # Hospital Patient Worklist API
│   ├── Controllers/
│   ├── Person/
│   ├── Patient/
│   ├── Doctor/
│   ├── Study/
│   ├── Shared/
│   ├── Validators/
│   ├── Data/
│   ├── Middleware/
│   ├── wwwroot/
│   └── Program.cs
│
├── 4th Task/                    # HospitalDB (SQL Server T-SQL)
│   ├── 01_CreateDatabase.sql
│   ├── 02_CreateTables.sql
│   ├── 03_InsertData.sql
│   ├── 04_Views.sql
│   ├── 05_Procedures.sql
│   ├── 06_Functions.sql
│   ├── 07_TestQueries.sql
│   └── README.md
│
├── 5th Task/                    # Hospital Appointment System (C# OOP)
│   ├── Appointment.cs
│   ├── Doctor.cs
│   ├── Main.cs
│   ├── Patient.cs
│   ├── Study.cs
│   └── README.md
│
└── README.md                    # This file
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later (for Projects 3, 4, & 6)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (for Projects 3 & 5)
- A modern web browser (for Projects 1 & 2)

### Quick Start

```bash
# Clone the repository
git clone https://github.com/your-username/Millensys.git
cd Millensys

# Project 1 — Open portfolio in browser
start "1st Task/index.html"

# Project 2 — Open patient management in browser
start "2nd Task/index.html"

# Project 3 — Run .NET console app
cd "3rd Task/.Net Task"
dotnet run

# Project 4 — Run HospitalDB (4th Task)
cd ../../"4th Task"

# Execute SQL scripts 01-07 in SSMS

# Project 5 — Run Hospital Appointment System (5th Task)
cd ../"5th Task"
dotnet run

# Project 6 — Run API server
cd ../HospitalAPI
dotnet run
```

---

## 👤 Author

**Anas Mohamed** — Software Engineering Intern at Millensys Healthcare IT Solutions

---

<div align="center">

**Built with dedication during the Millensys Internship Program**

</div>
