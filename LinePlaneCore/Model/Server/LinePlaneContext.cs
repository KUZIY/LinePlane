using LinePlaneCore.Model.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore
{
    public class LinePlaneContext: DbContext
    {
        public DbSet<Wall> Walls { get; set; }
        public DbSet<TipeFurniture> TipeFurnitures { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Measurements> Measurments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Conservation> Conservations { get; set; }
        public DbSet<User> Userss { get; set; }




        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string

            optionsBuilder.UseSqlServer(@"Data Source=WIN-G4RME6E5PVS\LINEPLANESERVER;Initial Catalog=LPlane;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);

        }
    }
}