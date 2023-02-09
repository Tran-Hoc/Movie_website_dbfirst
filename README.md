# Movie_website_dbfirst

### Sql server
### Database first
### command in package manager console: 
> https://learn.microsoft.com/en-us/ef/core/cli/powershell

### create model
> Scaffold-DbContext "Data Source=.\\Sqlexpress;Initial Catalog=Movie_DbFirst;Integrated Security=True; TrustServerCertificate=True; User ID=xnxx;Password=123456789;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

### Update database model: 
> Scaffold-DbContext "Data Source=DESKTOP-7MRL7G7\SQLEXPRESS;Initial Catalog=Movie_DbFirst;Integrated Security=True; TrustServerCertificate=True; User ID=sa;Password=1234"  Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -ContextDir DataContext -DataAnnotations -Force

### Step
1. create service interface, implement
2. inject 
3. builder.Service.AddScope<Interface, Implement>();
> - Transient objects are always different; a new instance is provided to every controller and every service.
> - Scoped objects are the same within a request, but different across different requests
> - Singleton objects are the same for every object and every request (regardless of whether an instance is provided in ConfigureServices)

4. ...

