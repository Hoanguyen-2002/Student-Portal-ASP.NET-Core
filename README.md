Dotnet Command EF+Migration
<pre>
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet ef migrations add InitialCreate
</pre>

Connect Entity Framework to SQL Server using custom Connection String in upsetting.json by command:
 <pre>"ConnectionStrings": {
    "StudentPortal": "Server=localhost;Database=Database name;User Id=sa;Password=123456aA@$;Trusted_Connection=False(In MACOS Docker Container);TrustServerCertificate=True"
  }
</pre>

Add database into SQL Server Management
<pre>
dotnet ef database update [MigrationName]
</pre>