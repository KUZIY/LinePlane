using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LinePlaneCore
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
       
        
        
   //    protected override void OnConfiguring(
   //        DbContextOptionsBuilder optionsBuilder)
   //    {
   //        optionsBuilder.UseSqlite(
   //            "Data Source=Users.db");
   //
   //       //Add-Migration UserTableCreated -Context UserContext optionsBuilder.UseLazyLoadingProxies();
   //        base.OnConfiguring(optionsBuilder);
   //    }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string

            optionsBuilder.UseSqlServer(@"Data Source=WIN-NN38URCCGPE;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
