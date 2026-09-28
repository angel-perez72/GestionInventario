public class Producto
{
    public string Codigo;
    public string Nombre;
    public decimal Precio;
    public int Cantidad;
    public Categoria CategoriaProducto;

    public Producto(string codigo, string nombre, decimal precio, int cantidad, Categoria categoria)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
        CategoriaProducto = categoria;
    }

    public bool EstaAgotado()
    {
        if (Cantidad == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public decimal ValorTotal()
    {
        return Precio * Cantidad;
    }

    public void Mostrar()
    {
        string estado;

        if (EstaAgotado())
        {
            estado = "\tAgotado";
        }
        else
        {
            estado = "\tDisponible";
        }

        Console.WriteLine(Codigo + "\t" + Nombre + "\t" + CategoriaProducto.Nombre + "\t" + Precio + "\t" + Cantidad + "\t" +
        estado);

    }
}