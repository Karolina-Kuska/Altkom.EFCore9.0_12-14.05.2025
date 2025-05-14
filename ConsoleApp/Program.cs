using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Components;
using Models.Inheritance;
using Models.Relations;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");
IConfiguration configuration = configurationBuilder.Build();

//var connectionString = "Server=(local);Database=EF;Integrated security=true;TrustServerCertificate=true";



/*using (var context = ContextWithDependencyInjection(configuration))
{
    context.Database.EnsureDeleted();
}*/

using (var context = ContextWithDbContextOptions(configuration))
{

    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

//AddUpdate(configuration);

string[] statuses = new[] { "A", "B", "C", "D" };


using (var context = ContextWithDbContextOptions(configuration))
{
    foreach (var item in statuses)
    {
        context.Add(new Status { Id = item });
    }

    var component = new Component();

    context.Add(component);
    context.SaveChanges();

}


var timer = new System.Diagnostics.Stopwatch();
timer.Start();
for (int i = 0; i < 1000; i++)
{
    using (var context = ContextWithDbContextOptions(configuration))
    {
        var subComponent = new SubComponent();
        subComponent.Component = new Component { Id = 1 };
        subComponent.Status = new Status { Id = statuses[i % statuses.Length] };

        context.Attach(subComponent.Component);
        context.Attach(subComponent.Status);

        context.Add(subComponent);

        context.SaveChanges();
    }
}
timer.Stop();

Console.WriteLine(timer.ElapsedMilliseconds);
Console.ReadLine();

timer = new System.Diagnostics.Stopwatch();
timer.Start();
using (var context = ContextWithDbContextOptions(configuration))
{
    for (int i = 0; i < 1000; i++)
    {

        var subComponent = new SubComponent();
        subComponent.Component = new Component { Id = 1 };
        subComponent.Status = new Status { Id = statuses[i % statuses.Length] };

        context.Attach(subComponent.Component);
        context.Attach(subComponent.Status);

        context.Add(subComponent);

        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}
timer.Stop();

Console.WriteLine(timer.ElapsedMilliseconds);
Console.ReadLine();


static MyContext ContextWithDependencyInjection(IConfiguration configuration)
{
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddDbContext<MyContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString(nameof(MyContext))));

    var serviceProvider = serviceCollection.BuildServiceProvider();

    return serviceProvider.GetRequiredService<MyContext>();
}

static MyContext ContextWithConnectionString(IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("MyContext")!;
    return new MyContext(connectionString);
}

static MyContext ContextWithDbContextOptions(IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("MyContext")!;

    var builder = new DbContextOptionsBuilder<MyContext>();
    var options = builder.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine)
        .Options;

    return new MyContext(options);
}

static void Modeling(IConfiguration configuration)
{
    /*using (var context = ContextWithDbContextOptions(configuration))
    {
        var car = new Car() { Model = Random.Shared.Next().ToString() };
        var registration = new Registration() { Number = Random.Shared.Next().ToString() };
        car.Registration = registration;
        context.Add(car);

        car = new Car() { Model = Random.Shared.Next().ToString() };
        registration = new Registration() { Number = Random.Shared.Next().ToString() };
        registration.Car = car;

        context.Add(registration);
        context.SaveChanges();
    }
    */
    /*using (var context = ContextWithDbContextOptions(configuration))
    {
        var car = new Car() { Model = Random.Shared.Next().ToString() };
        var engine = new Engine() { Power = Random.Shared.Next() };
        car.Engine = engine;
        engine.Cars.Add(car);
        //context.Add(car);

        car = new Car() { Model = Random.Shared.Next().ToString() };
        car.Engine = engine;
        engine.Cars.Add(car);
        //context.Add(car);

        context.Add(engine);

        context.SaveChanges();
    }*/

    /*using (var context = ContextWithDbContextOptions(configuration))
    {
        var driver = new Driver() { Name = Random.Shared.Next().ToString() };
        var car = new Car() { Model = Random.Shared.Next().ToString() };
        car.Drivers.Add(driver);

        context.Add(car);

        car = new Car() { Model = Random.Shared.Next().ToString() };
        driver.Car.Add(car);

        context.Add(driver);

        context.SaveChanges();
    }*/


    using (var context = ContextWithDbContextOptions(configuration))
    {
        //eager loading = wczesne ładowanie - ładowanie powiązanych danych z wykorzystaniem Include
        //zaleca się gdy ilość Include jest nie większa niż 2-3
        var cars = context.Set<Car>().Include(x => x.Registration).Include(x => x.Engine).ToList();
    }


    using (var context = ContextWithDbContextOptions(configuration))
    {
        var cars = context.Set<Car>().ToList();

        //explicit loading = jawne ładowanie - dane ładowane są w późniejszym czasie do kontekstu i wiązane z danymi już się tam znajdującymi
        context.Entry(cars.Last()).Reference(x => x.Engine).Load();
        context.Set<Registration>()/*.Where(x => x.Number.Contains("0"))*/.Load();
    }



    using (var context = ContextWithDbContextOptions(configuration))
    {
        /*var company = new Company { Name = "A", NumberOfWorkers = Random.Shared.Next() };
        var companyS = new SmallCompany { Name = "B", OwnerName = "S1" };
        var companyL = new LargeCompany { Name = "C", OwnerName = "S2" , CoOwnerName = "L1"  };

        context.Add(company);
        context.Add(companyS);
        context.Add(companyL);
        context.SaveChanges();*/

        var companies = context.Set<AbstractCompany>().ToList();
    }

    using (var context = ContextWithDbContextOptions(configuration))
    {
        /*var person = new Person { Age = 30, LastName = "Last", Name = "First", PESEL = 12345678901 };
        var student = new Student { Age = 20, LastName = "SLast", Name = "SFirst", PESEL = 12345678901, IndexNumber = Random.Shared.Next() };
        var educator = new Educator { Age = 40, LastName = "ELast", Name = "EFirst", PESEL = 12345678901, Salary = Random.Shared.Next(), Specialization = "S" };

        context.Add(person);
        context.Add(student);
        context.Add(educator);
        context.SaveChanges();*/

        var people = context.Set<Person>().ToList();

    }

    using (var context = ContextWithDbContextOptions(configuration))
    {
        /*var animal = new Animal { Name = "A", Species = "A" };
        var dog = new Dog { Name = "D", Species = "D", Breed = "D" };
        var cat = new Cat { Name = "C", Species = "C", Color = "C" };

        context.Add(animal);
        context.Add(dog);
        context.Add(cat);
        context.SaveChanges();*/

        var animals = context.Set<Animal>().ToList();
        var cats = context.Set<Cat>().ToList();

    }


    using (var context = ContextWithDbContextOptions(configuration))
    {
        /*var user = new User { Username = Random.Shared.Next().ToString(), UserType = UserType.Admin, Password = "alamakota" };
         context.Add(user);
         var user2 = new User { Username = Random.Shared.Next().ToString(), UserType = UserType.User, Password = "alamakota" };
         context.Add(user2);

         context.SaveChanges();*/

        var users = context.Set<User>().ToList();
    }

    using (var context = ContextWithDbContextOptions(configuration))
    {
        var userType = "Admin; DELETE FROM Animal";

        //var users = context.Set<User>().FromSqlRaw("EXEC GetUserByType @p0", userType).ToList();
        var users = context.Set<User>().FromSqlInterpolated($"EXEC GetUserByType {userType}").ToList();
    }
}

static void AddUpdate(IConfiguration configuration)
{
    using (var context = ContextWithDbContextOptions(configuration))
    {

        var person = new Person { Age = 30, LastName = "Kowalski", Name = "Jan", PESEL = 12345678901 };

        //odwołujemy się do konkretnej tabeli poprzez DBSet<T> zadeklarowany w kontekście
        context.People.Add(person);

        var student = new Student { Age = 20, LastName = "Nowak", Name = "Anna", PESEL = 12345678901, IndexNumber = Random.Shared.Next() };

        //odwołujemy się do konkretnej tabeli poprzez generyczną metodę Set<T>()
        context.Set<Student>().Add(student);

        person = new Educator { Age = 40, LastName = "Kowalska", Name = "Joanna", PESEL = 12345678901, Salary = Random.Shared.Next(), Specialization = "Matematyka" };

        //odwołujemy się do metody, która automatycznie wybiera odpowiednią tabelę na podstawie typu
        context.Add(person);

        context.SaveChanges();
    }



    using (var context = ContextWithDbContextOptions(configuration))
    {

        var car = new Car() { Model = Random.Shared.Next().ToString() };
        context.Add(car);
        context.SaveChanges();

        car = new Car() { Model = Random.Shared.Next().ToString() };
        car.Registration = new Registration() { Number = Random.Shared.Next().ToString() };
        context.Add(car);

        Console.WriteLine(context.ChangeTracker.DebugView.ShortView);
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        context.SaveChanges();
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        car.Model = "Opel";
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        //zmiany w ChangeTracker są widoczne dopiero po wywołaniu DetectChanges, SaveChanges lub odwołaniu się do Entry
        context.ChangeTracker.DetectChanges();
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        context.SaveChanges();
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        car.Model = "alamakota";
        Console.WriteLine(context.Entry(car).State);
    }



    using (var context = ContextWithDbContextOptions(configuration))
    {
        var car = new Car() { Model = Random.Shared.Next().ToString(), Id = 2 };


        //context.Set<Car>().Add(car);
        context.Update(car);

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);


        //możemy wysterować co ma być aktualizowane w bazie danych
        context.Entry(car).Property(x => x.RegistrationId).IsModified = false;
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        //możemy też zmienić stan całej encji
        //context.Entry(car).State = EntityState.Deleted;

        context.SaveChanges();
    }

    using (var context = ContextWithDbContextOptions(configuration))
    {
        var car = new Car() { Model = Random.Shared.Next().ToString() };
        //update działa jak AddOrUpdate w zależności od wartości klucza głównego (jeśli jest 0 to dodaje, jeśli jest > 0 to aktualizuje)
        context.Update(car);

        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        //context.SaveChanges();
    }


    using (var context = ContextWithDbContextOptions(configuration))
    {
        var registration = new Registration() { Number = Random.Shared.Next().ToString() };
        registration.Car = new Car { Id = 1 };

        //podłączenie obiektu do kontekstu i uznanie go za istniejący i niezmieniony w stosunku do tego co jest w bazie danych
        context.Attach(registration.Car);
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        //add bez zastosowania Attach spowoduje dodanie nowego samochodu z ustawionym ID (co spowoduje błąd bo ID jest generowanie przez bazę danych)
        context.Add(registration);
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        context.SaveChanges();
    }
}