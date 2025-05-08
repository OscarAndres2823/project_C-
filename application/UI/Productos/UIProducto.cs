using MiniprojectC_.domain.Entities;
using MiniprojectC_.application.Services;

namespace MiniprojectC_.application.UI.Productos;

public class UIProducto
{
    private readonly ProductoService _service;

    public UIProducto(ProductoService service)
    {
        _service = service;
    }

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("==== CRUD PRODUCTO ====");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Buscar por ID");
            Console.WriteLine("4. Editar");
            Console.WriteLine("5. Eliminar");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine()!);

            switch (opcion)
            {
                case 1: Crear(); break;
                case 2: Listar(); break;
                case 3: Buscar(); break;
                case 4: Editar(); break;
                case 5: Eliminar(); break;
            }
        } while (opcion != 0);
    }

    private void Crear()
    {
        var producto = new Producto();
        Console.Write("Nombre: ");
        producto.Nombre = Console.ReadLine()!;
        Console.Write("Stock: ");
        producto.Stock = int.Parse(Console.ReadLine()!);
        Console.Write("Stock mínimo: ");
        producto.StockMinimo = int.Parse(Console.ReadLine()!);
        Console.Write("Stock máximo: ");
        producto.StockMaximo = int.Parse(Console.ReadLine()!);
        producto.CreatedAt = DateTime.Now;
        producto.UpdatedAt = DateTime.Now;
        Console.Write("Código de barras: ");
        producto.BarCode = Console.ReadLine()!;

        _service.Crear(producto);
        Console.WriteLine("Producto agregado.");
    }

    private void Listar()
    {
        var productos = _service.ObtenerTodos();
        foreach (var p in productos)
        {
            Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Stock: {p.Stock}");
        }
    }

    private void Buscar()
    {
        Console.Write("ID del producto: ");
        int id = int.Parse(Console.ReadLine()!);
        var producto = _service.ObtenerPorId(id);
        if (producto is not null)
        {
            Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Stock: {producto.Stock}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    private void Editar()
    {
        Console.Write("ID del producto a editar: ");
        int id = int.Parse(Console.ReadLine()!);
        var producto = _service.ObtenerPorId(id);
        if (producto is null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        producto.Nombre = Console.ReadLine()!;
        Console.Write("Nuevo stock: ");
        producto.Stock = int.Parse(Console.ReadLine()!);
        Console.Write("Nuevo stock mínimo: ");
        producto.StockMinimo = int.Parse(Console.ReadLine()!);
        Console.Write("Nuevo stock máximo: ");
        producto.StockMaximo = int.Parse(Console.ReadLine()!);
        producto.UpdatedAt = DateTime.Now;
        Console.Write("Nuevo código de barras: ");
        producto.BarCode = Console.ReadLine()!;

        _service.Actualizar(producto);
        Console.WriteLine("Producto actualizado.");
    }

    private void Eliminar()
    {
        Console.Write("ID del producto a eliminar: ");
        int id = int.Parse(Console.ReadLine()!);
        _service.Eliminar(id);
        Console.WriteLine("Producto eliminado.");
    }
}
