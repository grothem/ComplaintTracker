# ComplaintTracker
Citizen Complaint Tracker ASP.NET Core App w/ Angular 4

# Prerequisites
.NET Core

The Angular portion of this app was generated using the Angular CLI tools, which requires Node 6.9.0 or higher, together with NPM 3 or higher.

# Instructions
If your using Visual Studio 2017, open the solution and build it (all dependencies should be automatically installed), otherwise, open terminal or command line in the project folder and run: 
```
npm install
dotnet build
dotnet run
```
The angular app is configured to build with the solution (see .csproj file)

The default database connection string uses the SQL Server Express LocalDB feature. If running on a mac, this feature is not avaiable, so you will need to provide a valid connection string to a SQL Server (Azure hosted Db, Docker, etc.)
