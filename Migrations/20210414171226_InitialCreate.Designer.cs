// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VrrrRent.Models;

namespace VrrrRent.Migrations
{
    [DbContext(typeof(VrrrRentContext))]
    [Migration("20210414171226_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VrrrRent.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BListStatus")
                        .HasColumnType("bit");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("VrrrRent.Models.Dealership", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dealership");
                });

            modelBuilder.Entity("VrrrRent.Models.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DealershipID")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DealershipID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("VrrrRent.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RentalID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RentalID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("VrrrRent.Models.Rental", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("Dropp_Off_Dealer_ID")
                        .HasColumnType("int");

                    b.Property<int>("Pick_Up_Dealer_ID")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("VrrrRent.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("VrrrRent.Models.Inventory", b =>
                {
                    b.HasOne("VrrrRent.Models.Dealership", "Dealership")
                        .WithMany("Inventory")
                        .HasForeignKey("DealershipID");

                    b.HasOne("VrrrRent.Models.Vehicle", "Vehicle")
                        .WithMany("Inventory")
                        .HasForeignKey("VehicleID");

                    b.Navigation("Dealership");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VrrrRent.Models.Payment", b =>
                {
                    b.HasOne("VrrrRent.Models.Rental", "Rental")
                        .WithMany("Payment")
                        .HasForeignKey("RentalID");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("VrrrRent.Models.Rental", b =>
                {
                    b.HasOne("VrrrRent.Models.Client", "Client")
                        .WithMany("Rental")
                        .HasForeignKey("ClientID");

                    b.HasOne("VrrrRent.Models.Vehicle", "Vehicle")
                        .WithMany("Rental")
                        .HasForeignKey("VehicleID");

                    b.Navigation("Client");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VrrrRent.Models.Client", b =>
                {
                    b.Navigation("Rental");
                });

            modelBuilder.Entity("VrrrRent.Models.Dealership", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("VrrrRent.Models.Rental", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("VrrrRent.Models.Vehicle", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("Rental");
                });
#pragma warning restore 612, 618
        }
    }
}
