﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.DatabaseResource
{
    public class VidlyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public VidlyDbContext()
            : base("name=DefaultConnection")
        {
            
        }

        public static VidlyDbContext Create()
        {
            return new VidlyDbContext();
        }
    }
}