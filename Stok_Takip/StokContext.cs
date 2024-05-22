using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok_Takip
{
    public class StokContext : DbContext
    {
        public StokContext()
        {
            Database.Connection.ConnectionString = "server=.;database=GumrukDB;uid=sa;pwd=123";
        }
        public DbSet<Kullanıcılar> Kullanıcılar { get; set; }
        public DbSet<Ürünler> Ürünler { get; set; }
    }
}
