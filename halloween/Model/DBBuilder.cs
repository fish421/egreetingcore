using Microsoft.EntityFrameworkCore;

namespace halloween.Model
{
    public class DBBuilder : DbContext
    {
        // HEY! ADD THESE CONTRUCTORS!
        public DBBuilder() { }
        public DBBuilder(DbContextOptions<DBBuilder> options) : base(options) { }

        // HEY! CREATE A DB FOR EACH EXISTING MODEL(S)
        //public DbSet<Greetings> Friends { get; set; }
        //public DbSet<Greetings> Frenemies { get; set; }
        //public DbSet<Greetings> Enemies { get; set; }
        public DbSet<Greetings> Greetings { get; set; }



    }
}