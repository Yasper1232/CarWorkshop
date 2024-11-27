﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWorkshopDbContext : IdentityDbContext
    {


     
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.Entities.CarWorkshop> CarWorkshop { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.CarWorkshop>()
                .OwnsOne(c => c.ContactDetails);
        }


    }
}
