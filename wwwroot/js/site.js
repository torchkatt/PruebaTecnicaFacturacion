
function limpiarNuevaFactura()
{
    

    if (CantidadProductos > 0)
    {

        for (var i = 1; i <= CantidadProductos; i++) {
            $("#id_host_filas_productos_" + i).remove();

            console.log("#id_host_filas_productos_" + i);
        }
    }

    CantidadProductos = 0;
}

function crearNuevaFilaProducto() {

    console.log(CantidadProductos);

    $('<tr>', {
        'id': 'id_host_filas_productos_' + CantidadProductos
    }).appendTo('#id_tablaProductos');



    $('<td>', {
        'id': 'id_host_listar_productos_' + CantidadProductos
    }).appendTo('#id_host_filas_productos_' + CantidadProductos);

    $('<td>', {
        'id': 'id_host_precio_producto_' + CantidadProductos
    }).appendTo('#id_host_filas_productos_' + CantidadProductos);

    $('<td>', {
        'id': 'id_host_cantidad_producto_' + CantidadProductos
    }).appendTo('#id_host_filas_productos_' + CantidadProductos);

    $('<td>', {
        'id': 'id_host_imagen_producto_' + CantidadProductos
    }).appendTo('#id_host_filas_productos_' + CantidadProductos);

    $('<td>', {
        'id': 'id_host_precio_total_producto_' + CantidadProductos
    }).appendTo('#id_host_filas_productos_' + CantidadProductos);

}

function GetConsultarProducto() {


    let id_conte_fila = $("#id_SelectListaProductos").parent().parent().parent()[0].id;
    let id_producto = $("#id_SelectListaProductos").val();
    let existe = false;

    for (var i = 0; i < JsonProductos.length; i++) {

        if (JsonProductos[i].Id == id_conte_fila)
        {
            existe = true;

            JsonProductos[i].Id = id_conte_fila;
            JsonProductos[i].IdProducto = id_producto;
            JsonProductos[i].CantidadDeProducto = "";
            JsonProductos[i].PrecioUnitarioProducto = "";
            JsonProductos[i].SubtotalProducto = "";
            JsonProductos[i].Notas = "Nueva nota";

        }
    }

    if (!existe) {

        JsonProductos.push({
            "Id": id_conte_fila,
            "IdProducto": id_producto,
            "CantidadDeProducto": 0,
            "PrecioUnitarioProducto": 0,
            "SubtotalProducto": 0,
            "Notas": ""
        })
    }

    console.log(JsonProductos);

}