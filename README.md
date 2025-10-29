#  Payroll Management System

## 📖 Description
The Payroll Management System is a web-based ASP.NET MVC application designed to automate salary calculation for employees.  
It calculates components like **Basic Pay**, **Dearness Allowance (DA)**, **House Rent Allowance (HRA)**, **Tax**, and the final **Take-Home Salary**.  
This system reduces manual work, avoids calculation errors, and simplifies salary management for organizations.

---

##  How to Run the Project

### Prerequisites
- Visual Studio 2019 or later  
- .NET Framework (MVC 5)  
- PostgreSQL

### Steps
1. **Clone the repository:**
   ```bash
   git clone https://github.com/yashsingh37/Payroll.git
2. Open the solution file

- Open PayRoll_Practies_Exam_2.sln in Visual Studio.

3. Restore dependencies

-Visual Studio will automatically restore missing NuGet packages.

4. Configure the database

-Open web.config

-Update the connection string if you are using SQL Server or LocalDB.

5. Run the project

-Press Ctrl + F5 or click Start Without Debugging in Visual Studio.

### Features

-Employee salary management system

-Automatic calculation of Basic, DA, HRA, and Tax

-Take-home salary generation

-User registration and login pages

-Clean and responsive design using Bootstrap

### Technologies Used

-Frontend: HTML, CSS, Bootstrap

-Backend: C#, ASP.NET MVC

-Database: PostgreSQL

-IDE: Visual Studio

### Salary Calculation Logic

-Basic Pay: 60% of total salary

-Dearness Allowance (DA): 25% of total salary

-House Rent Allowance (HRA): 15% of total salary

-Tax: 10% of (Salary − 25,000) if Salary > 25,000

-Take-Home Salary: Basic + DA + HRA − Tax

### Project Structure

-Controllers/   → Contains controller logic for Employee, User, etc.  
-Models/        → Holds data model classes (Employee, User, etc.)  
-Views/         → Contains all Razor view pages (.cshtml)  
-Content/       → CSS and styling files  
-Scripts/       → JavaScript and library files  
-everything/    → Additional CSS or external resources  
