using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PidePieperR.Models
{
    public class StockViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Descripcion del producto")]
        public string Descripcion { get; set; }
        [Display(Name = "Sin Stock")]
        public bool? Stock { get; set; }
        [Display(Name = "Nombre Empresa")]
        public string NombreEmpresa { get; set; }
        [Display(Name = "Nombre Producto")]
        public string NombreProducto { get; set; }
        public int? C_Id_Producto_s { get; set; }
        [Required]
        [Display(Name = "Empresa ID")]
        public int? Id_Empresa { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int? Cantidad { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }


        public SelectList SelectLisEstados { get; set; }
    }
}