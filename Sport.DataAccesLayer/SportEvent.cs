using Microsoft.EntityFrameworkCore;
using Sport.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Sport.DataAccesLayer
{
    public class SportEventContext : DbContext {
        public SportEventContext(DbContextOptions<SportEventContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        public DbSet<Event> Events { get; set; }
        //public DbSet<ViewModelEvent> ViewModel { get; set; }

    }
}
