# Hospital Database System (HospitalDB)

A comprehensive relational database management system designed for tracking medical personnel, patients, medical specializations, and patient diagnostic studies, built using **T-SQL (MS SQL Server)** with full database programmability including **Views**, **Stored Procedures**, and **Functions**.

## Overview

This project implements the database backend for a Hospital Management System. It utilizes a normalized relational model where basic personal details are abstracted into a core `Person` table, referenced by specific roles such as `Patient` and `Doctor`. Diagnostic procedures/examinations are tracked via a `Study` table. The system includes an abstraction layer built with pre-configured SQL Views, Stored Procedures for modular business logic, and custom User-Defined Functions (UDFs).

## Features

- **Normalized Database Design** — Standardized database architecture separating general personal data from specific role profiles.
- **Referential Integrity** — Enforces Primary Key (`IDENTITY`), Foreign Key constraints, and cascade relationships across all entities.
- **Medical Study Tracking** — Connects doctors and patients through diagnostic study records including dates and clinical findings.
- **Abstraction Views** — Pre-configured views (`PatientInfo`, `DoctorInfo`) to simplify common query operations without writing complex joins.
- **Stored Procedures** — Encapsulated routine actions for parameter-based patient filtering and safe record insertion.
- **User-Defined Functions (UDFs)** — Custom Scalar and Table-Valued Functions (TVF) for real-time statistical aggregation and patient history retrieval.
- **Verification Test Suite** — Includes a dedicated testing script to validate views, procedures, and functions against sample data.

## Tech Stack

| Technology | Purpose |
|------------|---------|
| MS SQL Server | Database engine |
| T-SQL (Transact-SQL) | DDL schema creation, DML data manipulation |
| Views | Data abstraction and simplified reporting |
| Stored Procedures | Parameterized business logic and data insertion |
| Functions (Scalar & TVF) | Reusable calculation logic and inline dataset return |

## File Structure

```
HospitalDB/
├── 01_CreateDatabase.sql   # Creates the HospitalDB database
├── 02_CreateTables.sql     # Defines tables, primary keys, and foreign keys
├── 03_InsertData.sql       # Populates tables with sample initial data
├── 04_Views.sql            # Defines database views for reporting
├── 05_Procedures.sql       # Stored procedures for querying and insertion
├── 06_Functions.sql        # Scalar and Table-Valued User-Defined Functions
├── 07_TestQueries.sql      # Test suite executing views, procedures, and functions
└── README.md               # Documentation
```

## Database Architecture

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

## How to Run

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

---

## Database Schema & Objects

### 1. Tables
- **`Person`**: Stores base personal details (Name, Age, Gender, Phone).
- **`Patient`**: Maps to `Person` and records patient-specific diagnostic details (`Disease`).
- **`Doctor`**: Maps to `Person` and records doctor credentials (`Specialization`).
- **`Study`**: Intermediary entity linking `Doctor` and `Patient` records with study logs (`StudyDate`, `Result`).

### 2. Views
- **`PatientInfo`**: Joins `Person` and `Patient` to display full patient profiles.
- **`DoctorInfo`**: Joins `Person` and `Doctor` to list available medical staff and specialties.

### 3. Stored Procedures
- **`GetPatientsByDisease (@Disease)`**: Filters and returns patient names diagnosed with a specific medical condition.
- **`AddPatient (@PersonID, @Disease)`**: Registers an existing person record as a patient.

### 4. User-Defined Functions (UDFs)
- **`GetPatientCount()`** *(Scalar)*: Returns the total count of registered patients.
- **`GetDoctorSpecialization(@DoctorID)`** *(Scalar)*: Returns the specialization string for a specific doctor ID.
- **`GetPatientStudies(@PatientID)`** *(Table-Valued)*: Returns a tabular set of study records (Date, Results) associated with a specific patient.

---

## Usage Examples

Below are query samples demonstrating how to invoke the stored procedures, functions, and views (as executed in `07_TestQueries.sql`):

```sql
-- Querying Abstraction Views
SELECT * FROM PatientInfo;
SELECT * FROM DoctorInfo;

-- Executing Stored Procedures
EXEC GetPatientsByDisease 'Diabetes';
EXEC AddPatient 3, 'Flu';

-- Calling Scalar & Table-Valued Functions
SELECT dbo.GetPatientCount();
SELECT dbo.GetDoctorSpecialization(1);
SELECT * FROM dbo.GetPatientStudies(1);
```

## Author

**Anas Mohamed** — Software Engineering Intern at Millensys