using Microsoft.EntityFrameworkCore;
using Models;

namespace Site.Data
{
	public class ApplicationContext : DbContext
	{
		public DbSet<FileModel> Files { get; set; }
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
		{
			Database.EnsureCreated();
		}
    }
}