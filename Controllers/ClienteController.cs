using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFacturacion.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using DevExtreme;

namespace PruebaTecnicaFacturacion.Controllers
{
    public class ClienteController : Controller
    {
        private List<Modelos.ClienteModel>? listaClientes;
        

        public IConfiguration Configuration { get; }


        public ClienteController(IConfiguration configuration)
        {
            Configuration = configuration;

            string msg = string.Empty;

            using (SqlConnection connection = new(Configuration["ConnectionStrings:conexion"]))
            {
                using (SqlCommand command = new("PA_CONSULTA_CLIENTES", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@msg", System.Data.SqlDbType.VarChar).Value = "";

                    connection.Open();
                    SqlDataAdapter adapter = new(command);
                    DataTable dtClientes = new DataTable();
                    adapter.Fill(dtClientes);
                    adapter.Dispose();

                    if (dtClientes.Rows.Count == 0)
                    {
                        msg = "Error al consultar los clientes.";
                    }
                    else
                    {
                        this.listaClientes = new List<Modelos.ClienteModel>();

                        for (int i = 0; i < dtClientes.Rows.Count; i++)
                        {
                            this.listaClientes.Add(new Modelos.ClienteModel()
                            {
                                Id = Convert.ToInt32(dtClientes.Rows[i]["Id"]),
                                RazonSocial = (dtClientes.Rows[i]["RazonSocial"]).ToString(),
                                IdTipoCliente = Convert.ToInt32(dtClientes.Rows[i]["IdTipoCliente"]),
                                FechaCreacion = Convert.ToDateTime(dtClientes.Rows[i]["FechaCreacion"]),
                                RFC = (dtClientes.Rows[i]["RFC"]).ToString()
                            });
                        }
                        ViewBag.Clientes = this.listaClientes;
                    }
                    connection.Close();
                }
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            ViewBag.Clientes = this.listaClientes;
            return View();
        }

        public IActionResult ListarClientes()
        {
            ViewBag.Clientes = this.listaClientes;
            return View();
        }

        public Microsoft.AspNetCore.Mvc.JsonResult ObtenerClientes()
        {
            return new JsonResult(new { data = this.listaClientes });
        }
    }
}
