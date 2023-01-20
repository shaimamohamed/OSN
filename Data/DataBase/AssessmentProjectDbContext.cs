using Core.Entities;
using Data.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DataBase
{
    public class AssessmentProjectDbContext : IdentityDbContext<ApplicationUser>
    {
        public AssessmentProjectDbContext()
        {
        }

        public AssessmentProjectDbContext(DbContextOptions<AssessmentProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER14;Database=AssessmentProjectDb;Trusted_Conn‌ection=True;Multiple‌​ActiveResultSets=tru‌​e;");
            }
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasIndex(b => b.ID)
                        .IsUnique();

            modelBuilder.Entity<Parent>()
                        .HasIndex(b => b.ID)
                        .IsUnique();

            modelBuilder.Entity<Subject>()
                        .HasIndex(b => b.ID)
                        .IsUnique();

            modelBuilder.Entity<Term>()
                        .HasIndex(b => b.ID)
                        .IsUnique();

            modelBuilder.Entity<Marks>()
                         .HasIndex(b => b.ID)
                         .IsUnique();

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
