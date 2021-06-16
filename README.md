# PlannR 

[![PlannR-CI](https://github.com/OwenSteele/PlannR/actions/workflows/dotnet.yml/badge.svg)](https://github.com/OwenSteele/PlannR/actions/workflows/dotnet.yml)

## [![gh-pages](https://github.com/OwenSteele/PlannR/actions/workflows/publish.yml/badge.svg)](https://owensteele.github.io/PlannR/) **:point_left: click to see PlannR website!**

### ```Written and Designed by Owen Steele```

#### *Plan and save all parts of your trips in one place. Blazor ASP.NET Core with Clean Architecture and CQRS linked to EF Core*



# :paintbrush: Design and Features

* **Clean/Onion Architecture** Design Style
  * MediatR for loose-coupling
* **CQRS** design
* Uses **Identity** alongside PlannR Database
* **EF Core used** for data persistence, code-first design


* **Client-Side Blazor App**
* **Public WebAPI**
  * built to **Swagger v3** standards
  * **JWT token Authentication**

# :vertical_traffic_light: Use PlannR

* **Click the 'Deploy PlannR App' button above** - to go to the client app, hosted on gh-pages
* **Or see enviroments section above the readme**
* The API is hosted on Azure, swagger docs: https://plannr-api.azurewebsites.net/swagger/index.html

:warning: The API is running on a low-cost service (D1 shared), meaning that loading times and querying the API through the client app can have longer response times.

# :running_woman: Run PlannR locally

1. Download (and unpack) or clone the repo
2. navigate to the root and restore dependencies folder:
```
$ cd .\PlannR
Plannr> $ dotnet restore
```
3. Create the databases from the existing migrations:
     * :warning: This requires mutiple install to build the SQL databases:
         * 	:link: [EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install "EF Core install")
         * 	:link: [Microsoft SQL server](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads "MS SQL server install page")
4. With the required software, navigate to the identity and persistence projects
```
// Starting in the root folder:
PlannR>                 $ cd .\PlannR.Identity
PlannR\PlannR.Identity> $ dotnet-ef database update -s ..\PlannR.API\PlannR.API.csproj --context PlannrIdentityDb

// Navigate back to root folder and repeat for PlannR database:
PlannR\PlannR.Identity>    $ cd ..
PlannR>                    $ cd .\PlannR.Persistence
PlannR\PlannR.Persistence> $ dotnet-ef database update -s ..\PlannR.API\PlannR.API.csproj --context PlannrDb
```
5. To seed the databases, uncomment code lines **~117-131** in file name below. This needs to be done **before** running the App.
```
/PlannR.Persistence/PlannRDbContext.cs
```
7. To run PlannR, both the API and the client App need to be running:

 * :infinity: If using Visual Studio, right-click on the solution and select 
    * **properties -> 'Common properties' -> 'Startup Project'**
    * then set **PlannR.App** and **Plannr.API** to 'start' actions 
 * :new: Alternatively in two terminal windows:
```
// Navigate back to root folder if not done already
PlannR\PlannR.Persistence> $ cd ..
PlannR>                    $ cd .\PlannR.API
PlannR\PlannR.API>         $ dotnet run
```
```
// New window, navigate to PlannR root folder:
PlannR>            $ cd .\PlannR.App
PlannR\PlannR.App> $ dotnet run
```

# :building_construction: Planned Updates and Features

**As this is a portfolio project some back-end features (API methods and calls, repository calls) have not yet been implemented for use in the App, but are planned to be added:**
* Sorting and filtering of results in overview pages
* Higher detail map of areas, using the [**wrld3D** package](https://www.wrld3d.com)
* Possible addition of refresh tokens, instead of sign-in required after token/session expiry
* Addition of files from users for bookings - [with safety validation checks](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0).
