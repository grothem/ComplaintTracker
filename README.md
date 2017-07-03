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

If you don't want the angular application to be automatically built, remove the "Build Angluar" target from the .csproj file. Now to run the angular app, open the project in your favorite IDE (I use Visual Studio Code), and edit the proxy.config.json so the target matches the location of where your backend is being hosted, and run the following command: 
```
ng serve --proxy-config proxy.config.json
```
This will proxy the angular app calls to the ASP.Net Core Server, instead of the default localhost:4200
