using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PidePieperR.Models;


namespace PidePieperR.Data
{
    public class ProductosRepository
    {
        static PidePieperEntities db;
        internal List<StockViewModel> Find(string nomEmpresa,string nomProducto,string fecha)
        {
            List<StockViewModel> ret = new List<StockViewModel>();
            db = new PidePieperEntities();
            List <Stock> stockList = new List<Stock>();
            if (!String.IsNullOrEmpty(nomEmpresa) || !String.IsNullOrEmpty(nomProducto) || !String.IsNullOrEmpty(fecha))
            {
                stockList = db.Stock.Where(y => y.Empresa.NombreEmpresa.ToLower().Trim().Contains(nomEmpresa.ToLower().Trim()) || y.Producto.NombreProducto.ToLower().Trim().Contains(nomProducto.ToLower().Trim()) || y.Fecha.ToString().Contains(fecha.ToString())).ToList();

            }/*else if (!String.IsNullOrEmpty(nomProducto))
            {
                stockList = db.Stock.Where(y => y.Producto.NombreProducto.ToLower().Trim().Contains(nomProducto.ToLower().Trim())).ToList();
            }
            else if (!String.IsNullOrEmpty(fecha))
            {
                stockList = db.Stock.Where(y => y.Fecha.ToString().Contains(fecha.ToString())).ToList();
            }*/
            foreach (var item in stockList)
            {
                StockViewModel stockViewModel = new StockViewModel 
                {
                    Id_Empresa = item.id_Empresa, 
                    Fecha = item.Fecha, 
                    NombreEmpresa = item.Empresa.NombreEmpresa, 
                    Cantidad = item.Cantidad, 
                    NombreProducto = item.Producto.NombreProducto };

                ret.Add(stockViewModel);
            }
            return ret;
        }

        internal List<StockViewModel> List(string nombreEmpresaSort,string cantidadSort, string fechaSort)
        {
            db = new PidePieperEntities();
            List<StockViewModel> list = new List<StockViewModel>();

                var lista = db.Stock.OrderBy(x => x.Empresa.NombreEmpresa).ToList();
                var cantidad = db.Stock.OrderBy(x => x.Cantidad).ToList();
                var fecha = db.Stock.OrderBy(x => x.Fecha).ToList();

            if (nombreEmpresaSort != null)
            {
                foreach (var item in lista)
                {
                    var stockViewModel = new StockViewModel
                    {
                        Cantidad = item.Cantidad,
                        Id_Empresa = item.id_Empresa,
                        Fecha = item.Fecha,
                        NombreEmpresa = item.Empresa.NombreEmpresa,
                        NombreProducto = item.Producto.NombreProducto,
                        Stock = item.Producto.Estado

                    };
                    list.Add(stockViewModel);
                }

            }
            else if (cantidadSort != null)
            {
                foreach (var item in cantidad)
                {
                    var stockViewModel = new StockViewModel
                    {
                        Cantidad = item.Cantidad,
                        Id_Empresa = item.id_Empresa,
                        Fecha = item.Fecha,
                        NombreEmpresa = item.Empresa.NombreEmpresa,
                        NombreProducto = item.Producto.NombreProducto,
                        Stock = item.Producto.Estado

                    };
                    list.Add(stockViewModel);
                }
            }
            else if(fechaSort != null)
            {
                foreach (var item in fecha)
                {
                    var stockViewModel = new StockViewModel
                    {
                        Cantidad = item.Cantidad,
                        Id_Empresa = item.id_Empresa,
                        Fecha = item.Fecha,
                        NombreEmpresa = item.Empresa.NombreEmpresa,
                        NombreProducto = item.Producto.NombreProducto,
                        Stock = item.Producto.Estado

                    };
                    list.Add(stockViewModel);
                }
            }

            return list;
        }

        internal List<NuevoStockViewModel> Create(int? cantidad, int? empresas, int? productos)
        {
            db = new PidePieperEntities();
            List<NuevoStockViewModel> newStock = new List<NuevoStockViewModel>();
            List<Stock> ret = new List<Stock>();

            Stock stock = new Stock
            {
                Cantidad = cantidad,
                id_Empresa = empresas,
                Id_Productos = productos,
                Fecha = DateTime.Now
            };

                ret.Add(stock);
                db.Stock.Add(stock);

            db.SaveChanges();
            return newStock;
        }

        internal List<StockViewModel> Info(int? id)
        {
            List<StockViewModel> ret = new List<StockViewModel>();
            db = new PidePieperEntities();
            StockViewModel stockViewModel;

            stockViewModel = (from x in db.Stock
                              where x.Id == id
                              select new StockViewModel
                              {
                               NombreEmpresa = x.Empresa.NombreEmpresa,
                               NombreProducto = x.Producto.NombreProducto,
                               Descripcion = x.Producto.Descripcion,
                               Cantidad = x.Cantidad,
                               Fecha = x.Fecha
                              }).FirstOrDefault();

            ret.Add(stockViewModel);
            db.SaveChanges();

            return (ret);
        }

        internal List<StockViewModel> Edit(int? id, bool? estado, int? cantidad)
        {
            db = new PidePieperEntities();
            List<StockViewModel> ret = new List<StockViewModel>();

            var stock = (from x in db.Stock
                         where x.Id == id
                         select x);

            foreach (var item in stock)
            {
                item.Producto.Estado = estado;
                if (item.Producto.Estado == true)
                {
                    item.Cantidad = cantidad;
                }
                else
                {
                    item.Cantidad = 0;
                }

            }

            db.SaveChanges();

            return (ret);
        }

        internal Stock Delete(int id)
        {
            db = new PidePieperEntities();

            Stock stock = db.Stock.RemoveRange(db.Stock.Where(x => x.Id == id)).FirstOrDefault();

            db.SaveChanges();


            return (stock);
        }

        internal Producto Combo(int id)
        {
            db = new PidePieperEntities();


            //Producto producto = db.Producto.Where(x => x.Id_Productos == id).FirstOrDefault();

            var producto = (from x in db.Producto
                            where x.Id_Productos == id
                            select x).FirstOrDefault();



            return (producto);
        }

        internal List<Empresa> GetEmpresas()
        {
            return db.Empresa.ToList();
        }

        internal List<Producto> GetProducto()
        {
            return db.Producto.ToList();
        }

        internal List<StockViewModel> GetAll()
        {
            db = new PidePieperEntities();
            List<StockViewModel> list;
            list = (from x in db.Stock
                    select new StockViewModel
                    {
                        Cantidad = x.Cantidad,
                        Id_Empresa = x.id_Empresa,
                        Fecha = x.Fecha,
                        NombreEmpresa = x.Empresa.NombreEmpresa,
                        NombreProducto = x.Producto.NombreProducto,
                        Stock = x.Producto.Estado,
                        Id = x.Id

                    }).ToList();

            return list;


            /*List<StockViewModel> ret  = new List<StockViewModel>();
            var stockList = db.Stock.ToList();
            foreach (var item in stockList)
            {
                var stockViewModel = new StockViewModel
                {
                    Cantidad = item.Cantidad,
                    Id_Empresa = item.Id_Empresa,
                    Fecha = item.Fecha,
                    NombreEmpresa = item.Empresa.NombreEmpresa

                };
                ret.Add(stockViewModel);
            }
            
            return ret;*/

        }
    }
}