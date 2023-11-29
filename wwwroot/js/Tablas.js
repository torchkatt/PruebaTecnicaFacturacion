








// Productos ---------------------------------------------
function CrearTablaProductos()
{

    $('#TablaProductos').dxDataGrid({

        dataSource: {
            store: {
                type: 'odata',
                url: '/Producto/ObtenerProductos',
                key: 'id',

            },
        },
        paging: {
            pageSize: 10,
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 25, 50, 100],
        },
        remoteOperations: false,
        searchPanel: {
            visible: true,
            highlightCaseSensitive: true,
        },
        groupPanel: { visible: false },
        grouping: {
            autoExpandAll: false,
        },
        showColumnLines: false,
        allowColumnReordering: true,
        rowAlternationEnabled: false,
        showBorders: false,
        width: '100%',
        columns: [

            {
                dataField: 'id',
                caption: 'Id producto',
                dataType: 'number',
            },
            {
                dataField: 'nombreProducto',
                caption: 'Nombre producto',
                dataType: 'string',
            },
            {
                dataField: 'imagenProducto',
                caption: 'Imagen producto',
                dataType: 'string',
            },
            {
                dataField: 'precioUnitario',
                caption: 'Precio unitario',
                dataType: 'currency',
            },
            {
                dataField: 'ext',
                caption: 'Existencias',
                dataType: 'number',
            }

        ],
        onContentReady(e) {
            if (!collapsed) {
                collapsed = true;
                e.component.expandRow(['EnviroCare']);
            }
        },
    });

};
// ------------------------------------------------------

// Clientes ---------------------------------------------
function CrearTablaClientes() {

    $('#TablaClientes').dxDataGrid({

        dataSource: {
            store: {
                type: 'odata',
                url: '/Cliente/ObtenerClientes',
                key: 'id',

            },
        },
        paging: {
            pageSize: 10,
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 25, 50, 100],
        },
        remoteOperations: false,
        searchPanel: {
            visible: true,
            highlightCaseSensitive: true,
        },
        groupPanel: { visible: false },
        grouping: {
            autoExpandAll: false,
        },
        allowColumnReordering: true,
        rowAlternationEnabled: true,
        showBorders: true,
        width: '100%',
        columns: [

            {
                dataField: 'id',
                caption: 'Id cliente',
                dataType: 'number',
            },
            {
                dataField: 'razonSocial',
                caption: 'Nombre cliente',
                dataType: 'string',
            },
            {
                dataField: 'idTipoCliente',
                caption: 'Id tipo cliente',
                dataType: 'number',
            },
            {
                dataField: 'rFC',
                caption: 'RFC',
                dataType: 'string',
            }

        ],
        onContentReady(e) {
            if (!collapsed) {
                collapsed = true;
                e.component.expandRow(['EnviroCare']);
            }
        },
    });

};

 //-------------------------------------------------------------
const discountCellTemplate = function (container, options) {
    $('<div/>').dxBullet({
        onIncidentOccurred: null,
        size: {
            width: 150,
            height: 35,
        },
        margin: {
            top: 5,
            bottom: 0,
            left: 5,
        },
        showTarget: false,
        showZeroLevel: true,
        value: options.value * 100,
        startScaleValue: 0,
        endScaleValue: 100,
        tooltip: {
            enabled: true,
            font: {
                size: 18,
            },
            paddingTopBottom: 2,
            customizeTooltip() {
                return { text: options.text };
            },
            zIndex: 5,
        },
    }).appendTo(container);
};

let collapsed = false;
