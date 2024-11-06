# Mr_XL Graduation Project

Welcome to the **Mr_XL Graduation Project** repository! This project is a web application designed to manage various aspects of student life at the university, including schedule management, grades, student info, payments, and academic planning. It serves as a graduation project showcasing various technologies such as .NET, Blazor, and web development best practices.

## Features

- **Student Dashboard**: Personalized dashboard showing the student's schedule, grades, balance, and bills.
- **Schedule Management**: View and manage your class schedule.
- **Grades**: Access your academic grades.
- **Student Information**: View personal and academic details such as ID, email, and course.
- **Payments and Balance**: View outstanding bills and payments.
- **Student Plan**: Access and view your academic plan.

## Technologies Used

This project utilizes the following technologies:
- **.NET Core**: Backend framework for handling business logic and data management.
- **Blazor**: Frontend framework to build interactive user interfaces with C#.
- **CSS**: Used for styling and layout of the application.
- **Entity Framework**: ORM for database interactions.
- **SQL Server**: Database for storing user and academic data.

## Setup and Installation

### Prerequisites

Ensure that you have the following tools installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- Visual Studio or Visual Studio Code (recommended)

### Clone the Repository

To get started, clone the repository:

```bash
git clone https://github.com/Aboda7m/Mr_XL-Graduation.git
Install Dependencies
Navigate to the project directory and restore the required packages:

bash
Copy code
cd Mr_XL-Graduation
dotnet restore
Set up Database
Ensure your database is set up correctly:

Configure your database connection in appsettings.json.
Apply database migrations:
bash
Copy code
dotnet ef database update
Run the Application
To run the application locally, execute the following command:

bash
Copy code
dotnet run
The application should now be accessible at https://localhost:5001 in your browser.

Usage
Navigate to the login page and enter the student credentials.
Once logged in, you will be redirected to the student dashboard, which contains links to various sections such as Schedule, Grades, Student Info, Payments, and Student Plan.
Each section allows you to view or manage your relevant data.
Folder Structure
Data: Contains database-related files and migrations.
Models: Contains the C# models for user and student data.
Pages: Contains Blazor pages for the UI, including the student dashboard, schedule, grades, etc.
wwwroot/css: Contains CSS files for styling.
appsettings.json: Configuration file for database connections and application settings.
Program.cs: The main entry point for the application.
Contributing
We welcome contributions! If you would like to contribute, please follow these steps:

Fork the repository.
Create a new branch (git checkout -b feature/your-feature).
Make your changes.
Commit your changes (git commit -am 'Add new feature').
Push to the branch (git push origin feature/your-feature).
Create a pull request.
License
This project is licensed under the MIT License - see the LICENSE file for details.

Acknowledgements
Special thanks to the university and faculty for their support throughout this project.
Thanks to open-source libraries and communities that made this project possible.
Contact
For any questions, feel free to reach out to the contributors:

Aboda7m - @Aboda7m
abdulrahmanxl - @abdulrahmanxl
markdown
Copy code

### Explanation:

- **Features**: Describes the main features of the application.
- **Technologies Used**: Lists all the key technologies employed in the project.
- **Setup and Installation**: Provides instructions to clone, install, and run the project locally.
- **Usage**: Outlines how users can interact with the application after logging in.
- **Folder Structure**: Gives a brief overview of the project's structure and important directories/files.
- **Contributing**: Encourages contributions and explains how to do so.
- **License**: States the licensing terms for the project (MIT in this case).
- **Contact**: Provides contact information for contributors.

Let me know if you need further customization!