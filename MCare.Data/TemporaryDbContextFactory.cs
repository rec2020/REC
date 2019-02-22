
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace MCare.Data
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<MCareContext>
    {
        public MCareContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MCareContext>();
            builder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=MCareDb;User Id=postgres;Password=wajdy6587",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MCareContext).GetTypeInfo().Assembly.GetName().Name));
            return new MCareContext(builder.Options);
        }
    }
}
