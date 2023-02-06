# Movie_website_dbfirst

Sql server
Database first
command in package manager console: https://www.entityframeworktutorial.net/efcore/pmc-commands-for-ef-core-migration.aspx

Scaffold-DbContext "Data Source=.\\Sqlexpress;Initial Catalog=Movie_DbFirst;Integrated Security=True; TrustServerCertificate=True; User ID=xnxx;Password=123456789;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

create service interface, implement
//inject 
builder.Service.AddScope<Interface, Implement>();
...

