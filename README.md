ZAGADNIENIA
1. Podstawy
   - Instalacja Entity Framework Core
   - Utworzenie kontekstu DbContext
   - Dostawcy baz danych
   - Konfiguracja parametrów połącznia do bazy danych
2. Tworzenie nowego połączenia
   - Code First
   - Database First
3. Konwencje
4. Tworzenie modelu
   - Klucze
   - Indeksy
   - Właściwości w tle
   - Konwertery wbudowane
   - Kolejność kolumn
5. Konfiguracja encji
   - Adnotacje
   - Fluent API
6. Dziedziczenie
   - TPH (table-per-hierarchy)
   - TPT (table-per-type)
   - TPC (table-per-concrete)
7. Relacje
   - Jeden-do-jeden
   - Jeden-do-wielu
   - Wiele-do-wielu
8. Migracje
   - Dodawanie
   - Usuwanie
   - Aktualizacja bazy danych
   - Pakiety migracji
9. Zarządzanie danymi
   - Operacje CRUD
   - Wzorzec repozytorium
   - Wzorzec repozytorium generyczne
10. SQL
   - Uruchamianie poleceń SQL
   - Przekazywanie parametrów
   - Uruchamianie procedur składowych
11. Operacje asynchroniczne
   - Zapytania asynchroniczne
   - Zapis asynchroniczny
12. Diagnostyka

--------------------------------------------------

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
