using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Storage.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Belt_characteristic> Belt_Characteristics { get; set; }

        public virtual DbSet<Enter_value> Enter_Values { get; set; }

        public virtual DbSet<kofC1> KofC1s { get; set; }

        public virtual DbSet<Out_value> Out_Values { get; set; }

        public virtual DbSet<Phi0> Phi0s { get; set; }

        public virtual DbSet<Sig0> Sig0s { get; set; }
    }
}
