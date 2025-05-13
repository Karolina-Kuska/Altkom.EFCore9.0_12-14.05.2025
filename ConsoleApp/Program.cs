using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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