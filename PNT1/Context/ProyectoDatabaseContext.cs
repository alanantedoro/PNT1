using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNT1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PNT1.Context
{
    public class PNT1DatabaseContext : IdentityDbContext<IdentityUser>
    {

        public PNT1DatabaseContext(DbContextOptions<PNT1DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Item> Item { get; set; }

        public DbSet<CarritoItems> CarritoItems { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<VentaDetalle> VentaDetalle { get; set; }
    }
}