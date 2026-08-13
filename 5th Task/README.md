# Hospital Appointment System (C# Console Application)

An Object-Oriented C# console application designed to model and manage medical appointments, diagnostic studies, patients, and doctors using fundamental **Object-Oriented Programming (OOP)** principles.

## Overview

This project provides a clean object-oriented domain model for managing hospital appointments. It demonstrates key software design concepts such as **Encapsulation**, **Aggregation**, and **Domain Object Relations** by modeling real-world medical entities (`Patient`, `Doctor`, `Study`, `Appointment`) and offering structured output formatting for appointment management.

## Features

- **Strict Encapsulation** — All model classes utilize private backing fields with explicit getter and setter methods to control data access and mutation.
- **Entity Aggregation** — The `Appointment` class integrates instance objects of `Patient` and `Doctor` along with appointment scheduling metadata.
- **Diagnostic Study Tracking** — Includes medical examination objects (`Study`) detailing study types and clinical findings.
- **Formatted Terminal Display** — Built-in `PrintAppointment()` method provides clean, readable summary reports for scheduled appointments.
- **Decoupled Architecture** — Separate C# source files for each class entity to maintain clean code organization and modularity.

## Tech Stack

| Technology | Purpose |
|------------|---------|
| C# (.NET) | Core programming language |
| .NET Console App | Runtime platform and application output |
| OOP Architecture | Class encapsulation, association, and object creation |

## File Structure

```
HospitalApp/
├── Appointment.cs  # Manages appointment details, scheduling, and formatting
├── Doctor.cs       # Doctor domain model (ID, Name, Specialization)
├── Main.cs         # Entry point (Program) driving object creation and execution
├── Patient.cs      # Patient domain model (ID, Name, Disease)
├── Study.cs        # Diagnostic study domain model (ID, StudyType, Result)
└── README.md       # Documentation
```

## Class Relationship Diagram

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

## How to Run

### Prerequisites
- [.NET SDK 6.0+](https://dotnet.microsoft.com/download) installed on your system.
- An IDE such as **Visual Studio**, **Visual Studio Code**, or **JetBrains Rider** (or command line terminal).

### Execution via .NET CLI
1. Open a terminal in the project directory where the `.cs` files are located.
2. Build and run the project using:
   ```bash
   dotnet run
   ```

### Execution via Visual Studio / VS Code
1. Open the solution/folder in your IDE.
2. Select `Main.cs` (or set the project as the startup project).
3. Press `F5` or click **Run/Debug**.

---

## Domain Classes Overview

| Class | Responsibilities |
|-------|------------------|
| **`Patient`** | Holds patient identification, name, and medical condition/disease. |
| **`Doctor`** | Holds doctor identification, name, and medical specialization. |
| **`Study`** | Represents diagnostic procedures with study ID, study type, and diagnostic result. |
| **`Appointment`** | Aggregates `Patient` and `Doctor` objects with appointment date, branch location, study type, and consultation reason. Contains `PrintAppointment()` for output rendering. |
| **`Program` (`Main.cs`)** | Instantiates mock patients, doctors, studies, and prints appointment details to the console. |

---

## Sample Console Output

Upon running the application, the system outputs formatted appointment receipts:

```text
========================================
         APPOINTMENT DETAILS
========================================
Patient     : Ahmed Ali
Disease     : Diabetes
Doctor      : Omar Hassan
Specialist  : Cardiology
Date        : 2026-07-20
Branch      : Main Branch
Study       : Heart Checkup
Reason      : Patient has chest pain
========================================

========================================
         APPOINTMENT DETAILS
========================================
Patient     : Sara Mohamed
Disease     : Asthma
Doctor      : Mona Adel
Specialist  : Neurology
Date        : 2026-07-21
Branch      : North Branch
Study       : Brain Scan
Reason      : Patient has recurring headaches
========================================
```

## Author

**Anas Mohamed** — Software Engineering Intern at Millensys