using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MiniprojectC_.domain.Entities;
using MiniprojectC_._application.Services;

namespace MiniprojectC_.UI;

public class UICliente
{
    private readonly ClienteService _service;

    public UICliente(ClienteService service)
    {
        _service = service;
    }

    public void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---- CRUD CLIENTE ----");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Listar();
                    break;
                case "2":
                    Agregar();
                    break;
                case "3":
                    Editar();
                    break;
                case "4":
                    Eliminar();
                    break;
                case "0":
                    return;
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void Listar()
    {
        var clientes = _service.GetAll();
        Console.WriteLine("ID | Fecha Nacimiento | Fecha Compra");
        foreach (var c in clientes)
        {
            Console.WriteLine($"{c.Id} | {c.FechaNacimiento:yyyy-MM-dd} | {c.FechaCompra:yyyy-MM-dd}");
        }
    }

    private void Agregar()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Fecha Nacimiento (yyyy-mm-dd): ");
        var fn = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Fecha Compra (yyyy-mm-dd): ");
        var fc = DateTime.Parse(Console.ReadLine()!);
        _service.Add(new Cliente { Id = id, FechaNacimiento = fn, FechaCompra = fc });
        Console.WriteLine("Cliente agregado.");
    }

    private void Editar()
    {
        Console.Write("ID del cliente a editar: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Nueva Fecha Nacimiento (yyyy-mm-dd): ");
        var fn = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Nueva Fecha Compra (yyyy-mm-dd): ");
        var fc = DateTime.Parse(Console.ReadLine()!);
        _service.Update(new Cliente { Id = id, FechaNacimiento = fn, FechaCompra = fc });
        Console.WriteLine("Cliente actualizado.");
    }

    private void Eliminar()
    {
        Console.Write("ID del cliente a eliminar: ");
        int id = int.Parse(Console.ReadLine()!);
        _service.Delete(id);
        Console.WriteLine("Cliente eliminado.");
    }
}
