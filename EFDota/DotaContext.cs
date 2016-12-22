using EFDota.Migrations;
using EFDota.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota
{
    public class DotaContext : DbContext
    {
        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<MatchPlayer> Players { get; set; }

        public DotaContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            var conf = new Configuration();
            Database.SetInitializer<DotaContext>(
                new MigrateDatabaseToLatestVersion<
                    DotaContext, Configuration>(true, conf));
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600;
        }

        #region Public Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<MatchDetail>()
            //    .Property(p => p.ID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<MatchDetail>().HasKey(r => r.ID);
            //modelBuilder.Entity<Player>().HasKey(r => r.ID);
            //modelBuilder
            //    .Entity<Player>()
            //    .HasOptional<MatchDetail>(p => p.MatchDetail)
            //    .WithMany(p => p.Players)
            //    .HasForeignKey(p => p.MatchDetailID);
            modelBuilder.Entity<MatchPlayer>().HasRequired(p => p.MatchDetail);
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
