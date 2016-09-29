using EFDota.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota
{
    public class DotaContext : DbContext
    {
        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<Player> Players { get; set; }

        public DotaContext()
            : base("dota")
        {
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
            modelBuilder.Entity<Player>().HasRequired(p => p.MatchDetail);
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
