using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNT1.Models;

namespace PNT1.Context
{
    public class PNT1DatabaseContext : DbContext
    {

        public PNT1DatabaseContext(DbContextOptions<PNT1DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Item> Item { get; set; }
    }
}