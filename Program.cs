using MiniprojectC_.UI;
using MiniprojectC_.application.Services;
using MiniprojectC_.infrastructure.mysql. ;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;user=root;password=tu_contraseña;database=tu_base_datos";

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
            Console.WriteLine("\n========= MENÚ PRINCIPAL =========");
            Console.WriteLine("1. CRUD Cliente");
            Console.WriteLine("2. CRUD Producto");
            Console.WriteLine("3. CRUD Empleado");
            Console.WriteLine("4. CRUD Proveedor");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

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
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
