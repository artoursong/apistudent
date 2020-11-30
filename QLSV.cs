using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API
{
    public class QLSV : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-SM1AGEJG\MSSQLSERVER01;Database=QLSVapi;Trusted_Connection=True");
        }
        public virtual DbSet<Student> Students { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            var student1 = new Student 
            {
                Id = 1,
                Name = "Nigga"
            };


            modelBuilder.Entity<Student>().HasData(student1);
        }
    }
}