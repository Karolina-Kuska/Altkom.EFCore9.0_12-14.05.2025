using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");
IConfiguration configuration = configurationBuilder.Build();

//var connectionString = "Server=(local);Database=EF;Integrated security=true;TrustServerCertificate=true";



using (var context = ContextWithDependencyInjection(configuration))
{
    context.Database.EnsureDeleted();
}

using (var context = ContextWithDbContextOptions(configuration))
{
    context.Database.EnsureCreated();
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
        .Options;

    return new MyContext(options);
}