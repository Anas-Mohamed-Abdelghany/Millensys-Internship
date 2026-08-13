# Patient Management System

A client-side CRUD application for managing patient records, built with **HTML5**, **Bootstrap 5**, **CSS3**, and **Vanilla JavaScript**.

## Overview

This project implements a Patient Management System that allows users to add, view, edit, and delete patient records through a clean, responsive interface. All data is managed in-memory using JavaScript arrays.

## Features

- **Create** — Register new patients with name, age, gender, and condition
- **Read** — View all patient records in a responsive table
- **Update** — Edit existing patient information inline
- **Delete** — Remove patient records with confirmation dialog
- Form validation with Bootstrap's built-in validation
- Auto-incrementing patient IDs
- Real-time UI updates without page reload
- Responsive layout for desktop and mobile

## Tech Stack

| Technology | Purpose |
|------------|---------|
| HTML5 | Page structure |
| Bootstrap 5.3 | UI components and grid system |
| Bootstrap Icons | Icon library |
| CSS3 | Custom styling and animations |
| Vanilla JavaScript | Client-side logic and DOM manipulation |

## File Structure

```
2nd Task/
├── index.html    # Main HTML document
├── style.css     # Custom styles
├── script.js     # Application logic
└── README.md     # This file
```

## Application Architecture

```
┌─────────────┐     ┌──────────────┐     ┌─────────────┐
│  HTML Form  │────▶│  JavaScript  │────▶│ HTML Table  │
│  (Input)    │     │  (Logic)     │     │ (Display)   │
└─────────────┘     └──────────────┘     └─────────────┘
```

## How to Run

1. Open `index.html` in any modern web browser.
2. No server or build tools required — fully client-side.

## Usage

1. Fill in the patient form (Name, Age, Gender, Condition)
2. Click **Add** to register a new patient
3. Click the **Edit** icon to modify an existing record
4. Click the **Delete** icon to remove a record

## Author

**Anas Mohamed** — Software Engineering Intern at Millensys
