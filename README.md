# Evona
This is a project that I created from scratch as a task for company called Evona using 
ASP.NET Core 5.0 Web API, SQL Server, and PostgreSQL.

# Requirements:
 Databases:
 -SQL Server ( SQL Server , graphical tool -> Microsoft SQL Server Management Studio )
 -PostgreSql ( Postgre Database Server, Graphical tool -> pgAdmin )

# Setup:
You have to set connection strings in appsettings.json inside the folder with path 'src/API' by your requirements.

- "EvonaTaskConnectionString" stands for PostgreSQL connection string. The most common case would be that you have to change your username and password.

- "EvonaTaskIdentityConnectionString" stands for SQL Server database string. In most common cases it would work properly, but also you can change that by your requirements.

After you set up connection strings, the next step you should do to properly work the entire application is:

Inside Package Manager Console you should run 2 commands:
 *Make sure if you want to update EvonaTaskDbContext your default project should be: src/Infrastructure/Evona.Task.Persistence and for update and update EvonaTaskIdentityDbContext default project should be src/Infrastructure/Evona.Task.Identity

 update-database -context EvonaTaskDbContext
 update-database -context EvonaTaskIdentityDbContext

 After running these two commands you will get users: 

        (Admin)
  Email: admin@evona.com
  Password: evonaadmin
  
        (User)
  Email: user@evona.com
  Password: evonauser

 After you update both databases you can run the application.

# Task:
Create 3 tables:
- Students (FirstName, LastName, JMBG, BirthDate)
- StudentsBackup - Copy of Students
- AdminUsers

Create API with methods:
- SearchStudents method (anonymous)
- AddStudent method (authorized)
- GenerateStudents method(authorized) for generating dummy records
- Send count limit for generating
- DeleteStudent method (authorized)
- Backup method (authorized) for copying data from Students to StudentsBackup

Bonus points:
- Role-based authorization
- Use repository pattern
- Caching
- Unit tests
- Performance
- Push code to Github
- PostgreSQL
Notice:

- You can create new tables or methods if necessary


# About the project: 
I decided to create this project as a good template for every startup project.

What do I implement?

-CQRS pattern (Command and Query Responsibility Segregation) that separates query and command for a data store. Commands stand for update data while query stands for reading data.

-SOLID principles: 
                S - Single-responsibility Principle
                O - Open-closed Principle
                L - Liskov Substitution Principle
                I - Interface Segregation Principle
                D - Dependency Inversion Principle
Design principles encourage us to create more maintainable, understandable, and flexible software. 

-Global Error Handling and Custom Exception ( Protect secret information for example about databases as well as other unnecessary messages to the clients and better understanding real problems )

-Register the NSwag middleware ( Generate the Swagger specification for implemented API and serve the Swagger UI for test the web API)

-Identity and JWT for secure application

-Moq and Shouldly Frameworks ( Help us for creating unit tests)

-Example of unit testing

-Memory caching ( If we have API that is very often called, caching is a very good solution because we save data for some period (maybe 30 sec) in cache memory then return result from the cache and avoid every single request made a call to a database.  )

-Tools: 
      MediatR ( Pattern/Library is used to reduce dependencies between objects )
      Automapper ( Object to object mapping automatically )
      Fluent API Validation ( Used for validation DTO-s before every interaction with database )

-Email service using SendGrid

# Me:
I hope this template will find someone who would start a project or learn with it.
If someone who sees this has some questions about the project or whatever else feel free to contact me at:
             Email: m.fazlic4@gmail.com
             LinkedIn: https://www.linkedin.com/in/muhamed-fazlic/

Have a great day and nice coding... :)
