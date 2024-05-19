using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace webApi.ContextFactory;

public class RepositoryContextFaactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {

        //configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        //DbContexOptions
        var builder=new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            prj=>prj.MigrationsAssembly("webApi"));

        return new RepositoryContext(builder.Options);
    }
}
