using DDDRestAPI_JWT.Domain.Enties;
using Microsoft.EntityFrameworkCore;

namespace DDDRestAPI_JWT.Repository.Data
{
    internal class ContextDatabase : DbContext
    {
        public DbSet<ClientAPI> ClientAPIs { get; set; }
        public DbSet<User> Users { get; set; }

        public ContextDatabase()
        { }

        public ContextDatabase(DbContextOptions _context) : base(_context)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString: "Server=localhost;DataBase=db_restjwt;Uid=root;Pwd=");
        }
    }
}