using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Data
{
    public class MatrimonyDbContext : DbContext
    {
        public MatrimonyDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }
    }
}
