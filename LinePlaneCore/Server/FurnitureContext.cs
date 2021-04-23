using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Server
{
    public class FurnitureContext: DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TipeFurniture> TipeFurnitures { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Measurements> Measurments { get; set; }






        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string

            optionsBuilder.UseSqlServer(@"Data Source=WIN-NN38URCCGPE;Initial Catalog=Furniture;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}