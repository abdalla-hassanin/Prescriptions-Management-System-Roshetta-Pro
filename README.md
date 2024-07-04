# Project Documentation: Prescriptions Management System (Roshetta Pro)

## 1. Title Page
**Project Title**: Prescriptions Management System (Roshetta Pro)  
**Author(s)**: Abdalla Hassanin  
**Date**: [4/7/2024] 
**Version**: 1.0  

## 2. Table of Contents
1. [Executive Summary](#executive-summary)
2. [Introduction](#introduction)
3. [Project Overview](#project-overview)
4. [System Requirements](#system-requirements)
5. [System Architecture](#system-architecture)
6. [Design Specifications](#design-specifications)
7. [Implementation Plan](#implementation-plan)
8. [Testing and Quality Assurance](#testing-and-quality-assurance)
9. [Deployment Plan](#deployment-plan)
10. [Maintenance and Support](#maintenance-and-support)
11. [Risk Management](#risk-management)
12. [Appendices](#appendices)
13. [Approval and Revision History](#approval-and-revision-history)

## 3. Executive Summary
This document outlines the Prescriptions Management System (Roshetta Pro), detailing the data model, system requirements, design specifications, implementation plan, and more. The system is built using SQL, .NET Core, and ReactJS to manage patient, doctor, prescription, and medication data efficiently.

## 4. Introduction
### Purpose
The purpose of this document is to provide a comprehensive overview of the Prescriptions Management System (Roshetta Pro) project.

### Scope
This document covers the data model, system architecture, functional and non-functional requirements, design specifications, implementation plan, and more.

### Audience
This document is intended for project stakeholders, developers, and testers.

## 5. Project Overview
### Background
The Prescriptions Management System (Roshetta Pro) is designed to streamline the management of patient data, prescriptions, and medical history for clinics and hospitals.

### Objectives
- Efficiently manage patient and doctor records.
- Facilitate prescription and medication management.
- Provide a user-friendly interface for all stakeholders.

### Deliverables
- A functional web application using .NET Core and ReactJS.
- A robust relational database using SQL.

## 6. System Requirements
### Functional Requirements
- User registration and login.
- Role-based access control for doctors and patients.
- CRUD operations for patient and doctor records.
- Prescription and medication management.
- Medical history and X-ray management.

### Non-Functional Requirements
- Performance: The system should handle concurrent users efficiently.
- Security: Ensure data protection and secure access.
- Usability: User-friendly interface for both doctors and patients.

### Technical Requirements
- Backend: .NET Core
- Frontend: ReactJS
- Database: SQL Server

## 7. System Architecture
### Overview
The system architecture consists of a backend developed with .NET Core, a frontend built with ReactJS, and a SQL Server database.

### Components
- **Frontend**: ReactJS application for user interaction.
- **Backend**: .NET Core API to handle business logic.
- **Database**: SQL Server for data storage.

### Data Flow
Diagrams illustrating data flow between components.

## 8. Design Specifications
### Data Model (Relational Schema)

#### Patients Table
| Column                | Type          | Description               |
|-----------------------|---------------|---------------------------|
| PatientID             | INT           | Primary Key               |
| FirstName             | VARCHAR(50)   | First name of the patient |
| LastName              | VARCHAR(50)   | Last name of the patient  |
| DateOfBirth           | DATE          | Date of birth             |
| Gender                | CHAR(1)       | Gender                    |
| Address               | VARCHAR(255)  | Address                   |
| PhoneNumber           | VARCHAR(15)   | Phone number              |
| Email                 | VARCHAR(100)  | Email address             |
| EmergencyContactName  | VARCHAR(100)  | Emergency contact name    |
| EmergencyContactPhone | VARCHAR(15)   | Emergency contact phone   |
| BloodType             | VARCHAR(3)    | Blood type                |
| ImageURL              | VARCHAR(255)  | URL to the patient's image|
| CreatedTime           | DATETIME      | Record creation time      |
| UpdatedTime           | DATETIME      | Record update time        |

#### Clinics Table
| Column        | Type          | Description             |
|---------------|---------------|-------------------------|
| ClinicID      | INT           | Primary Key             |
| Name          | VARCHAR(100)  | Clinic name             |
| Address       | VARCHAR(255)  | Clinic address          |
| PhoneNumber   | VARCHAR(15)   | Clinic phone number     |
| Email         | VARCHAR(100)  | Clinic email            |
| CreatedTime   | DATETIME      | Record creation time    |
| UpdatedTime   | DATETIME      | Record update time      |

#### Doctors Table
| Column        | Type          | Description             |
|---------------|---------------|-------------------------|
| DoctorID      | INT           | Primary Key             |
| FirstName     | VARCHAR(50)   | First name of the doctor|
| LastName      | VARCHAR(50)   | Last name of the doctor |
| Specialization| VARCHAR(100)  | Doctor's specialization |
| PhoneNumber   | VARCHAR(15)   | Doctor's phone number   |
| Email         | VARCHAR(100)  | Doctor's email          |
| ClinicID      | INT           | Foreign Key to Clinics  |
| ImageURL      | VARCHAR(255)  | URL to the doctor's image|
| CreatedTime   | DATETIME      | Record creation time    |
| UpdatedTime   | DATETIME      | Record update time      |

#### Prescriptions Table
| Column          | Type        | Description             |
|-----------------|-------------|-------------------------|
| PrescriptionID  | INT         | Primary Key             |
| PatientID       | INT         | Foreign Key to Patients |
| DoctorID        | INT         | Foreign Key to Doctors  |
| DateIssued      | DATE        | Date issued             |
| ExpirationDate  | DATE        | Expiration date         |
| Notes           | TEXT        | Additional notes        |
| CreatedTime     | DATETIME    | Record creation time    |
| UpdatedTime     | DATETIME    | Record update time      |

#### Medications Table
| Column        | Type          | Description             |
|---------------|---------------|-------------------------|
| MedicationID  | INT           | Primary Key             |
| Name          | VARCHAR(100)  | Medication name         |
| Description   | TEXT          | Medication description  |
| Manufacturer  | VARCHAR(100)  | Manufacturer            |
| SideEffects   | TEXT          | Side effects            |
| Type          | VARCHAR(50)   | Type of medication      |
| CreatedTime   | DATETIME      | Record creation time    |
| UpdatedTime   | DATETIME      | Record update time      |

#### PrescriptionMedications Table
| Column                  | Type        | Description             |
|-------------------------|-------------|-------------------------|
| PrescriptionMedicationID| INT         | Primary Key             |
| PrescriptionID          | INT         | Foreign Key to Prescriptions|
| MedicationID            | INT         | Foreign Key to Medications|
| Dosage                  | INT         | Dosage amount           |
| DosageUnit              | VARCHAR(10) | Dosage unit (e.g., mg)  |
| Frequency               | VARCHAR(50) | Frequency of intake     |
| StartDate               | DATE        | Start date              |
| EndDate                 | DATE        | End date                |
| Instructions            | TEXT        | Special instructions    |
| CreatedTime             | DATETIME    | Record creation time    |
| UpdatedTime             | DATETIME    | Record update time      |

#### MedicalHistory Table
| Column        | Type          | Description             |
|---------------|---------------|-------------------------|
| MedicalHistoryID| INT         | Primary Key             |
| PatientID     | INT           | Foreign Key to Patients |
| DoctorID      | INT           | Foreign Key to Doctors  |
| VisitDate     | DATE          | Date of visit           |
| Diagnosis     | TEXT          | Diagnosis details       |
| Notes         | TEXT          | Additional notes        |
| CreatedTime   | DATETIME      | Record creation time    |
| UpdatedTime   | DATETIME      | Record update time      |

#### PatientXrays Table
| Column        | Type          | Description             |
|---------------|---------------|-------------------------|
| XrayID        | INT           | Primary Key             |
| PatientID     | INT           | Foreign Key to Patients |
| DoctorID      | INT           | Foreign Key to Doctors  |
| DateTaken     | DATE          | Date taken              |
| XrayImageURL  | VARCHAR(255)  | URL to the X-ray image  |
| LabName       | VARCHAR(100)  | Name of the lab         |
| XrayType      | VARCHAR(50)   | Type of X-ray           |
| Notes         | TEXT          | Additional notes        |
| CreatedTime   | DATETIME      | Record creation time    |
| UpdatedTime   | DATETIME      | Record update time      |

### Relationships:
- Patients (1) — (M) Prescriptions
- Doctors (1) — (M) Prescriptions
- Clinics (1) — (M) Doctors
- Prescriptions (1) — (M) PrescriptionMedications
- Medications (1) — (M) PrescriptionMedications
- Patients (1) — (M) MedicalHistory
- Doctors (1) — (M) MedicalHistory
- Patients (1) — (M) PatientXrays
- Doctors (1) — (M) PatientXrays

## 9. Implementation Plan
### Tasks
- Setup project repository and environment.
- Develop database schema and setup SQL Server.
- Implement backend API using .NET Core.
- Develop frontend using ReactJS.
- Integrate frontend with backend.
- Perform user testing and debugging.

### Timeline
- **Week 1-2**: Project setup, database schema, and initial backend development.
- **Week 3-4**: Backend development and API implementation.
- **Week 5-6**: Frontend development and integration.
- **Week 7-8**: Testing, debugging, and final adjustments.

### Resources
- Developers: 2 backend, 2 frontend.
- Tools: SQL Server, .NET Core, ReactJS, Git.

## 10. Testing and Quality Assurance
### Test Plan
- Unit testing for backend API.
- Integration testing between frontend and backend.
- User acceptance testing (UAT) with end-users.

### Test Cases
- Verify user registration and login functionality.
- Test CRUD operations for patients, doctors, prescriptions, and medications.
- Ensure role-based access control.

### Quality Metrics
- Code coverage percentage.
- Number of bugs found and resolved.
- User satisfaction score.

## 11. Deployment Plan
### Deployment Strategy
- Deploy backend API to a cloud service (e.g., Azure).
- Host frontend on a web server (e.g., Netlify).
- Use CI/CD pipelines for automated deployment.

### Rollback Plan
- Keep backups of previous versions.
- Implement automated rollback scripts.

### Training
- Provide documentation and training sessions for users.

## 12. Maintenance and Support
### Maintenance Plan
- Regular updates and bug fixes.
- Monitor system performance and user feedback.

### Support Plan
- Dedicated support team for issue resolution.
- Provide a support ticket system for users.

## 13. Risk Management
### Risk Assessment
- **Risk**: Data breach
  - **Mitigation**: Implement strong encryption and access controls.
- **Risk**: Downtime during deployment
  - **Mitigation**: Schedule deployments during off-peak hours.

### Mitigation Strategies
- Regular security audits.
- Implement redundancy and failover mechanisms.

## 14. Appendices
### Glossary
- **CRUD**: Create, Read, Update, Delete
- **UAT**: User Acceptance Testing

### References
- [ReactJS Documentation](https://reactjs.org/docs/getting-started.html)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)

### Additional Information
- Project GitHub repository: [[Link](https://github.com/abdalla-hassanin/Prescriptions-Management-System-Roshetta-Pro)]

## 15. Approval and Revision History
### Approvals
- **Project Manager**: Abdalla Hassanin

### Revision History
| Version | Date       | Description                        | Author            |
|---------|------------|------------------------------------|-------------------|
| 1.0     | [4/7/2024] | Initial document creation          | Abdalla Hassanin  |
