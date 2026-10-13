public class Producto
{
    private string codigo;
    private string nombre;
    private decimal precio;
    private int cantidad;
    private Categoria categoriaProducto;

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public decimal Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }

    public Categoria CategoriaProducto
    {
        get { return categoriaProducto; }
        set { categoriaProducto = value; }
    }

    public Producto(string codigo, string nombre, decimal precio, int cantidad, Categoria categoria)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.precio = precio;
        this.cantidad = cantidad;
        this.categoriaProducto = categoria;
    }

    public bool EstaAgotado()
    {
        if (cantidad == 0)
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
        return precio * cantidad;
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

        Console.WriteLine(codigo + "\t" + nombre + "\t" + categoriaProducto.Nombre + "\t" + precio + "\t" + cantidad + "\t" +
        estado);

    }
}