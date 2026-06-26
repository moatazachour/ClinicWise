<p align="center">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=for-the-badge&logo=dotnet" alt=".NET Framework 4.8"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server"/>
  <img src="https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms"/>
  <img src="https://img.shields.io/badge/Windows%20Service-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Service"/>
</p>

<h1 align="center">ClinicWise</h1>

<p align="center">
  <strong>A desktop clinic management system with a Windows Service background worker, built with Windows Forms, C#, and SQL Server.</strong>
</p>

ClinicWise is a .NET Framework 4.8 application for managing clinic operations from registration through appointments, medical records, prescriptions, invoicing, and payment tracking. The codebase is organized around a layered architecture with a WinForms presentation project, a Windows Service background worker, a business layer, shared DTO contracts, and SQL Server data access.

The project focuses on practical clinic workflows: patient and doctor records, guardian handling for minors, appointment lifecycle management, medical documentation, medication catalogs, visit fees, invoices, payments, reminder emails, and automatic background status updates.

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
| Background service | Automatic appointment reminders, missed-appointment no-show marking, invoice payment reminders, and final overdue notices |
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

Background service settings:

```xml
<appSettings>
  <add key="IntervalHours" value="2"/>
  <add key="NoShowThresholdMinutes" value="60"/>
  <add key="InvoiceReminderMaxCount" value="3"/>
  <add key="InvoiceReminderIntervalDays" value="7"/>
  <add key="SmtpHost" value="smtp.gmail.com"/>
  <add key="SmtpPort" value="587"/>
  <add key="SmtpUser" value="your-clinic-email@example.com"/>
  <add key="SmtpPass" value="your-app-password"/>
</appSettings>
```

The Windows Service runs all background jobs when it starts and then repeats them every `IntervalHours`. It can also run interactively from the executable for local debugging.

Background jobs:

- `NoShowMarkingJob` marks confirmed or rescheduled appointments as `NoShow` after the configured threshold and sends missed-appointment emails.
- `AppointmentReminderJob` sends reminder emails for tomorrow's appointments that have not already been marked as reminded.
- `InvoiceReminderJob` sends payment reminders for outstanding invoices, logs invoice reminder history, and marks invoices overdue after the configured reminder limit.

## Architecture

The main application follows a layered design:

```text
ClinicWise                 Windows Forms UI
    |                         |
    |                         |
ClinicWise.Service           Windows Service background jobs
    |                         |
    `-----------.-------------`
                v
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
- Windows Service jobs for scheduled operational work outside the WinForms UI.
- SMTP email delivery for appointment and invoice notifications.
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
|   |-- Services/
|   |   `-- EmailService.cs
|   |-- clsAppointment.cs
|   |-- clsDoctor.cs
|   |-- clsInvoice.cs
|   |-- clsInvoiceReminder.cs
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
|-- ClinicWise.Service/
|   |-- Jobs/
|   |   |-- AppointmentReminderJob.cs
|   |   |-- InvoiceReminderJob.cs
|   |   `-- NoShowMarkingJob.cs
|   |-- App.config
|   |-- ClinicWiseService.cs
|   |-- Program.cs
|   `-- ProjectInstaller.cs
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

Main database areas include persons, patients, guardians, doctors, users, roles, appointments, medical records, prescription items, medicaments, visit type fees, invoices, invoice reminders, invoice items, and payments.

Service-related SQL assets include:

- `Appointment_MarkAndGetNoShowAppointments.sql`
- `Appointment_GetTomorrowsPendingReminder.sql`
- `Appointment_MarkReminderAsSent.sql`
- `Invoice_GetInvoicesDueForReminder.sql`
- `Invoice_MarkOverdue.sql`
- `InvoiceReminder_AddNew.sql`
- `InvoiceReminder_GetLatestByInvoiceID.sql`

## Getting Started

### Prerequisites

- Visual Studio 2019 or later with the .NET desktop development workload.
- .NET Framework 4.8 Developer Pack.
- SQL Server or SQL Server Express.
- SQL Server Management Studio, Azure Data Studio, or another tool capable of restoring `.bak` files.
- Administrator access if you want to install or control the Windows Service locally.
- SMTP credentials for the email reminder features.

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

   Open both `ClinicWise/App.config` and `ClinicWise.Service/App.config`, then update the `DatabaseConnection` connection string if your SQL Server instance is not local:

   ```xml
   <connectionStrings>
     <add
       name="DatabaseConnection"
       connectionString="Data Source=.;Initial Catalog=ClinicDB;Integrated Security=True"
       providerName="System.Data.SqlClient"/>
   </connectionStrings>
   ```

4. Configure service reminder and email settings.

   Open `ClinicWise.Service/App.config` and set:

   - `IntervalHours`: how often the service runs all jobs.
   - `NoShowThresholdMinutes`: how long after an appointment time before it can be marked as no-show.
   - `InvoiceReminderMaxCount`: how many invoice reminders are sent before final overdue handling.
   - `InvoiceReminderIntervalDays`: how many days to wait between invoice reminders.
   - `SmtpHost`, `SmtpPort`, `SmtpUser`, and `SmtpPass`: the SMTP account used to send emails.

   For Gmail, `SmtpPass` should be an app password, not the normal account password. Avoid committing real production credentials.

5. Build and run the desktop application.

   - Open `ClinicWise/ClinicWise.sln`.
   - Restore/build the solution in Visual Studio.
   - Set `ClinicWise` as the startup project.
   - Run the application.

6. Test the service in console mode.

   After building, run the service executable directly from a terminal. Because `Program.Main` checks `Environment.UserInteractive`, the service starts in console mode and waits for Enter before stopping.

   ```powershell
   .\ClinicWise.Service\bin\Debug\ClinicWise.Service.exe
   ```

7. Install the Windows Service.

   Run the following from an elevated Developer Command Prompt or elevated PowerShell after building the service:

   ```powershell
   & "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe" ".\ClinicWise.Service\bin\Release\ClinicWise.Service.exe"
   Start-Service ClinicWiseService
   ```

   To stop and uninstall it:

   ```powershell
   Stop-Service ClinicWiseService
   & "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe" /u ".\ClinicWise.Service\bin\Release\ClinicWise.Service.exe"
   ```

   The installer registers the service as `ClinicWiseService` with the display name `ClinicWise Background Service`.

## Current Status

Implemented modules:

- Patient, doctor, guardian, user, and role management.
- Appointment scheduling, filtering, status updates, no-show marking logic, and completion checks.
- Medical records and prescription item workflows.
- Pharmacy/medicament catalog management.
- Visit fee management.
- Invoice, invoice item, discount, voiding, and payment workflows.
- Windows Service project for automatic no-show processing, appointment reminders, invoice reminders, and overdue notices.
- SMTP email service used by appointment and invoice notification workflows.
- Invoice reminder tracking through `InvoiceReminders` data access and stored procedures.
- SQL Server scripts for stored procedures, views, triggers, and fee validation.

Possible next improvements:

- Add automated tests for business rules and data access behavior.
- Add screenshots for the main screens.
- Add a formal license file if the project should be open sourced under a specific license.
- Add setup scripts for creating or migrating the database without restoring a backup.
- Move SMTP credentials and operational secrets out of committed config files for production deployments.
- Add richer service logging for each job run and email delivery result.
- Improve configuration documentation for production-like environments.

## Author

**Moataz Achour**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/moataz-achour)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/moatazachour)
