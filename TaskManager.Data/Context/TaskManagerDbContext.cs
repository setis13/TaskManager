﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TaskManager.Data.Mappings;

namespace TaskManager.Data.Context {
    /// <summary>
    ///     Main application db context implementation
    /// </summary>
    public class TaskManagerDbContext : DbContext, ITaskManagerDbContext {
        /// <summary>
        ///     Creates context instance
        /// </summary>
        public TaskManagerDbContext() : base("DefaultConnection") {
        }

        /// <summary>
        ///     Gest base db context instance
        /// </summary>
        public DbContext DbContext {
            get { return this; }
        }


        /// <summary>
        ///     Build models
        /// </summary>
        /// <param name="modelBuilder">Models builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Configurations
            modelBuilder.Configurations.Add(new TaskMap());
            modelBuilder.Configurations.Add(new CommentMap());

            // Conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
    }
}