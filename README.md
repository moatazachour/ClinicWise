<p align="center">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=for-the-badge&logo=dotnet" alt=".NET Framework 4.8"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server"/>
  <img src="https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms"/>
</p>

<h1 align="center">ClinicWise</h1>

<p align="center">
  <strong>A desktop clinic management system built with Windows Forms, C#, and SQL Server.</strong>
</p>

ClinicWise is a .NET Framework 4.8 application for managing clinic operations from registration through appointments, medical records, prescriptions, invoicing, and payment tracking. The codebase is organized around a layered architecture with a WinForms presentation project, a business layer, shared DTO contracts, and SQL Server data access.

The project focuses on practical clinic workflows: patient and doctor records, guardian handling for minors, appointment lifecycle management, medical documentation, medication catalogs, visit fees, invoices, and payments.

## Features

| Area | What it supports |
| --- | --- |
| Patients and persons | Shared person records, patient profiles, patient picker screens, image handling, and guardian linking |
| Doctors | Doctor profiles, specializations, doctor picker screens, and doctor availability checks |
| Appointments | Scheduling, filtering by date ranges, conflict checks, business-hours validation, and lifecycle status tracking |
| Medical records | Visit records connected to appointments, diagnosis/notes fields, and prescription item management |
| Pharmacy | Medication catalog with dosage forms, add/edit flows, detail screens, and reusable medication cards |
| Prescriptions | Prescription items tied to medical records with dosage, frequency, and duration information |
| Financials | Visit fees, invoice items, invoices, discounts, voiding, outstanding balances, and payment tracking |
| Users and roles | Login, user management, role lookup, active/inactive status, and password changes |
| Database layer | Stored procedures, SQL views, triggers, and a scalar function for active visit fee checks |

## Domain Rules

ClinicWise includes business rules in the application layer and the database layer.

Appointment statuses:

```csharp
public enum enAppointmentStatus
{
    Pending = 1,
    Confirmed = 2,
    Completed = 3,
    Cancelled = 4,
    Rescheduled = 5,
    NoShow = 6
}
```

Clinic hours:

```text
Monday-Friday: 08:00 AM - 05:00 PM
Saturday:      09:00 AM - 01:00 PM
Sunday:        Closed
```

Visit types:

```csharp
public enum enVisitType
{
    Consultation = 1,
    FollowUp = 2,
    Emergency = 3,
    RoutineCheck = 4,
    Vaccination = 5,
    LabTest = 6
}
```

Invoice statuses:

```csharp
public enum enInvoiceStatus
{
    Draft,
    Issued,
    PartiallyPaid,
    Paid,
    Waived,
    Void
}
```

## Architecture

The main application follows a layered design:

```text
ClinicWise                 Windows Forms UI
    |
ClinicWise.Business        Domain logic and workflow rules
    |
ClinicWise.Contracts       DTOs and shared enums
    |
ClinicWise.DataAccess      SQL Server access classes, scripts, views, triggers
    |
SQL Server                 ClinicDB database
```

Key patterns and practices used in the codebase:

- Three-layer separation between UI, business logic, and data access.
- DTOs in `ClinicWise.Contracts` for passing data between layers.
- `enMode.AddNew` / `enMode.Update` state handling for save workflows.
- Stored procedures for most database writes and reads.
- SQL views for display-oriented data such as appointments, invoices, payments, users, doctors, and patients.
- Triggers for invoice/payment status synchronization and audit-style database behavior.
- SHA-256 password hashing.
- AES encryption for locally remembered credentials.
- Windows Event Log integration for error logging.

## Project Structure

```text
.
|-- ClinicDB.bak
|-- Database Schema.png
|-- README.md
|-- ClinicWise/
|   |-- Appointments/
|   |-- Doctors/
|   |-- Financial/
|   |   |-- InvoiceItems/
|   |   |-- Invoices/
|   |   |-- Payments/
|   |   `-- Visit Fees/
|   |-- Global Classes/
|   |-- Guardians/
|   |-- Login/
|   |-- MedicalRecords/
|   |-- Patients/
|   |-- Persons/
|   |-- Pharmacy/
|   |-- PrescriptionItems/
|   |-- Users/
|   |-- App.config
|   `-- ClinicWise.sln
|-- ClinicWise.Business/
|   |-- ClinicHours.cs
|   |-- clsAppointment.cs
|   |-- clsDoctor.cs
|   |-- clsInvoice.cs
|   |-- clsMedicalRecord.cs
|   |-- clsMedicament.cs
|   |-- clsPatient.cs
|   |-- clsPayment.cs
|   |-- clsPrescriptionItem.cs
|   |-- clsUser.cs
|   `-- clsVisitTypeFee.cs
|-- ClinicWise.Contracts/
|   |-- Appointments/
|   |-- Doctors/
|   |-- Invoices/
|   |-- MedicalRecords/
|   |-- Medicaments/
|   |-- Patients/
|   |-- Payments/
|   |-- Persons/
|   |-- PrescriptionItems/
|   |-- Users/
|   `-- VisitTypeFees/
`-- ClinicWise.DataAccess/
    |-- Functions/
    |-- StoredProcedures/
    |-- Triggers/
    |-- Views/
    `-- cls*Data.cs
```

## Database

The repository includes:

- `ClinicDB.bak` for restoring a sample SQL Server database.
- SQL stored procedure scripts under `ClinicWise.DataAccess/StoredProcedures`.
- SQL views under `ClinicWise.DataAccess/Views`.
- SQL triggers under `ClinicWise.DataAccess/Triggers`.
- `ClinicWise.DataAccess/Functions/dbo.CheckIfFeeIsActive.sql` for validating active visit fees.
- `Database Schema.png` as a visual database schema reference.

<p align="center">
  <img src="Database Schema.png" alt="ClinicWise database schema" width="100%"/>
</p>

Main database areas include persons, patients, guardians, doctors, users, roles, appointments, medical records, prescription items, medicaments, visit type fees, invoices, invoice items, and payments.

## Getting Started

### Prerequisites

- Visual Studio 2019 or later with the .NET desktop development workload.
- .NET Framework 4.8 Developer Pack.
- SQL Server or SQL Server Express.
- SQL Server Management Studio, Azure Data Studio, or another tool capable of restoring `.bak` files.

### Setup

1. Clone the repository.

   ```bash
   git clone https://github.com/moatazachour/ClinicWise.git
   cd ClinicWise
   ```

2. Restore the database backup.

   - Open SQL Server Management Studio.
   - Restore `ClinicDB.bak`.
   - Keep or rename the restored database as `ClinicDB`.

3. Configure the database connection.

   Open `ClinicWise/App.config` and update the `DatabaseConnection` connection string if your SQL Server instance is not local:

   ```xml
   <connectionStrings>
     <add
       name="DatabaseConnection"
       connectionString="Data Source=.;Initial Catalog=ClinicDB;Integrated Security=True"
       providerName="System.Data.SqlClient"/>
   </connectionStrings>
   ```

4. Build and run the application.

   - Open `ClinicWise/ClinicWise.sln`.
   - Restore/build the solution in Visual Studio.
   - Set `ClinicWise` as the startup project.
   - Run the application.

## Current Status

Implemented modules:

- Patient, doctor, guardian, user, and role management.
- Appointment scheduling, filtering, status updates, no-show marking logic, and completion checks.
- Medical records and prescription item workflows.
- Pharmacy/medicament catalog management.
- Visit fee management.
- Invoice, invoice item, discount, voiding, and payment workflows.
- SQL Server scripts for stored procedures, views, triggers, and fee validation.

Possible next improvements:

- Add automated tests for business rules and data access behavior.
- Add screenshots for the main screens.
- Add a formal license file if the project should be open sourced under a specific license.
- Add setup scripts for creating or migrating the database without restoring a backup.
- Improve configuration documentation for production-like environments.

## Author

**Moataz Achour**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/moataz-achour)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/moatazachour)
