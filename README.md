* Pakiety
```
Microsoft.EntityFrameworkCore.SqlServer - dostawca bazy danych
Microsoft.EntityFrameworkCore.Design - umożliwia migracje
Microsoft.EntityFrameworkCore.Tools - umożliwia migracje w PMC (dla VisualStudio)
```
   
* ConnectionString dla MSSql
```
Server=(localdb)\mssqllocaldb;Database=<name>;[AttachDBFilename=<file path>]
Sercer=(local);Database=<name>;Integrated security=true;Trust server certificate=true
Sercer=<ip>;Database=<name>;User Id=<user>;Password=<password>;Trust server certificate=true
Sercer=(local)\SQLExpress;Database=<name>;Integrated security=true;Trust server certificate=true
```

* dotnet-ef (CLI)
```
dotnet tool install --global dotnet-ef [--version 9.0.4]
dotnet tool uninstall --global dotnet-ef
```

* Migracje
   * CLI
   ```
   dotnet ef migrations add <nazwa>
   dotnet ef migrations remove [-f]
   
   dotnet ef database update [--connection "<connection string>"] 
   ```
   
   * Package Manager Console
   ```
   Add-Migration <nazwa>
   Remove-Migration [-f]
   
   Update-Database [-connection "<conneciton string>"]
   ```
* Db First
  * CLI
  ```
  dotnet ef dbcontext scaffold <connection string> <provider package> [--output-dir <folder>] [--context <context name>] [-f]
  dotnet ef dbcontext scaffold "Server=(local);Database=EF;Integrated security=true;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context MyContext -f
  ```
  * PMC
  ```
  dotnet ef dbcontext scaffold  <connection string> <provider package> [--output-dir <folder>] [--context <context name>] [-f]
  dotnet ef dbcontext scaffold "Server=(local);Database=EF;Integrated security=true;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context MyContext -f
  ```
