
# Fitlife .netCore MVC Web App

This project is a fitness automation system built on the .NET Core MVC framework, employing N-layer architecture for efficient organization and scalability. The system leverages various technologies to provide a seamless user experience.





### Features:

- Entity Framework: The project utilizes Entity Framework for data access, allowing seamless interaction with the underlying database.

- Bootstrap: Bootstrap is employed for frontend development, ensuring responsive and visually appealing user interfaces across devices.

- Chart.js: Integration with Chart.js enables the visualization of fitness-related data, providing users with insightful analytics and progress tracking.

- CSS Styling: CSS is utilized for styling the application, ensuring a polished and cohesive user interface design.

### Functionality:

- Authentication: The system implements cookie-based authentication for secure user login and session management. This ensures that only authorized users can access the system's functionalities.

- Session Management: HTTPContext session is employed for efficient session management, enabling the persistence of user-specific data across multiple requests. This ensures a seamless and personalized user experience throughout the application.

### Architecture:

- Presentation Layer: Contains the MVC components responsible for handling user interaction and displaying the user interface.

- Business Logic Layer: Implements the core business logic of the application, including data validation, processing, and manipulation.

- Data Access Layer: Interacts with the database through Entity Framework, encapsulating all database-related operations.

- Infrastructure Layer: Houses cross-cutting concerns such as authentication, logging, and caching.

### Summary:

In summary, this .NET Core MVC project embodies a comprehensive fitness automation solution, offering a user-friendly interface, and advanced visualization features. Leveraging N-layer architecture, the project ensures scalability, maintainability, and security, making it an ideal choice for fitness enthusiasts and professionals alike.
##  Cloud Database


In our .NET Core project, we have integrated Amazon RDS (Relational Database Service) with a PostgreSQL engine to leverage the power and scalability of cloud databases. Amazon RDS offers a managed database service that simplifies database administration tasks such as hardware provisioning, database setup, patching, and backups, allowing us to focus more on developing our application.

### Benefits:

- Scalability: With Amazon RDS, we can easily scale our PostgreSQL database instance vertically or horizontally to accommodate changes in traffic patterns or data volume.

- High Availability: Amazon RDS provides built-in high availability and automatic failover capabilities, ensuring that our application remains accessible even in the event of hardware or software failures.

- Security: Amazon RDS offers various security features such as network isolation, encryption at rest and in transit, and automated backups, helping us to maintain the confidentiality and integrity of our data.

- Performance: By leveraging Amazon RDS, we can take advantage of performance optimizations and best practices implemented by AWS, resulting in improved database performance and responsiveness.

### Implementation:

- Configuration: We configured our .NET Core application to connect to the Amazon RDS PostgreSQL instance using connection strings provided by AWS. This involved specifying the database endpoint, credentials, and other necessary parameters.

- Database Management: With Amazon RDS, we can easily manage our PostgreSQL database through the AWS Management Console, AWS CLI, or programmatically via AWS SDKs. Tasks such as creating database snapshots, resizing instances, and applying patches can be performed seamlessly.

- Monitoring and Optimization: Amazon RDS offers comprehensive monitoring tools such as Amazon CloudWatch, which allows us to monitor database performance metrics, set up alarms, and troubleshoot issues proactively. Additionally, we can optimize database performance by utilizing features like Read Replicas and Performance Insights.

### Conclusion:

Integrating Amazon RDS with PostgreSQL engine in our .NET Core project has provided us with a robust, scalable, and cost-effective solution for managing our relational database requirements. By offloading administrative tasks to AWS, we can focus our efforts on developing features and delivering value to our users, while ensuring that our data remains secure and highly available.
## Authentication And User Management


This project is aimed at developing a user management system using .NET Core. The core component of the project seems to be the "AppUser" class, which likely encapsulates basic user information such as username, password, email, etc., along with potentially additional properties. Additionally, it incorporates security features such as Two-Factor Authentication (2FA) and hashing.

- Two-Factor Authentication (2FA) goes beyond just using a password for user login by requiring a second authentication step typically through a device (phone, physical key, etc.), adding an extra layer of security and authentication for authorized access.

- Hashing passwords is a crucial aspect of securely storing user credentials. Passwords are typically stored using hash functions, ensuring they are irreversibly transformed and securely stored.

- Another notable feature of this project is the inclusion of a password reset mechanism using a mail sender utility, providing users with a secure way to reset their passwords in case of forgetting them.

- Furthermore, Google Authentication appears to be integrated into the project, possibly as an option for users to authenticate using their Google accounts, adding flexibility and convenience to the authentication process.

## Architecture

### Presentation Layer:

#### Responsibilities:

- Handles user interaction and input through the user interface.

- Renders views and presents data to the user.

- Sends user requests to the appropriate controllers for processing.

#### Key Components:

- Views: HTML templates that define the user interface.

- Controllers: Classes that handle user requests, invoke business logic, and return appropriate responses.

### Business Logic Layer (Service Layer):

#### Responsibilities:

- Implements the core business logic and rules of the application.

- Validates user input and enforces business constraints.

- Orchestrates interactions between different components of the application.

#### Key Components:

- Services: Classes that encapsulate business logic and operations related to specific features or entities.

- DTOs (Data Transfer Objects): Objects used to transfer data between layers, often representing entities or complex data structures.

### Data Access Layer:

#### Responsibilities:

- Interacts with the database to perform CRUD (Create, Read, Update, Delete) operations.

- Converts data between database entities and application objects.

- Manages database connections, transactions, and performance optimizations.

#### Key Components:

- Entity Framework Context: Represents the database context and manages interactions with the database.

- Entity Models: Classes that map to database tables and define the structure of the data.

###  Infrastructure Layer:

#### Responsibilities:

- Houses cross-cutting concerns and infrastructure-related functionalities.

- Provides services such as authentication, logging, caching, and error handling.


#### Key Components:

- Authentication Middleware: Implements cookie-based authentication and manages user sessions.

- Logging Middleware: Logs application events and errors for monitoring and debugging purposes.

- HTTPContext Session: Manages user-specific session data stored on the server side.

## Basic Model structure

### User :

- Properties: ID, Username, Password (hashed), Email, Role, etc.

- Relationships: May have relationships with other entities such as UserProfile, UserRole, etc.

### Fitness Activity :

- Properties: ID, Name, Description, Duration, CaloriesBurned, Date, etc.

- Relationships: May have relationships with User (owner), WorkoutPlan, etc.

### WorkOut Plan :

- Properties: ID, Name, Description, Duration, DifficultyLevel, etc.

- Relationships: May have relationships with User (owner), FitnessActivity, etc.

### DTOs :

- Used for transferring data between layers and components.

- Example DTOs: UserDTO, FitnessActivityDTO, WorkoutPlanDTO, etc.
## Used Technologies

![Bootstrap Badge](https://img.shields.io/badge/Bootstrap-7952B3?logo=bootstrap&logoColor=fff&style=for-the-badge)
![HTML5 Badge](https://img.shields.io/badge/HTML5-E34F26?logo=html5&logoColor=fff&style=for-the-badge)
![CSS3 Badge](https://img.shields.io/badge/CSS3-1572B6?logo=css3&logoColor=fff&style=for-the-badge)
![JavaScript Badge](https://img.shields.io/badge/JavaScript-F7DF1E?logo=javascript&logoColor=000&style=for-the-badge)
![TypeScript Badge](https://img.shields.io/badge/TypeScript-3178C6?logo=typescript&logoColor=fff&style=for-the-badge)
![Chart.js Badge](https://img.shields.io/badge/Chart.js-FF6384?logo=chartdotjs&logoColor=fff&style=for-the-badge)
![jQuery Badge](https://img.shields.io/badge/jQuery-0769AD?logo=jquery&logoColor=fff&style=for-the-badge)
![npm Badge](https://img.shields.io/badge/npm-CB3837?logo=npm&logoColor=fff&style=for-the-badge)
![Amazon AWS Badge](https://img.shields.io/badge/Amazon%20AWS-232F3E?logo=amazonaws&logoColor=fff&style=for-the-badge)
![Amazon RDS Badge](https://img.shields.io/badge/Amazon%20RDS-527FFF?logo=amazonrds&logoColor=fff&style=for-the-badge)
![PostgreSQL Badge](https://img.shields.io/badge/PostgreSQL-4169E1?logo=postgresql&logoColor=fff&style=for-the-badge)
![.NET Badge](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge)
![Google Authenticator Badge](https://img.shields.io/badge/Google%20Authenticator-4285F4?logo=googleauthenticator&logoColor=fff&style=for-the-badge)

  
## Run On Your Computer

Clone the project

```bash
  git clone https://github.com/fatihserhatturan/Fitlife
```

Switch to directory

```bash
  cd Fitlife
```

Build the project

```bash
  dotnet build

```
Manage the dependence

```bash
  dotnet restore

```

Install required packages

```bash
  dotnet add package Microsoft.EntityFrameworkCore

```
```bash
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer

```

```bash
  dotnet add package Microsoft.EntityFrameworkCore.Design

```

```bash
  dotnet add package Microsoft.EntityFrameworkCore.Tools

```

Run the server

```bash
  run dotnet 
```

  
## Licenses

[MIT](https://choosealicense.com/licenses/mit/)

  


