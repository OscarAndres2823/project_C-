using MiniprojectC_.domain.Entities;
using MiniprojectC_.application.Services;

namespace MiniprojectC_.application.UI.Empleados;

public class UIEmpleado
{
    private readonly EmpleadoService _service;

    public UIEmpleado(EmpleadoService service)
    {
        _service = service;
    }

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("==== CRUD EMPLEADO ====");
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
        var empleado = new Empleado();
        Console.Write("Tercero ID: ");
        empleado.TerceroId = int.Parse(Console.ReadLine()!);
        Console.Write("Fecha ingreso (yyyy-MM-dd): ");
        empleado.FechaIngreso = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Salario base: ");
        empleado.SalarioBase = decimal.Parse(Console.ReadLine()!);
        Console.Write("EPS ID: ");
        empleado.EpsId = int.Parse(Console.ReadLine()!);
        Console.Write("ARL ID: ");
        empleado.ArlId = int.Parse(Console.ReadLine()!);

        _service.Crear(empleado);
        Console.WriteLine("Empleado agregado.");
    }

    private void Listar()
    {
        var lista = _service.ObtenerTodos();
        foreach (var e in lista)
        {
            Console.WriteLine($"ID: {e.Id}, TerceroId: {e.TerceroId}, FechaIngreso: {e.FechaIngreso.ToShortDateString()}, Salario: {e.SalarioBase}");
        }
    }

    private void Buscar()
    {
        Console.Write("ID del empleado: ");
        int id = int.Parse(Console.ReadLine()!);
        var e = _service.ObtenerPorId(id);
        if (e != null)
        {
            Console.WriteLine($"ID: {e.Id}, TerceroId: {e.TerceroId}, FechaIngreso: {e.FechaIngreso}, Salario: {e.SalarioBase}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void Editar()
    {
        Console.Write("ID del empleado a editar: ");
        int id = int.Parse(Console.ReadLine()!);
        var e = _service.ObtenerPorId(id);
        if (e == null)
        {
            Console.WriteLine("Empleado no encontrado.");
            return;
        }

        Console.Write("Nuevo Tercero ID: ");
        e.TerceroId = int.Parse(Console.ReadLine()!);
        Console.Write("Nueva fecha ingreso (yyyy-MM-dd): ");
        e.FechaIngreso = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Nuevo salario base: ");
        e.SalarioBase = decimal.Parse(Console.ReadLine()!);
        Console.Write("Nuevo EPS ID: ");
        e.EpsId = int.Parse(Console.ReadLine()!);
        Console.Write("Nuevo ARL ID: ");
        e.ArlId = int.Parse(Console.ReadLine()!);

        _service.Actualizar(e);
        Console.WriteLine("Empleado actualizado.");
    }

    private void Eliminar()
    {
        Console.Write("ID del empleado a eliminar: ");
        int id = int.Parse(Console.ReadLine()!);
        _service.Eliminar(id);
        Console.WriteLine("Empleado eliminado.");
    }
}
