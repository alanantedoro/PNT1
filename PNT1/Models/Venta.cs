using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int VentaId { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(20)]
        [Required(ErrorMessage ="Ingrese su nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [StringLength(20)]
        [Required(ErrorMessage = "Ingrese su apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(40)]
        [Required(ErrorMessage = "Ingrese su direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Ciudad")]
        [StringLength(20)]
        [Required(ErrorMessage = "Ingrese su ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Codigo Postal")]
        [StringLength(4, MinimumLength =4)]
        [Required(ErrorMessage = "Ingrese el codigo postal")]
        public string CodigoPostal { get; set; }


        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Ingrese el telefono")]
        public string Telefono { get; set; }

        public List<VentaDetalle> VentaDetalle { get; set; }

        [BindNever]
        public double VentaTotal { get; set; }

        [BindNever]
        public DateTime Fecha { get; set; }

    }
}
