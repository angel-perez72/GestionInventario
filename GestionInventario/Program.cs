class Program
{
    static Almacen almacen = new Almacen();

    static List<Categoria> categorias = new List<Categoria>
    {
        new Categoria(1, "Alimentos"),
        new Categoria(2, "Electronica"),
        new Categoria(3, "Limpieza"),
        new Categoria(4, "Ropa")
    };

    static void Main()
    {
        string opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("Inventario");
            Console.WriteLine();
            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Listar");
            Console.WriteLine("5. Por categoria");
            Console.WriteLine("6. Agotados");
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.Write("Opcion: ");

            opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Registrar();
                    break;

                case "2":
                    Buscar();
                    break;

                case "3":
                    Eliminar();
                    break;

                case "4":
                    Listar(almacen.ListarProductos());
                    break;

                case "5":
                    PorCategoria();
                    break;

                case "6":
                    Listar(almacen.ListarAgotados());
                    break;

                case "0":
                    Console.WriteLine("Programa terminado.");
                    break;

                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }

        } while (opcion != "0");
    }

    static void Registrar()
    {
        Console.Write("Codigo del producto: ");
        string codigo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(codigo))
        {
            Console.WriteLine("El codigo no puede estar vacio.");
            return;
        }

        if (almacen.ExisteCodigo(codigo))
        {
            Console.WriteLine("Ese codigo ya existe.");
            return;
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Categorias:");
        Console.WriteLine();
        Console.WriteLine("1. Alimentos");
        Console.WriteLine("2. Electronica");
        Console.WriteLine("3. Limpieza");
        Console.WriteLine("4. Ropa");

        Console.WriteLine();
        int idCategoria = int.Parse(Console.ReadLine());

        Categoria categoria = null;

        foreach (Categoria elementoCategoria in categorias)
        {
            if (elementoCategoria.Id == idCategoria)
            {
                categoria = elementoCategoria;
                break;
            }
        }

        if (categoria == null)
        {
            Console.WriteLine("Categoria invalida.");
            return;
        }

        Producto producto = new Producto(codigo, nombre, precio, cantidad, categoria);

        almacen.RegistrarProducto(producto);

        Console.WriteLine();
        Console.WriteLine("Producto registrado correctamente.");
    }

    static void Buscar()
    {
        Console.WriteLine();
        Console.Write("Codigo: ");
        string codigo = Console.ReadLine();

        Producto producto = almacen.BuscarPorCodigo(codigo);

        if (producto == null)
        {
            Console.WriteLine();
            Console.WriteLine("Producto no encontrado.");
        }
        else
        {
            Console.WriteLine("Codigo\tNombre\tCategoria\tPrecio\tCantidad\tEstado");
            producto.Mostrar();
        }
    }

    static void Eliminar()
    {
        Console.WriteLine();
        Console.Write("Codigo: ");
        string codigo = Console.ReadLine();

        if (almacen.EliminarProducto(codigo))
            Console.WriteLine("Producto eliminado.");
        else
            Console.WriteLine("Producto no encontrado.");
    }

    static void PorCategoria()
    {
        Console.WriteLine();
        Console.Write("Nombre de la categoria: ");
        string categoria = Console.ReadLine();

        Listar(almacen.ListarPorCategoria(categoria));
    }

    static void Listar(List<Producto> productos)
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("No hay productos");
            return;
        }

        Console.WriteLine("Codigo\tNombre\tCategoria\tPrecio\tCantidad\tEstado");

        foreach (Producto producto in productos)
        {
            producto.Mostrar();
        }
    }
}