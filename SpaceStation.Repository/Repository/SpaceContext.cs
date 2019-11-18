using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpaceStation.Models;

namespace SpaceStation.Repository.Repository
{
    public class SpaceContext: DbContext
    {
        public DbSet<Shuttle> Shuttles { get; set; }

        public DbSet<Dimension> Dimensions { get; set; }

        public SpaceContext(DbContextOptions<SpaceContext> options) : base(options)
        {

        }
    }
}
