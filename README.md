# Employee Management System Setup Guide

## Project Overview
This Employee Management System is built using:
- C#
- .NET Framework
- Guna UI
- ADO.NET (SQL Server)

## Prerequisites
Before setting up the project, ensure you have the following installed:

1. Visual Studio Community Edition
2. .NET Framework
3. SQL Server
4. Guna UI Framework

## Installation Steps

### 1. Install Visual Studio Community Edition
1. Visit the [Visual Studio downloads page](https://visualstudio.microsoft.com/vs/community/).
2. Download and run the Visual Studio Community installer.
3. In the installer, select the ".NET desktop development" workload.
4. Complete the installation process.

### 2. Install .NET Framework
The .NET Framework is usually included with Visual Studio. If not:
1. Visit the [.NET Framework download page](https://dotnet.microsoft.com/download/dotnet-framework).
2. Download and install the latest version compatible with the project.

### 3. Install Guna UI Framework
1. In Visual Studio, go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
2. Search for "Guna.UI2.WinForms" and install it in your project.

### 4. Set up the Database
1. Open SQL Server Management Studio (SSMS).
2. Create a new database named `EmployeeManagementDB` (or your preferred name).
3. Execute the SQL scripts provided in the project's `Database` folder to create the necessary tables and initial data.

### 5. Configure Connection String
1. In the solution, locate the `DataAccessSettings.cs` file.
2. Update the connection string to match your SQL Server settings:

```csharp
public static string ConnectionString = @"Data Source=YOUR_SERVER_NAME;Initial Catalog=EmployeeManagementDB;Integrated Security=True";
Replace YOUR_SERVER_NAME with your SQL Server instance name.
Running the Project

    Open the solution in Visual Studio.
    Build the solution (Build > Build Solution).
    Run the project (Debug > Start Debugging or press F5).

Troubleshooting

    If you encounter any issues with Guna UI, ensure you have the latest version installed.
    For database connection issues, verify your connection string and ensure SQL Server is running.

Contributing
Please read CONTRIBUTING.md for details on our code of conduct and the process for submitting pull requests.
License
This project is licensed under the MIT License - see the LICENSE.md file for details.
