using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Data.SqlClient;

namespace Library
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "HP\\MSSQLSERVER01",
                InitialCatalog = "Library",
                IntegratedSecurity = true, // or set User ID and Password for SQL Server Authentication
                // ... other parameters
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<User>().ToTable("Users");
        }

        // Define the User class here

        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

  
    
        public class Member
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Member_Id { get; set; }

            public string MFirst_Name { get; set; }

            public string MLast_Name { get; set; }

            public DateTime Registration_Date { get; set; }
        }

        public class Reservation
        {
            public int Reservation_Id { get; set; }
            public string RBook_Name { get; set; }
            public DateTime Reservation_Date { get; set; }
            public int Member_Id { get; set; }  // Foreign key to Users table
        }

    }

}

