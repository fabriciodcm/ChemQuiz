﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Models.Context
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
        }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.SetCommandTimeout(150000);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Exemplo de mapeando N - N
            //modelBuilder.Entity<PlaceBenefit>()
            //    .HasKey(pb => new { pb.PlaceId, pb.BenefitId });
            //modelBuilder.Entity<PlaceBenefit>()
            //    .HasOne(pb => pb.Place)
            //    .WithMany(p => p.PlaceBenefit)
            //    .HasForeignKey(pb => pb.PlaceId);
            //modelBuilder.Entity<PlaceBenefit>()
            //    .HasOne(pb => pb.Benefit)
            //    .WithMany(b => b.PlaceBenefit)
            //    .HasForeignKey(pb => pb.BenefitId);
        }

        //Exemplo de persistência
        //public DbSet<Place> Place { get; set; }
    }
}
