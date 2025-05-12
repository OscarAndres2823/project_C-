using System;
using MiniprojectC_.UI;
using MiniprojectC_.application.Services;
using MiniprojectC_.infrastructure.mysql.repositories;
using MiniprojectC_.application.UI.Productos;
using MiniprojectC_.application.UI.Empleados;
using MiniprojectC_.application.UI.Terceros;
using MiniprojectC_.application.UI.Proveedores;
using MiniprojectC_.Application.UI.Arl;
using MiniprojectC_.Application.UI.Eps;
using MiniprojectC_.application.services;
using MiniprojectC_.Repositories;
using MiniprojectC_.infrastructure.mysql.Repositories;
using MiniprojectC_.Application.Services;     // <- Servicio de CrudFaltante
using MiniprojectC_.Application.UI;           // <- UI de CrudFaltante

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;user=root;password=123456;database=soe";

        // Servicios
        var clienteService = new ClienteService(new ClienteRepository(connectionString));
        var productoService = new ProductoService(new ProductoRepository(connectionString));
        var empleadoService = new EmpleadoService(new EmpleadoRepository(connectionString));
        var proveedorService = new ProveedorService(new ProveedorRepository(connectionString));
        var terceroService = new TerceroService(new TerceroRepository(connectionString));
        var crudFaltanteService = new CrudFaltanteService(); // <- Servicio para los cruds adicionales

        // Interfaces de usuario
        var uiCliente = new UICliente(clienteService);
        var uiProducto = new UIProducto(productoService);
        var uiEmpleado = new UIEmpleado(empleadoService);
        var uiProveedor = new UIProveedor(proveedorService);
        var uiTercero = new UITercero(terceroService);
        var uiArl = new UIArl();
        var uiEps = new UIEps();
        var uiCrudFaltante = new CrudFaltanteUI(crudFaltanteService); // <- UI para los cruds adicionales

        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- MENÚ PRINCIPAL -----");
            Console.WriteLine("1. Clientes");
            Console.WriteLine("2. Productos");
            Console.WriteLine("3. Empleados");
            Console.WriteLine("4. Proveedores");
            Console.WriteLine("5. Terceros");
            Console.WriteLine("6. ARL");
            Console.WriteLine("7. EPS");
            Console.WriteLine("8. Módulos Faltantes");
            Console.WriteLine("0. Salir");
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
                case "5":
                    uiTercero.Menu();
                    break;
                case "6":
                    uiArl.Menu();
                    break;
                case "7":
                    uiEps.Menu();
                    break;
                case "8":
                    uiCrudFaltante.MostrarMenu(); // <- Invoca el submenú con todos los cruds nuevos
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
