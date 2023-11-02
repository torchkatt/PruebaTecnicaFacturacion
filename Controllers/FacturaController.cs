using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFacturacion.Models;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnicaFacturacion.Controllers
{
    public class FacturaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IConfiguration Configuration { get; }

        public FacturaController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Consultar(int id)
        {
            return View();
        }

        public IActionResult Crear()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Crear(Modelos.FacturaModel factura)
        {

            using (SqlConnection connection = new(Configuration["ConnectionStrings:conexion"]))
            {
                using (SqlCommand command = new("PA_CREACION_FACTURAS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@IdCliente", System.Data.SqlDbType.Int).Value = factura.IdCliente;
                    command.Parameters.Add("@NumeroFactura", System.Data.SqlDbType.Int).Value = factura.NumeroFactura;
                    command.Parameters.Add("@NumeroTotalArticulos", System.Data.SqlDbType.Int).Value = factura.NumeroTotalArticulos;
                    command.Parameters.Add("@SubTotalFactura", System.Data.SqlDbType.Decimal).Value = factura.SubTotalFactura;
                    command.Parameters.Add("@TotalImpuesto", System.Data.SqlDbType.Decimal).Value = factura.TotalImpuesto;
                    command.Parameters.Add("@TotalFactura", System.Data.SqlDbType.Decimal).Value = factura.TotalFactura;
                    command.Parameters.Add("@JsonProductos", System.Data.SqlDbType.VarChar).Value = factura.JsonProductos;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return Redirect("Facturar");

        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
