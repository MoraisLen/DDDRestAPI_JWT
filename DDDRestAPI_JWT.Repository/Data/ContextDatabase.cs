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
            optionsBuilder.UseSqlServer(connectionString: "Password=camocim360;Persist Security Info=True;User ID=apijwt;Initial Catalog=db_apijwt;Data Source=DESKTOP-8S4R9T9");
            //optionsBuilder.UseMySQL(connectionString: "Server=localhost;DataBase=db_restjwt;Uid=root;Pwd=");
        }
    }
}