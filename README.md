# Payroll Forecast Application

The Payroll Forecast Application is a web application that allows an employer (the end-user) to input employees, as well as their dependents, and get a preview of the yearly costs of benefits for them.

### Projects/Frameworks/Dependencies Used
* PayrollForecast.Api (Backend, Web Api written in ASP.NET Core 2.2)
  * EntityFrameworkCore 2.2 (SQL Server)
  * AutoMapper 8.0
* PayrollForecast.Client (Frontend, written in Angular 7.2)
  * Angular Material (7.2)
  * AutoMapper-TS (1.9)
* PayrollForecast.Test (Used for testing business requirements)

### Business Requirements of the Application
The following logic is in place when deducting benefit costs from an employee:
* All employees are paid $2000 per paycheck before deductions
* There are 26 paychecks in a year
* The cost of benefits is $1000/year for each employee
* Each dependent (children and possibly spouses) incurs a cost of $500/year
* Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

Please install the following on your development environment before installing the application:
* [Git](https://git-scm.com/downloads) v2.20+
* [NodeJS](https://nodejs.org/en/download/) v10.15+
* [.NET Core SDK](https://dotnet.microsoft.com/download) v2.2+
* [Angular CLI](https://cli.angular.io/) v7.2+
* [SQL Server 2017 Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express) 
  * **Please install LocalDb** - Please read https://www.mssqltips.com/sqlservertip/5612/getting-started-with-sql-server-2017-express-localdb/ if you do not have LocalDb installed.
  * :bell: **IMPORTANT - PLEASE READ** :bell: - Before you get started using LocalDb, you should patch SQL Server 2017 to the latest Cumulative Update. The reason is that there was initially a critical bug that prevented the creation of database files due to a missing slash in the file path.  The latest Cumulative Update can be [downloaded here](https://www.microsoft.com/en-us/download/details.aspx?id=56128).

### Installing

1. Open up a terminal (cmd) as Administrator.
2. Clone repository to a directory of your liking:
```
git clone https://github.com/tljesti/payroll-forecast.git
```
#### Setting up the backend Web Api
3. Once cloned, navigate to the following directory:
```
cd payroll-forecast\PayrollForecast.Api
```
4. Run the following to install necessary nuget packages for the Web Api project:
```
dotnet restore
```
5. Once all pacakges are restored, run the following to run the application:
```
dotnet run
```
The following will occur:
* A new database "EmployeeDb" will be created on the "(LocalDb)\MSSQLLocalDB" SQL Server Instance and will be seeded with sample Employee/Dependent data for the application.
* The web application will spin up, providing the web api endpoints necessary for the client application to run.  (example: http://localhost:5000/api/employees)
#### Setting up the frontend
6. Once we have verified that the Web Api is running, please open up another terminal window as Administrator.
7. Starting from the root directory of the git repository (payroll-forecast), navigate to the following directory:
```
cd PayrollForecast.Client
```
8. Run the following to install necessary client packages:
```
npm install
```
9. Once all packages are installed, run the following to compile and run the Angular application:
```
ng serve -o
```
* Please note that the client application will run on http://localhost:4200.

If all works well, then you will be greeted to the Employees component of the application:
![MyImage](https://i.imgur.com/nn8aHAb.png)

To observe the details of an employee (dependents, yearly payment information, etc), simply click on an employee record on the table.  This will take you to the details component for that employee:
![MyImage](https://i.imgur.com/GH4toW6.png)

* Please note that in order to stop the frontend/backend services running, simply Ctrl-C while inside of the terminals.

## Running the tests

To run tests against the business logic of the application, please perform the following steps:
1. Open up a new terminal window as Administrator
2. Navigate to the root directory where the local repository resides (payroll-forecast)
3. Navigate to the following:
```
cd PayrollForecast.Test
```
4. Run the following to restore the nuget packages of the test project
```
dotnet restore
```
5. Run the following command to start the tests
```
dotnet test -v n
```

## Authors

* **Tyler Jestice** 
