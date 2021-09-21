using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) :base(opt)
        {
          
        }
          public DbSet<Platform> Platforms { get; set; }
    }

}