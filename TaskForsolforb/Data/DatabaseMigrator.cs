using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Infrastructure.Persistence;

namespace TaskForsolforb.Data
{
    public class DatabaseMigrator
    {
        
        private readonly AppDbContext appDbContext;

        public DatabaseMigrator( AppDbContext appDbContext)
        {
           
            this.appDbContext = appDbContext;
        }

        public async Task MigrateAsync()
        {
            
            await appDbContext.Database.MigrateAsync();
        }
    }
}
