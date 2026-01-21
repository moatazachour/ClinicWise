<p align="center">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=for-the-badge&logo=dotnet" alt=".NET Framework"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server"/>
  <img src="https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms"/>
</p>

<h1 align="center">🏥 ClinicWise</h1>

<p align="center">
  <strong>A comprehensive Clinic Management System built from scratch using .NET and SQL Server</strong>
</p>

<p align="center">
  <em>Streamlining clinic operations through intelligent patient, doctor, and appointment management</em>
</p>

---

## 📋 Overview

**ClinicWise** is a desktop application designed to manage day-to-day clinic operations efficiently. Built with a focus on clean architecture and healthcare domain modeling, this project demonstrates professional software development practices while solving real-world clinic management challenges.

Beyond just coding, this project provided deep insight into **healthcare domain modeling** — understanding how clinics actually operate, from patient workflows and appointment lifecycles to guardian consent rules and audit requirements. Building domain-specific software is as much about understanding the business as it is about writing code.

---

## ✨ Features

### Core Modules

| Module | Description |
|--------|-------------|
| 👥 **Patient Management** | Full CRUD operations with guardian linking for minors (auto-detects patients under 18) |
| 👨‍⚕️ **Doctor Management** | Doctor profiles with specialization tracking and availability management |
| 📅 **Appointment Scheduling** | 6-state workflow tracking with conflict detection and business hours validation |
| 🔐 **User Authentication** | Secure login with role-based access control (Admin, Doctor, Staff) |
| 👨‍👩‍👧 **Guardian Management** | Automatic guardian requirement detection for minor patients |
| 📋 **Medical Records** | Visit tracking with 6 visit types (Consultation, Follow-Up, Emergency, Routine Check, Vaccination, Lab Test) |

### Medical Record Visit Types

```csharp
public enum enVisitType
{
    Consultation = 1,   // General consultation
    FollowUp = 2,       // Follow-up visits
    Emergency = 3,      // Emergency cases
    RoutineCheck = 4,   // Routine health checks
    Vaccination = 5,    // Vaccination visits
    LabTest = 6         // Laboratory tests
}
```

### Business Hours Validation

```
┌──────────────────────────────────────────┐
│           CLINIC HOURS                   │
├──────────────────────────────────────────┤
│  Weekdays (Mon-Fri):  08:00 AM - 05:00 PM│
│  Saturday:            09:00 AM - 01:00 PM│
│  Sunday:              CLOSED             │
└──────────────────────────────────────────┘
```

### Security Features

- 🔒 **SHA-256** password hashing
- 🔐 **AES-256** encryption for stored credentials
- 📝 **Windows Registry** integration for secure "Remember Me"
- 📊 **Windows Event Log** for centralized error logging
- 🛡️ **SQL Triggers** for audit trail on deletions

---

## 🏗️ Architecture

ClinicWise follows a **3-Tier Architecture** pattern ensuring clean separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                       │
│                      (ClinicWise)                           │
│  ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐            │
│  │  Forms  │ │Controls │ │  Utils  │ │Resources│            │
│  └─────────┘ └─────────┘ └─────────┘ └─────────┘            │
└─────────────────────────────────────────────────────────────┘
                            │
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                    BUSINESS LOGIC LAYER                     │
│                   (ClinicWise.Business)                     │
│  ┌──────────┐ ┌──────────┐ ┌──────────┐ ┌──────────┐        │
│  │clsPatient│ │clsDoctor │ │clsAppoint│ │clsMedical│        │
│  │          │ │          │ │  ment    │ │  Record  │        │
│  └──────────┘ └──────────┘ └──────────┘ └──────────┘        │
└─────────────────────────────────────────────────────────────┘
                            │
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                    DATA ACCESS LAYER                        │
│                  (ClinicWise.DataAccess)                    │
│  ┌──────────┐ ┌──────────┐ ┌──────────┐ ┌──────────┐        │
│  │  Stored  │ │  Views   │ │ Triggers │ │  Data    │        │
│  │Procedures│ │  (CTEs)  │ │ (Audit)  │ │ Classes  │        │
│  └──────────┘ └──────────┘ └──────────┘ └──────────┘        │
└─────────────────────────────────────────────────────────────┘
                            │
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                      SQL SERVER DATABASE                    │
│                       (ClinicDB.bak)                        │
└─────────────────────────────────────────────────────────────┘
```

---

## 🛠️ Technical Highlights

### Design Patterns & Practices

| Pattern | Implementation |
|---------|---------------|
| **3-Tier Architecture** | Separate projects for Presentation, Business, Data Access |
| **DTO Pattern** | Dedicated Contracts layer (e.g., `AppointmentDTO` vs `AppointmentDisplayDTO`) |
| **Mode Pattern** | `enMode.AddNew` / `enMode.Update` for entity state management |
| **Repository Pattern** | Data classes abstracting SQL operations |
| **Async/Await** | Non-blocking database operations for responsive UI |

### Object-Oriented Design

```csharp
// Inheritance hierarchy with polymorphic Save() methods
public class clsPerson { public virtual bool Save() { ... } }
    ├── public class clsPatient : clsPerson { public override bool Save() { ... } }
    ├── public class clsDoctor : clsPerson { public override bool Save() { ... } }
    └── public class clsGuardian : clsPerson { public override bool Save() { ... } }
```

### Database Features

- **Stored Procedures** with output parameters for all CRUD operations
- **Views with CTEs** for complex queries (e.g., `GetAllAppointments_View`)
- **Triggers** for audit logging on deletions (`trg_AfterDeleteDoctor`, etc.)
- **Proper indexing** and normalized schema design
- **Database Backup** included (`ClinicDB.bak`) for quick setup

### Reusable Components

- **`ctrlPersonCard`** — User control with method overloading (load by ID, DTO, or National Number)
- **`ctrlPersonCardWithFilter`** — Extended control with search/filter capabilities
- **`ctrlAppointmentDetails`** — Appointment details display control
- **`ctrlUserCard`** — User information display control
- **Event-driven communication** — Custom delegates for passing data between forms

---

## 📁 Project Structure

```
ClinicWise/
├── 📄 ClinicDB.bak                   # SQL Server Database Backup
├── 📄 README.md
│
├── 📂 ClinicWise/                    # Presentation Layer (Windows Forms)
│   ├── 📂 Appointments/              # Appointment management forms
│   │   └── 📂 Controls/              # ctrlAppointmentDetails
│   ├── 📂 Doctors/                   # Doctor management forms
│   ├── 📂 Patients/                  # Patient management forms
│   ├── 📂 Persons/                   # Shared person controls
│   │   └── 📂 Controls/              # ctrlPersonCard, ctrlPersonCardWithFilter
│   ├── 📂 Users/                     # User management forms
│   │   └── 📂 Controls/              # ctrlUserCard
│   ├── 📂 Login/                     # Authentication forms
│   ├── 📂 Guardians/                 # Guardian management
│   ├── 📂 Global Classes/            # Utilities, validation, settings
│   └── 📂 Resources/                 # Images and assets
│
├── 📂 ClinicWise.Business/           # Business Logic Layer
│   ├── clsAppointment.cs             # Appointment business logic
│   ├── clsDoctor.cs                  # Doctor business logic
│   ├── clsPatient.cs                 # Patient business logic
│   ├── clsPerson.cs                  # Base person class
│   ├── clsUser.cs                    # User business logic
│   ├── clsGuardian.cs                # Guardian business logic
│   ├── clsMedicalRecord.cs           # Medical records logic
│   └── ClinicHours.cs                # Business hours validation
│
├── 📂 ClinicWise.Contracts/          # DTOs / Data Transfer Objects
│   ├── 📂 Appointments/              # AppointmentDTO, AppointmentDisplayDTO
│   ├── 📂 Doctors/                   # DoctorDTO, DoctorDisplayDTO
│   ├── 📂 Patients/                  # PatientDTO, PatientDisplayDTO
│   ├── 📂 Persons/                   # PersonDTO
│   ├── 📂 Users/                     # UserDTO, UserDisplayDTO
│   ├── 📂 Guardians/                 # GuardianDTO, GuardianRelationshipDTO
│   ├── 📂 Roles/                     # RoleDTO
│   └── 📂 Specializations/           # SpecializationDTO
│
└── 📂 ClinicWise.DataAccess/         # Data Access Layer
    ├── 📂 StoredProcedures/          # All SQL stored procedures
    │   ├── 📂 Appointments/          # 14 procedures
    │   ├── 📂 Doctors/               # 7 procedures
    │   ├── 📂 Patients/              # 5 procedures
    │   ├── 📂 Persons/               # 5 procedures
    │   ├── 📂 Users/                 # 6 procedures
    │   ├── 📂 Guardians/             # 3 procedures
    │   ├── 📂 MedicalRecords/        # 2 procedures
    │   ├── 📂 Roles/                 # 3 procedures
    │   └── 📂 Specializations/       # 3 procedures
    ├── 📂 Views/                     # SQL views with CTEs
    │   ├── 📂 Appointments/          # GetAllAppointments, GetTodays, GetTomorrows
    │   ├── GetAllDoctors_View.sql
    │   ├── GetAllPatients_View.sql
    │   ├── GetAllPersons_View.sql
    │   └── GetAllUsers_View.sql
    ├── 📂 Triggers/                  # Audit triggers
    │   ├── trg_AfterDeleteDoctor.sql
    │   ├── trg_AfterDeletePatient.sql
    │   ├── trg_AfterDeletePerson.sql
    │   └── trg_AfterDeleteGuardian.sql
    └── cls*Data.cs                   # Data access classes
```

---

## 🗄️ Database Schema

<p align="center">
  <img src="images/database-schema.png" alt="ClinicWise Database Schema" width="100%"/>
</p>

### Tables Overview

| Table | Description |
|-------|-------------|
| **Persons** | Base table for all people (patients, doctors, guardians) |
| **Patients** | Patient records linked to Persons and Guardians |
| **Doctors** | Doctor profiles with specializations |
| **Guardians** | Guardian information for minor patients |
| **GuardianRelationships** | Lookup table for relationship types |
| **Appointments** | Scheduled appointments between patients and doctors |
| **MedicalRecords** | Visit records linked to appointments |
| **PrescriptionItems** | Prescribed medications per medical record |
| **Medicaments** | Drug/medication catalog |
| **Payments** | Payment tracking for appointments |
| **Users** | System users with authentication |
| **Roles** | User roles (Admin, Doctor, Staff) |
| **Specializations** | Medical specialization categories |

---

## 🚀 Getting Started

### Prerequisites

- **Visual Studio 2019/2022** with .NET Desktop Development workload
- **SQL Server 2019+** (or SQL Server Express)
- **.NET Framework 4.8**

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/ClinicWise.git
   ```

2. **Restore the database**
   - Open SQL Server Management Studio
   - Right-click on Databases → Restore Database
   - Select "Device" and browse to `ClinicDB.bak`
   - Restore the database

3. **Configure the connection string**
   - Open `ClinicWise.DataAccess/clsDataAccessSettings.cs`
   - Update the `ConnectionString` with your SQL Server details

4. **Build and run**
   - Open `ClinicWise/ClinicWise.sln` in Visual Studio
   - Build the solution (Ctrl + Shift + B)
   - Run the application (F5)

### Default Login Credentials
```
Username: admin
Password: admin123
```

---

## 🗺️ Roadmap

### ✅ Completed
- [x] Patient Management with CRUD operations
- [x] Doctor Management with Specializations
- [x] Appointment Scheduling with 6-state workflow
- [x] User Authentication & Authorization
- [x] Guardian Management for minors
- [x] Business Hours Validation
- [x] Conflict Detection for appointments
- [x] Medical Records with Visit Types
- [x] Database Schema for Prescriptions & Payments (ready for implementation)

### 🔜 Coming Soon
- [ ] 💊 Prescription Management (with Medicaments catalog)
- [ ] 💳 Payment Tracking & Receipt Generation
- [ ] 🔔 Background Services for appointment reminders
- [ ] ⭐ Doctor Rating & Scoring System
- [ ] 💰 Staff Salary Management
- [ ] 🏖️ Leave Management System
- [ ] 📊 Dashboard & Analytics

---

## 📸 Screenshots

> *Screenshots coming soon*

---

## 🤝 Contributing

Contributions are welcome! Feel free to:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 👤 Author

**Moataz Achour**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/yourprofile)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/yourusername)

---

## 🙏 Acknowledgments

- Built as a portfolio project to demonstrate enterprise application development
- Inspired by real-world clinic management workflows
- Special thanks to the .NET and SQL Server communities

---

<p align="center">
  <strong>⭐ If you found this project helpful, please consider giving it a star!</strong>
</p>

<p align="center">
  Made with ❤️ and C#
</p>
