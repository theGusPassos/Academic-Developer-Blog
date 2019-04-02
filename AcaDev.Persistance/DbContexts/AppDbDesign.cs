using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AcaDev.Persistance.DbContexts
{
    public class AppDbDesign : IDesignTimeDbContextFactory<AppDbContext>
    {
        public static string ConnectionString;

        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            // the UseSqlServer will only be available if the SqlServer
            // package was downloaded
            builder.UseSqlServer(ConnectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
