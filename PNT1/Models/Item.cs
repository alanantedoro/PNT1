using PNT1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Titulo { get; set; }

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public double Valor { get; set; }

        public string Imagen { get; set; }

        public string Ubicacion { get; set; }

        [Display(Name = "Fecha de nacimiento")] public DateTime FechaDeNacimiento { get; set; }
        [EnumDataType(typeof(TipoDeItem))] public Item Categoria { get; set; }
    }
}
