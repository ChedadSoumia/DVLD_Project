# DVLD - Driving & Vehicle License Department

A desktop application for managing driving license services and related operations.

This project was developed using **C# WinForms** and **SQL Server**, with a layered architecture separating the Presentation, Business Logic, and Data Access layers.

## 🚗 Main Features

### 👤 Manage People

* Add, update, delete, and search people.
* Manage personal information and nationality data.
* Display people in a structured DataGridView.

### 👨‍💻 Manage Users

* Full CRUD operations for system users.
* User permissions management.
* Permission-based access to application features.
* Save the login username and password securely using the **Windows Registry** for the "Remember Me" functionality.

### 🚘 Local Driving License Applications

Manage local driving license applications according to their status:

* **New**
* **Cancelled**
* **Completed**

The system manages the application workflow from creation through the required tests and license issuance.

### 📝 Driving Tests

* Manage test appointments.
* Add and update tests.
* Send email notifications/messages when tests are added or updated using **SMTP**.

### 🔄 Renew Driving License

* Manage driving license renewal applications.
* Process renewal requests according to the license status and expiration date.

### 🌍 International Driving License

* Manage International Driving License applications.
* Create and manage international licenses for eligible applicants.

### 🚫 Detained Licenses

* Manage detained driving licenses.
* Record detained license information.
* Release detained licenses when the required conditions are met.

### 📊 Dashboard & System Management

A small dashboard provides access to administrative and monitoring features, including:

* Manage **Application Types**.
* Edit application type information.
* Manage driving tests.
* Monitor **license expiration dates**.

## 🏗️ Architecture

The project follows a layered architecture:

```text
Presentation Layer
       ↓
Business Logic Layer
       ↓
Data Access Layer
       ↓
SQL Server Database
```

### Presentation Layer

Built with **C# WinForms** and responsible for:

* Forms and UI
* User interaction
* Validation
* Data presentation

### Business Logic Layer

Responsible for:

* Business rules
* Application workflows
* Validation
* Communication between the UI and Data Access Layer

### Data Access Layer

Responsible for:

* SQL Server communication
* Stored procedures
* CRUD operations
* Database queries

## 🛠️ Technologies

* **C#**
* **.NET Framework**
* **Windows Forms**
* **SQL Server**
* **ADO.NET**
* **Stored Procedures**
* **SMTP**
* **Windows Registry**
* **Git & GitHub**

## 🔐 Security & Permissions

The application includes a permission system that controls access to different parts of the application.

Users can have permissions such as:

* Add User
* Change Password
* Dashboard
* Local Driving License
* International Driving License
* Replacement License
* Release Detained License

The system also supports remembering login credentials through the Windows Registry.

## 📌 Project Purpose

The main goal of this project was to build a practical desktop system that simulates the workflow of a Driving & Vehicle License Department while applying real-world software development concepts such as:

* Layered architecture
* CRUD operations
* Database design
* Stored procedures
* Business rules
* User authentication
* Permissions
* Email notifications
* Exception handling
* Git/GitHub version control

## 📷 Screenshots

*Add screenshots of the main forms here.*

## 👩‍💻 Author

**Soumia Chedad**

Junior C# / .NET Developer
Interested in Desktop Application Development, SQL Server, and Clean & Maintainable Code.
