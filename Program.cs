using System;
using MiniprojectC_.UI;
using MiniprojectC_.application.Services;
using MiniprojectC_.infrastructure.mysql.repositories;
using MiniprojectC_.application.UI.Productos;
using MiniprojectC_.application.UI.Empleados;
using MiniprojectC_.application.services;
using MiniprojectC_._application.Services;
using MiniprojectC_.infrastructure.mysql.Repositories;
using MiniprojectC_.Repositories;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;user=root;password=123456;database=soe";

        
        var clienteService = new ClienteService(new ClienteRepository(connectionString));
        var productoService = new ProductoService(new ProductoRepository(connectionString));
        var empleadoService = new EmpleadoService(new EmpleadoRepository(connectionString));
        var proveedorService = new ProveedorService(new ProveedorRepository(connectionString));

        var uiCliente = new UICliente(clienteService);
        var uiProducto = new UIProducto(productoService);
        var uiEmpleado = new UIEmpleado(empleadoService);
        var uiProveedor = new UIProveedor(proveedorService);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- MENÚ PRINCIPAL -----");
            Console.WriteLine("1. Clientes");
            Console.WriteLine("2. Productos");
            Console.WriteLine("3. Empleados");
            Console.WriteLine("4. Proveedores");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    uiCliente.MostrarMenu();
                    break;
                case "2":
                    uiProducto.MostrarMenu();
                    break;
                case "3":
                    uiEmpleado.MostrarMenu();
                    break;
                case "4":
                    uiProveedor.MostrarMenu();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}