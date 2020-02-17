using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PidePieperR.Models
{
    public class NuevoStockViewModel
    {
        [Display(Name = "Empresas")]
        [Required(ErrorMessage = "El campo Empresas debe ser seleccionado BREO")]
        public List<Empresa> Empresas { get; set; }

        public List<Producto> Productos { get; set; }

        public int Id_Productos { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo Cantidad es requerido BREO")]
        public int? Cantidad { get; set; }

        public SelectList SelectLisEmpresas { get; set; }
        public SelectList SelectLisProductos { get; set; }

    }
}