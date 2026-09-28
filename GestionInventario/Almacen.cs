public class Almacen
{
    private List<Producto> productos = new List<Producto>();

    public bool ExisteCodigo(string codigo)
    {
        foreach (Producto producto in productos)
        {
            if (producto.Codigo == codigo)
            {
                return true;
            }
        }

        return false;
    }

    public bool RegistrarProducto(Producto producto)
    {
        if (ExisteCodigo(producto.Codigo))
        {
            return false;
        }

        productos.Add(producto);
        return true;
    }

    public Producto BuscarPorCodigo(string codigo)
    {
        foreach (Producto producto in productos)
        {
            if (producto.Codigo == codigo)
            {
                return producto;
            }
        }

        return null;
    }

    public bool EliminarProducto(string codigo)
    {
        Producto producto = BuscarPorCodigo(codigo);

        if (producto == null)
        {
            return false;
        }

        productos.Remove(producto);
        return true;
    }

    public List<Producto> ListarProductos()
    {
        return productos;
    }

    public List<Producto> ListarPorCategoria(string categoria)
    {
        List<Producto> resultado = new List<Producto>();

        foreach (Producto producto in productos)
        {
            if (producto.CategoriaProducto.Nombre == categoria)
            {
                resultado.Add(producto);
            }
        }

        return resultado;
    }

    public List<Producto> ListarAgotados()
    {
        List<Producto> resultado = new List<Producto>();

        foreach (Producto producto in productos)
        {
            if (producto.EstaAgotado())
            {
                resultado.Add(producto);
            }
        }

        return resultado;
    }
}