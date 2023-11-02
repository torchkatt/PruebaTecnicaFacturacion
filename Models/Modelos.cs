namespace PruebaTecnicaFacturacion.Models
{

    public class Modelos {

        public class DetalleFacturaModel
        {

            public int Id { get; set; }
            public int IdFactura { get; set; }
            public int IdProducto { get; set; }
            public int CantidadDeProducto { get; set; }
            public decimal PrecioUnitarioProducto { get; set; }
            public decimal SubtotalProducto { get; set; }
            public string Notas { get; set; }

        }

        public class FacturaModel
        {
            public int IdCliente { get; set; }
            public int NumeroFactura { get; set; }
            public int NumeroTotalArticulos { get; set; }
            public decimal SubTotalFactura { get; set; }
            public decimal TotalImpuesto { get; set; }
            public decimal TotalFactura { get; set; }

            public DetalleFacturaModel JsonProductos { get; set; }

        }

        public class ProductoModel
        {

            public int Id { get; set; }
            public string NombreProducto { get; set; }
            public string ImagenProducto { get; set; }
            public decimal PrecioUnitario { get; set; }
            public string ext { get; set; }

        }

        public class ClienteModel
        {
            public int Id { get; set; }
            public string RazonSocial { get; set; }
            public int IdTipoCliente { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string RFC { get; set; }

        }

    }

    
}
