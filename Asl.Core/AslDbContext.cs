using Asl.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Asl.Core
{
    public class AslDbContext : DbContext
    {
        public AslDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string cs = config.GetConnectionString("Default");
            builder.UseMySQL("Server=localhost;database=asl;username=root;password=123456abc!;port=3306");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Patient>().HasKey(p => p.FiscalCode);

            builder.Entity<Patient>().Property(p => p.FiscalCode)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnType("varchar(16)");

            builder.Entity<Patient>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Entity<Patient>().Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Entity<Patient>().Property(p => p.BirthPlace)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");


            builder.Entity<Doctor>().ToTable("Doctor");
            builder.Entity<Doctor>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Entity<Doctor>().Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Entity<Doctor>().Property(p => p.BirthPlace)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Entity<Stub>().ToTable("Stub");
            builder.Entity<Stub>().Property(x => x.StubResult)
                .IsRequired()
                .HasColumnType("char(3)")
                .HasMaxLength(3);

            builder.Entity<Stub>()
                .HasOne(s => s.Result)
                .WithMany()
                .HasForeignKey(x => x.StubResult);

            builder.Entity<Stub>().Property(p => p.PatientId)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnType("varchar(16)");

            builder.Entity<Address>().ToTable("Address");
            
            builder.Entity<Address>().Property(a => a.StreetName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Entity<Address>().Property(a => a.StreetNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Entity<Address>().Property(a => a.City)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Entity<Address>().Property(a => a.Cap)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("char(5)");

            builder.Entity<StubResult>().HasKey(x => x.Code);

            builder.Entity<StubResult>().Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnType("char(3)");

            builder.Entity<StubResult>().Property(a => a.Code)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            //builder.Entity<Patient>()
            //    .HasOne(p => p.Address)
            //    .WithOne(a => a.Patient)
            //    .HasForeignKey<Patient>(p => p.AddressId)
            //    .HasForeignKey<Address>(a => a.PatientId);

            builder.Entity<Stub>()
                .HasOne(s => s.PrescribeDoctor)
                .WithMany(x => x.Stubs)
                .HasForeignKey(x => x.DoctorId);

            builder.Entity<Stub>()
                .HasOne(s => s.Patient)
                .WithMany(p => p.Stubs)
                .HasForeignKey(s => s.PatientId);

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Stub> Stubs { get; set; }
    }
}
