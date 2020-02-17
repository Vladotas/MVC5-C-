using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PidePieperR.Models
{
    public class ProductosViewModel
    {
        public int C_Id_Producto_s { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Estado { get; set; }

    }
}