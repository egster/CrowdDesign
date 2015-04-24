﻿using System.Data.Entity;
using CrowdDesign.Core.Entities;

namespace CrowdDesign.Infrastructure.SQLServer.Contexts
{
    public class DatabaseContext : DbContext
    {
        #region Properties
        public DbSet<Project> Projects { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<Sketch> Sketches { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sketch>()
                .HasRequired(e => e.Dimension)
                .WithMany()
                .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
