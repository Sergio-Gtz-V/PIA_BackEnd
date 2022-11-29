﻿using PIA_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace PIA_BackEnd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Raffle> Rifas { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Prizes> Prizes { get; set; }
    }
}
