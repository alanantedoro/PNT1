using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public class VentaDetalle
    {
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public double Valor { get; set; }
        public Venta Venta { get; set; }
    }
}
