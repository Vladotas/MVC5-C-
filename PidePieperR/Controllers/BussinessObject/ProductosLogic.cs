using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PidePieperR.Data;
using PidePieperR.Models;

namespace PidePieperR.Controllers.BussinessObject
{
    public class ProductosLogic
    {
        ProductosRepository db;
        //public List<StockViewModel> stocklist = new ProductosRepository().GetAll();

        public List<StockViewModel> Find(string nomEmpresa, string nomProducto, string fecha)
        {
            ProductosRepository db = new ProductosRepository();

            return db.Find(nomEmpresa, nomProducto, fecha);
        }


        public List<StockViewModel> GetAll()
        {
            db = new ProductosRepository();
            return db.GetAll();
        }

        public List<StockViewModel> List(string nombreEmpresaSort, string cantidadSort, string fechaSort)
        {
            db = new ProductosRepository();
            return db.List(nombreEmpresaSort, cantidadSort, fechaSort);
        }

        public Stock Delete(int id)
        {
            db = new ProductosRepository();
            return db.Delete(id);
        }

        public Producto Combo (int id)
        {
            db = new ProductosRepository();
            return db.Combo(id);
        }

        public List<NuevoStockViewModel> Create( int? cantidad, int? empresas, int? productos)
        {
            db = new ProductosRepository();

            return db.Create(cantidad, empresas, productos);
        }

        public List<StockViewModel> Edit (int? id, bool? estado, int? cantidad)
        {
            db = new ProductosRepository();

            return db.Edit(id, estado, cantidad);
        }

        public List<StockViewModel> Info(int? id)
        {
            db = new ProductosRepository();

            return db.Info(id);
        }

        internal List<Empresa> GetEmpresas()
        {
            db = new ProductosRepository();
            return db.GetEmpresas();
        }

        internal List<Producto> GetProductos()
        {
            db = new ProductosRepository();
            return db.GetProducto();
        }
    }
}