# Hospital Database System (HospitalDB)

A relational database management system designed for tracking medical personnel, patients, medical specializations, and patient diagnostic studies, built using **T-SQL (MS SQL Server)**.

## Overview

This project implements the database backend for a Hospital Management System. It utilizes a normalized relational model where basic personal details are abstracted into a core `Person` table, which is then referenced by specific roles such as `Patient` and `Doctor`. Additionally, it tracks diagnostic procedures/examinations via a `Study` table and provides pre-built SQL Views for streamlined reporting.

## Features

- **Normalized Database Design** — Standardized database architecture separating general personal data from specific role profiles.
- **Referential Integrity** — Enforces Primary Key (`IDENTITY`), Foreign Key constraints, and cascade relationships across all entities.
- **Medical Study Tracking** — Connects doctors and patients through diagnostic study records including dates and clinical findings.
- **Abstraction Views** — Includes pre-configured SQL Views (`PatientInfo`, `DoctorInfo`) to simplify common query operations without writing complex joins.
- **Automated Identifiers** — Uses auto-incrementing identity columns for seamless primary key generation.

## Tech Stack

| Technology | Purpose |
|------------|---------|
| MS SQL Server | Database engine |
| T-SQL (Transact-SQL) | DDL schema creation, DML data manipulation, and Views |
| Relational Modeling | Schema design and relational integrity |

## File Structure

```
HospitalDB/
├── 01_CreateDatabase.sql   # Creates the HospitalDB database
├── 02_CreateTables.sql     # Defines tables, primary keys, and foreign keys
├── 03_InsertData.sql       # Populates tables with sample data
├── 04_Views.sql            # Defines database views for simplified reporting
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
3. Execute the SQL scripts in the following exact order:

```bash
1. 01_CreateDatabase.sql
2. 02_CreateTables.sql
3. 03_InsertData.sql
4. 04_Views.sql
```

## Database Schema & Objects

### Tables
- **`Person`**: Stores general personal information (Name, Age, Gender, Phone).
- **`Patient`**: Links to `Person` and records patient specific data (Disease).
- **`Doctor`**: Links to `Person` and records doctor specific data (Specialization).
- **`Study`**: Intermediary record connecting a `Doctor` and a `Patient` with examination details (`StudyDate`, `Result`).

### Views
- **`PatientInfo`**: Joins `Person` and `Patient` to display complete patient profiles.
- **`DoctorInfo`**: Joins `Person` and `Doctor` to display doctor specialties.

## Author

**Anas Mohamed** — Software Engineering Intern at Millensys