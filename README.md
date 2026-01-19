# 🏋️ Spark Powerhouse Gym – C# WinForms Gym Management Simulation

![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-512BD4?logo=dotnet&logoColor=white)
![WinForms](https://img.shields.io/badge/WinForms-0078D6?logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?logo=microsoft-sql-server&logoColor=white)

**Spark Powerhouse Gym** is a **C# WinForms–based desktop application** developed as part of academic coursework. The project simulates a gym management and membership system with a modern, web-style user interface.

The application focuses on **application flow design, role-based access, UI/UX consistency, and event-driven programming**, rather than real-world transactions or live integrations.

The system includes **separate User and Admin modes** and demonstrates how a real-world fitness management platform might function at a conceptual level.

---

## ✨ Features

### 👤 User Mode
- Web-style graphical user interface built using **C# WinForms**
- Home dashboard with menu-based navigation
- Browse gym information:
  - About Us
  - Contact Us
- View gym class schedules in a weekly timetable format
- Explore membership plans (3 / 6 / 12 months)
- Browse gym equipment via a dedicated shop
- Simulated checkout and payment flow
- Card payment *(simulation only)*
- Mobile payment *(bKash-style UI simulation)*
- OTP-based confirmation *(simulated)*

> **Note:** All purchases, payments, and OTP verifications are fully simulated.

---

### 🧑‍💼 Admin Mode
- Separate admin interface with restricted access
- Admin login authentication
- View registered users
- Monitor membership information
- Manage user-related records

---

### 🔐 General
- Role-based access control (Admin vs User)
- Event-driven desktop application design
- Modular WinForms structure
- Fitness-themed UI design
- Clear separation of workflows

---

## 📸 Application Screenshots

A visual walkthrough of the application highlighting key interfaces and role-based interactions.

---

### 🔐 Authentication & Mode Selection
Core entry points that define role-based access.

![Mode Selection](Screenshots/mode-selection.png)
![User Login](Screenshots/user-login.png)
![Admin Login](Screenshots/admin-login.png)

---

### 👤 User Experience
Primary user-facing features demonstrating navigation, services, and simulated interactions.

![User Dashboard](Screenshots/user-dashboard.png)
![Membership Plans](Screenshots/membership-plans.png)
![Gym Class Schedule](Screenshots/gym-schedule.png)
![Equipment Shop](Screenshots/equipment-shop.png)

---

### 💳 Payment Simulation (Mock)
Demonstrates the simulated checkout and OTP-based confirmation flow  
(UI-only, no real transactions)

![Payment Simulation](Screenshots/payment-simulation.png)
![Payment Gateway (OTP Simulation)](Screenshots/payment-gateway.png)

---

### 🛠 Admin Dashboard
Administrative controls for managing users and memberships.

![Admin Dashboard](Screenshots/admin-dashboard.png)
![Admin – User Information](Screenshots/admin-user-information.png)
![Admin – Membership Information](Screenshots/admin-membership-information.png)

---

## 🛠 Technologies Used
- **C#**
- **.NET Framework**
- **Windows Forms (WinForms)**
- **SQL Server** *(local / simulated)*
- **Object-Oriented Programming (OOP)**
- **Event-Driven Programming**

---

## ▶ How to Run
1. Open the project in **Visual Studio**
2. Load `SPG.sln`
3. Build the solution
4. Run the project
5. The application window will launch

---

## ℹ Notes
- Simulation-based academic project
- No real payments, OTPs, or external services
- All workflows are mock implementations

---

## 👤 Author
**Sajidur Rahman Sajid**  
BSc in Computer Science & Engineering (CSE)  
Final-year undergraduate student
