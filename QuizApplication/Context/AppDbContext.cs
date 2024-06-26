﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace QuizApplication.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            //Context
            string connectionString = configuration.GetConnectionString("AppDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Quiz
            modelBuilder.Entity<Quiz>().HasMany(x => x.Questions).WithOne(x => x.Quiz).HasForeignKey(x => x.QuizId);

            //Question
            modelBuilder.Entity<Question>().HasMany(x => x.Tags).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);
            modelBuilder.Entity<Question>().HasMany(x => x.IncorrectAnswers).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);
        }

        public DbSet<Quiz> Quizes { get; set; }
    }
}
