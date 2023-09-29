using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace PIMToolCodeBase.Database
{
    /// <summary>
    ///     DbContext of PIMTool.
    /// </summary>
    public class PimContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        public PimContext() { }

        public PimContext(DbContextOptions<PimContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Base entity configuration
            //modelBuilder.Entity<BaseEntity>(b =>
            //{
            //    b.HasKey(e => e.Id);
            //    b.Property(e => e.Id).ValueGeneratedOnAdd();
            //});

            // Project entity configuration
            modelBuilder.Entity<Project>().ToTable("PROJECT");

            modelBuilder.Entity<Project>()
                .Property(s => s.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(s => s.GroupId)
                .HasColumnName("GROUP_ID")
                .HasColumnType("numeric(19, 0)")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(s => s.ProjectNumber)
                .HasColumnName("PROJECT_NUMBER")
                .HasColumnType("numeric(4, 0)")
                .HasPrecision(4, 0)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .HasIndex(e => e.ProjectNumber)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .Property(s => s.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(s => s.Customer)
                .HasColumnName("CUSTOMER")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(s => s.Status)
                .HasColumnName("STATUS")
                .HasColumnType("char")
                .HasMaxLength(3)
                .IsFixedLength(true)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Project>()
               .Property(s => s.StartDate)
               .HasColumnName("START_DATE")
               .IsRequired();

            modelBuilder.Entity<Project>()
               .Property(s => s.EndDate)
               .HasColumnName("END_DATE");

            modelBuilder.Entity<Project>()
                .Property(s => s.Version)
                .HasColumnName("VERSION")
                .HasColumnType("numeric(10, 0)")
                .HasPrecision(10, 0)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .HasOne<Group>(s => s.Group)
                .WithMany(g => g.Projects)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Project>(entity =>
                entity.HasCheckConstraint("CK_Project_Status", "[STATUS] IN ('NEW', 'PLA', 'INP', 'FIN')")
            );

            // Employee entity configuration
            modelBuilder.Entity<Employee>().ToTable("EMPLOYEE");

            modelBuilder.Entity<Employee>()
                .Property(s => s.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(s => s.Visa)
                .HasColumnName("VISA")
                .HasColumnType("char")
                .HasMaxLength(3)
                .IsFixedLength(true)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(s => s.FirstName)
                .HasColumnName("FIRST_NAME")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(s => s.LastName)
                .HasColumnName("LAST_NAME")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(s => s.BirthDay)
                .HasColumnName("BIRTH_DAY")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(s => s.Version)
                .HasColumnName("VERSION")
                .HasColumnType("numeric(10, 0)")
                .HasPrecision(10, 0)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne<Group>(s => s.Group)
                .WithOne(g => g.GroupLeader)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<Group>(s => s.GroupLeaderId);

            // Group entity configuration
            modelBuilder.Entity<Group>().ToTable("GROUP");

            modelBuilder.Entity<Group>()
                .Property(s => s.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric(19, 0)")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .Property(s => s.GroupLeaderId)
                .HasColumnName("GROUP_LEADER_ID")
                .HasColumnType("numeric(19, 0)")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .Property(s => s.Version)
                .HasColumnName("VERSION")
                .HasColumnType("numeric(10, 0)")
                .HasPrecision(10, 0)
                .IsRequired();

            // Project_Employee entity configuration
            modelBuilder.Entity<ProjectEmployee>().ToTable("PROJECT_EMPLOYEE");

            modelBuilder.Entity<ProjectEmployee>()
                .Property(s => s.ProjectId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("PROJECT_ID")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<ProjectEmployee>()
                .Property(s => s.EmployeeId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("EMPLOYEE_ID")
                .HasPrecision(19, 0)
                .IsRequired();

            modelBuilder.Entity<ProjectEmployee>().HasKey(sc => new { sc.ProjectId, sc.EmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne<Project>(s => s.Project)
                .WithMany(g => g.ProjectEmployees)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s => s.ProjectId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne<Employee>(s => s.Employee)
                .WithMany(g => g.ProjectEmployees)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}