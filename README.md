# Clicker
**Clicker** is a small web app where the goal is to click as fast as possible. With **Clicker**, you can register accounts and save your scores. Saved scores can be viewed on individual account pages or on the leaderboard.

In order to run **Clicker** on your PC there are two main requirements. 
1. Have Visual Studio installed
2. Have an SQL Server

Once these requirements are met, you can follow these steps:
1. Download **Clicker** and open `Clicker.sln` in Visual Studio
2. If you want to change the SQL database connection string, update `DatabaseConnectionString` in `Clicker/Models/Globals.cs` and `DefaultConnection` in `Clicker/appsettings.json`.
   However, If you just want to use a localhost database, then it should work as is.
3. Open the Nuget Package Manager Console under Tools in the Visual Studio toolbar.
4. In the console, enter `add-migration "InitialCreate"`
5. Then, if there are no errors, enter `update-database`.
6. From there, you can click the green run button up the top and the app will be hosted on `https://localhost:7256`

Notes:
- Clicker is only supported for screen sizes of 1920x1080 and larger. If your screen is smaller you will have to zoom out.
- For some reason the screen sometimes flickers black when changing endpoints. This was a problem since I initialized it as an ASP.NET Core project and I can not find the problem.
