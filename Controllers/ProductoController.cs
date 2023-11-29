using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFacturacion.Models;
using System.Data;
using System.Data.SqlClient;
using DevExtreme.AspNet.Data;
using DevExpress;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace PruebaTecnicaFacturacion.Controllers
{
    public class ProductoController : Microsoft.AspNetCore.Mvc.Controller
    {

        private List<Modelos.ProductoModel>? listaProductos;
        
        public IConfiguration Configuration { get; }

        public ProductoController(IConfiguration configuration)
        {
            Configuration = configuration;

            string msg = string.Empty;

            using (SqlConnection connection = new(Configuration["ConnectionStrings:conexion"]))
            {
                using (SqlCommand command = new("PA_CONSULTA_PRODUCTOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@msg", System.Data.SqlDbType.VarChar).Value = "";

                    connection.Open();
                    SqlDataAdapter adapter = new(command);
                    DataTable dtProductos = new DataTable();
                    adapter.Fill(dtProductos);
                    adapter.Dispose();

                    if (dtProductos.Rows.Count == 0)
                    {
                        msg = "Error al consultar los productos.";
                    }
                    else
                    {
                        this.listaProductos = new List<Modelos.ProductoModel>();

                        for (int i = 0; i < dtProductos.Rows.Count; i++)
                        {
                            this.listaProductos.Add(new Modelos.ProductoModel()
                            {
                                Id = Convert.ToInt32(dtProductos.Rows[i]["Id"]),
                                NombreProducto = (dtProductos.Rows[i]["NombreProducto"]).ToString(),
                                ImagenProducto = (dtProductos.Rows[i]["ImagenProducto"]).ToString(),
                                PrecioUnitario = Convert.ToDecimal(dtProductos.Rows[i]["PrecioUnitario"]),
                                ext = (dtProductos.Rows[i]["ext"]).ToString()
                            });
                        }
                        ViewBag.Productos = this.listaProductos;
                    }
                    connection.Close();
                }
            }
        }
        public IActionResult Index()
        {
            return (IActionResult)View();

        }

        public IActionResult Consultar()
        {
            ViewBag.Productos = this.listaProductos;
            return (IActionResult)View();
            
        }

        public IActionResult Registrar()
        {
            return (IActionResult)View();
        }

        [System.Web.Mvc.HttpPost]
        public IActionResult Registrar(Modelos.ProductoModel producto)
        {
            using (SqlConnection connection = new(Configuration["ConnectionStrings:conexion"]))
            {
                using (SqlCommand command = new("PA_CREACION_PRODUCTOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@NombreProducto", System.Data.SqlDbType.VarChar).Value = producto.NombreProducto;
                    command.Parameters.Add("@ImagenProducto", System.Data.SqlDbType.VarChar).Value = producto.ImagenProducto;
                    command.Parameters.Add("@PrecioUnitario", System.Data.SqlDbType.Decimal).Value = producto.PrecioUnitario;
                    command.Parameters.Add("@ext", System.Data.SqlDbType.VarChar).Value = producto.ext;

                    command.Parameters.Add("@msg", System.Data.SqlDbType.VarChar).Value = "";

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return (IActionResult)Redirect("DashBoard");
        }

        public IActionResult ListarProductos()
        {

            ViewBag.Productos = this.listaProductos;

            return View();
        }

        public Microsoft.AspNetCore.Mvc.JsonResult ObtenerProductos()
        {
            return new JsonResult( new { data = this.listaProductos });
        }

    }
}
