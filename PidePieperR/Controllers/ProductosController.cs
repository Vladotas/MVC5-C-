using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PidePieperR.Models;
using PidePieperR.Controllers.BussinessObject;
using System.Threading.Tasks;

namespace PidePieperR.Controllers
{
    public class ProductosController : Controller
    {
        public ActionResult Index(string nomEmpresa, string fecha, string nomProducto, string nombreEmpresaSort, string cantidadSort, string fechaSort)
        {
            ProductosLogic productosLogic = new ProductosLogic();
            List<StockViewModel> stockViewModel;
            ViewBag.nomEmpresa = nomEmpresa;
            ViewBag.fecha = fecha;
            ViewBag.nomProducto = nomProducto;

            if (nomEmpresa != null && nomEmpresa != "" || fecha != null && fecha != "" || nomProducto != null && nomProducto != "")
            {
                stockViewModel = productosLogic.Find(nomEmpresa, nomProducto, fecha);

                return View(stockViewModel);
            }
            if(nombreEmpresaSort != null || cantidadSort != null || fechaSort != null)
            {
                stockViewModel = productosLogic.List(nombreEmpresaSort, cantidadSort, fechaSort);
                return View(stockViewModel);
            }

            stockViewModel = productosLogic.GetAll();

            return View(stockViewModel);
        }

        /*public ActionResult List()
        {
            ProductosLogic productosLogic = new ProductosLogic();
            List<StockViewModel> model;

            model = productosLogic.List();

            return PartialView("Index",model);
        }*/


        [HttpPost]
        public ActionResult Delete(int id)
        {
            ProductosLogic productosLogic = new ProductosLogic();

            productosLogic.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ProductosLogic productosLogic = new ProductosLogic();
            NuevoStockViewModel model = new NuevoStockViewModel();
            model.Empresas = productosLogic.GetEmpresas();
            model.Productos = productosLogic.GetProductos();


            //SelectList selectLisEmpresas = new SelectList(model.Empresas, "id_Empresa", "NombreEmpresa");
            //ViewBag.selectLisEmpresas = selectLisEmpresas;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NuevoStockViewModel model, int? cantidad,int? empresas,int? productos)
        {
            ProductosLogic productosLogic = new ProductosLogic();
            model.Empresas = productosLogic.GetEmpresas();
            model.Productos = productosLogic.GetProductos();

            if (!ModelState.IsValid)
            {
                if (cantidad != null)
                {
                   productosLogic.Create(cantidad, empresas, productos);

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }


        public ActionResult Info(int? id)
        {
            ProductosLogic productosLogic = new ProductosLogic();
            List<StockViewModel> model;
            model = productosLogic.Info(id);

            return View(model);

        }

        public ActionResult Edit(int? id)
        {
            ProductosLogic productoLogic = new ProductosLogic();
            List<StockViewModel> model;

            model = productoLogic.Info(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int? id, bool? estado,int? cantidad)
        {
            ProductosLogic productoLogic = new ProductosLogic();

            productoLogic.Edit(id,estado, cantidad);

            return RedirectToAction("index");
        }

        [HttpPost]
        public JsonResult Combo (int id)
        {
            ProductosLogic productosLogic = new ProductosLogic();
            Producto entidad = productosLogic.Combo(id);

            return new JsonResult { Data = entidad.NombreProducto, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //return Json(new { Data = entidad, JsonRequestBehavior.AllowGet });
        }
    }
}