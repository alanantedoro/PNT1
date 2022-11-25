using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public class CarritoItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarritoItemId { get; set; }
        public string CarritoId { get; set; }
        public Item Item { get; set; }
        public int Cantidad { get; set; }
    }
}
