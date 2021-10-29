# Starter 
+ Starter
  - https://github.com/dotnet-architecture/eShopOnWeb/wiki/Getting-Started-for-Beginners
  - Solution Structure
    As applications grow in size, it can be worthwhile to break them up into several projects, usually based on their focus. 
    This follows the Separation of Concerns principle, and common examples of focus for individual portions of an application are user interface (UI), business logic, and data access or infrastructure. 
    The solution has been split up into three main application Layer:
        Core
	Infrastructure
	Presentation

The business logic and domain model are kept in the ApplicationCore project. Data access and other infrastructure plumbing code belongs in the Infrastructure project. And ASP.NET Core (Web) concerns belong in the Web project. The solution also has a number of different kinds of automated tests, found in separate Test folders. Projects depend on one another and can help enforce the direction of dependencies. In this case, we don't want our business logic to depend on low level plumbing code like that found in the Infrastructure project, so we structure the dependency direction so that Infrastructure depends on Application Core. 
+ Follow instruction: https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/?fbclid=IwAR2kIDSzEZZm46rEd3CMTm2f7ImGZSOTl6MA1Cu-DPa1LBU6ArgRjMt44NI
  - Implement Custom User 
+ Implement External Login
  - Facebook Login Follow instruction: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/facebook-logins?view=aspnetcore-5.0
  - Google Login Follow instruction: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-5.0
+ Modify Identity Page After Implement External Login.
  - Register Page.
  - Login Page.
  - Not sure other page are ok.
+ Follow instruction:https://codewithmukesh.com/blog/integrating-adminlte-with-aspnet-core/
  - Implement: AdminLTE theme 3.1 (Login and Register Page)
  - Update Latest Version of Bootstrap 5.1 and jQuery 3.6
+ Referencen link:https://codewithmukesh.com/blog/onion-architecture-in-aspnet-core/

