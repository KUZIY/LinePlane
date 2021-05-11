﻿// <auto-generated />
using LinePlaneCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LinePlaneCore.Migrations
{
    [DbContext(typeof(LinePlaneContext))]
    partial class LinePlaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LinePlaneCore.Furniture", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("_FurnitureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_FurnitureUSERName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_IdTipeFurniture")
                        .HasColumnType("int");

                    b.Property<string>("_Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_Price")
                        .HasColumnType("int");

                    b.HasKey("_Id");

                    b.HasIndex("_IdTipeFurniture");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("LinePlaneCore.Measurements", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_IdFurniture")
                        .HasColumnType("int");

                    b.Property<int>("_Length")
                        .HasColumnType("int");

                    b.Property<int>("_Width")
                        .HasColumnType("int");

                    b.HasKey("_Id");

                    b.ToTable("Measurments");
                });

            modelBuilder.Entity("LinePlaneCore.Model.Server.Conservations", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_IdUser")
                        .HasColumnType("int");

                    b.Property<string>("_Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_SaveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_Id");

                    b.HasIndex("_IdUser");

                    b.ToTable("Conservations");
                });

            modelBuilder.Entity("LinePlaneCore.Model.Server.Project", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_IdConservation")
                        .HasColumnType("int");

                    b.Property<int>("_IdFurniture")
                        .HasColumnType("int");

                    b.Property<int>("_IdСoordinates")
                        .HasColumnType("int");

                    b.HasKey("_Id");

                    b.HasIndex("_IdConservation");

                    b.HasIndex("_IdСoordinates");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("LinePlaneCore.TipeFurniture", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FurnitureTipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_Id");

                    b.ToTable("TipeFurnitures");
                });

            modelBuilder.Entity("LinePlaneCore.User", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LinePlaneCore.Wall", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_IdConservation")
                        .HasColumnType("int");

                    b.Property<double>("_X1")
                        .HasColumnType("float");

                    b.Property<double>("_X2")
                        .HasColumnType("float");

                    b.Property<double>("_Y1")
                        .HasColumnType("float");

                    b.Property<double>("_Y2")
                        .HasColumnType("float");

                    b.HasKey("_Id");

                    b.HasIndex("_IdConservation");

                    b.ToTable("Walls");
                });

            modelBuilder.Entity("LinePlaneCore.Сoordinates", b =>
                {
                    b.Property<int>("_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("_X")
                        .HasColumnType("float");

                    b.Property<double>("_Y")
                        .HasColumnType("float");

                    b.HasKey("_Id");

                    b.ToTable("Сoordinates");
                });

            modelBuilder.Entity("LinePlaneCore.Furniture", b =>
                {
                    b.HasOne("LinePlaneCore.TipeFurniture", "_TipeFurniture")
                        .WithMany()
                        .HasForeignKey("_IdTipeFurniture")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_TipeFurniture");
                });

            modelBuilder.Entity("LinePlaneCore.Model.Server.Conservations", b =>
                {
                    b.HasOne("LinePlaneCore.User", "_User")
                        .WithMany()
                        .HasForeignKey("_IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_User");
                });

            modelBuilder.Entity("LinePlaneCore.Model.Server.Project", b =>
                {
                    b.HasOne("LinePlaneCore.Model.Server.Conservations", "_Conservation")
                        .WithMany()
                        .HasForeignKey("_IdConservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LinePlaneCore.Сoordinates", "_Сoordinates")
                        .WithMany()
                        .HasForeignKey("_IdСoordinates")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_Сoordinates");

                    b.Navigation("_Conservation");
                });

            modelBuilder.Entity("LinePlaneCore.Wall", b =>
                {
                    b.HasOne("LinePlaneCore.Model.Server.Conservations", "_Conservation")
                        .WithMany()
                        .HasForeignKey("_IdConservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_Conservation");
                });
#pragma warning restore 612, 618
        }
    }
}
