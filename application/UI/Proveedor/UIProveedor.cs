using MiniprojectC_.domain.Entities;
using MiniprojectC_.application.services;

namespace MiniprojectC_.application.UI.Proveedores;

public class UIProveedor
{
    private readonly ProveedorService _servicio;

    public UIProveedor(ProveedorService servicio)
    {
        _servicio = servicio;
    }

    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- CRUD Proveedor ---");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Editar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Listar");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": Agregar(); break;
                case "2": Editar(); break;
                case "3": Eliminar(); break;
                case "4": Listar(); break;
                case "5": return;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
    }

    private void Agregar()
    {
        var proveedor = LeerProveedor();
        _servicio.Crear(proveedor);
        Console.WriteLine("Proveedor agregado.");
    }

    private void Editar()
    {
        var proveedor = LeerProveedor();
        _servicio.Editar(proveedor);
        Console.WriteLine("Proveedor actualizado.");
    }

    private void Eliminar()
    {
        Console.Write("Ingrese el ID del proveedor: ");
        var id = int.Parse(Console.ReadLine()!);
        _servicio.Eliminar(id);
        Console.WriteLine("Proveedor eliminado.");
    }

    private void Listar()
    {
        var proveedores = _servicio.Listar();
        foreach (var p in proveedores)
        {
            Console.WriteLine($"ID: {p.Id}, Tercero ID: {p.TerceroId}, Documento: {p.Documento}, Día Pago: {p.DiaPago}");
        }
    }

    private Proveedor LeerProveedor()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Tercero ID: ");
        int terceroId = int.Parse(Console.ReadLine()!);
        Console.Write("Documento: ");
        string doc = Console.ReadLine()!;
        Console.Write("Día de Pago: ");
        int diaPago = int.Parse(Console.ReadLine()!);

        return new Proveedor { Id = id, TerceroId = terceroId, Documento = doc, DiaPago = diaPago };
    }
}
