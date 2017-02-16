using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CSRA.Data;

namespace CSRA.Data.Migrations
{
    [DbContext(typeof(CsraContext))]
    [Migration("20170216110012_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSRA.Data.DataModels.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CSRA.Data.DataModels.Prisoner", b =>
                {
                    b.Property<int>("PrisonerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DoB");

                    b.Property<string>("Firstname");

                    b.Property<int?>("FromLocationLocationID");

                    b.Property<string>("LastName");

                    b.Property<string>("NomisId");

                    b.Property<DateTime>("ReceptionDate");

                    b.HasKey("PrisonerID");

                    b.HasIndex("FromLocationLocationID");

                    b.ToTable("Prisoners");
                });

            modelBuilder.Entity("CSRA.Data.DataModels.Prisoner", b =>
                {
                    b.HasOne("CSRA.Data.DataModels.Location", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationLocationID");
                });
        }
    }
}
