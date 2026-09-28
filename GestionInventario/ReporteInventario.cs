public class ReporteInventario
{
    public void MostrarResumen(Almacen almacen)
    {
        var productos = almacen.ListarProductos();
        int totalUnidades = 0;
        decimal valorTotal = 0;

        foreach (var producto in productos)
        {
            //Significa: sumar la cantidad de unidades de cada producto al total.
            totalUnidades += producto.Cantidad;
            valorTotal += producto.ValorTotal();
        }

        Console.WriteLine("Resumen del inventario");
        Console.WriteLine();
        Console.WriteLine("Productos registrados: " + productos.Count);
        Console.WriteLine("Unidades en inventario: " + totalUnidades);
        Console.WriteLine("Valor total: " + valorTotal);
        Console.WriteLine("Productos agotados: " + almacen.ListarAgotados().Count);
    }
}