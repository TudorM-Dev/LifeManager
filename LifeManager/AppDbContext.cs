using LifeManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeManager
{
    public class AppDbContext: DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=life_data.db");
        }

    }
}
