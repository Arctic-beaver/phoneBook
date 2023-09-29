﻿// <auto-generated />
using System;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Persistence.Migraions
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Contact");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("API.Entities.Organization", b =>
                {
                    b.HasBaseType("API.Entities.Contact");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("OrganizationType")
                        .HasColumnType("integer");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_Contacts_OrganizationType_Enum", "\"OrganizationType\" IN (0, 1)");
                        });

                    b.HasDiscriminator().HasValue("Organization");
                });

            modelBuilder.Entity("API.Entities.Person", b =>
                {
                    b.HasBaseType("API.Entities.Contact");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_Contacts_Gender_Enum", "\"Gender\" IN (0, 1)");
                        });

                    b.HasDiscriminator().HasValue("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
