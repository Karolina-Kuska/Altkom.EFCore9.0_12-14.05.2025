using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
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
    context.Database.Migrate();
}



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