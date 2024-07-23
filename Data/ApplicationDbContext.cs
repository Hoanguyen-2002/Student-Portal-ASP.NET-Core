using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Entities;

namespace StudentPortal.Data//bridge between application and SQLServer
{
    public class ApplicationDbContext: DbContext
    {
        //constructor giving the options for the Program.cs file, injecting the db context
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }//create student table
    }
}