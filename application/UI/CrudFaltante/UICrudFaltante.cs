using System;
using MiniprojectC_.Domain;
using MiniprojectC_.Application.Services;
using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.Application.UI
{
    public class CrudFaltanteUI
    {
        private readonly CrudFaltanteService _service;

        public CrudFaltanteUI(CrudFaltanteService service)
        {
            _service = service;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---- CRUD FALTANTES ----");
                Console.WriteLine("1. Tipo Movimiento Caja");
                Console.WriteLine("2. Plan Producto");
                Console.WriteLine("3. Detalle Venta");
                Console.WriteLine("4. Factura");
                Console.WriteLine("5. Compra");
                Console.WriteLine("6. Detalle Compra");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        SubmenuTipoMovimientoCaja();
                        break;
                    case "2":
                        SubmenuPlanProducto();
                        break;
                    case "3":
                        SubmenuDetalleVenta();
                        break;
                    case "4":
                        SubmenuFactura();
                        break;
                    case "5":
                        SubmenuCompra();
                        break;
                    case "6":
                        SubmenuDetalleCompra();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void SubmenuTipoMovimientoCaja()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Tipo Movimiento Caja ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del Tipo de Movimiento de Caja: ");
                        var nombre = Console.ReadLine();
                        _service.AgregarTipoMovimientoCaja(nombre);
                        break;
                    case "2":
                        _service.ListarTipoMovimientoCaja();
                        break;
                    case "3":
                        Console.Write("Ingrese el ID del Tipo de Movimiento de Caja a editar: ");
                        var idEditar = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo nombre: ");
                        var nuevoNombre = Console.ReadLine();
                        _service.EditarTipoMovimientoCaja(idEditar, nuevoNombre);
                        break;
                    case "4":
                        Console.Write("Ingrese el ID del Tipo de Movimiento de Caja a eliminar: ");
                        var idEliminar = int.Parse(Console.ReadLine());
                        _service.EliminarTipoMovimientoCaja(idEliminar);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void SubmenuPlanProducto()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Plan Producto ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del Plan de Producto: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Ingrese la descripción: ");
                        var descripcion = Console.ReadLine();
                        _service.AgregarPlanProducto(nombre, descripcion);
                        break;
                    case "2":
                        _service.ListarPlanProducto();
                        break;
                    case "3":
                        Console.Write("Ingrese el ID del Plan de Producto a editar: ");
                        var idEditar = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo nombre: ");
                        var nuevoNombre = Console.ReadLine();
                        Console.Write("Ingrese la nueva descripción: ");
                        var nuevaDescripcion = Console.ReadLine();
                        _service.EditarPlanProducto(idEditar, nuevoNombre, nuevaDescripcion);
                        break;
                    case "4":
                        Console.Write("Ingrese el ID del Plan de Producto a eliminar: ");
                        var idEliminar = int.Parse(Console.ReadLine());
                        _service.EliminarPlanProducto(idEliminar);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void SubmenuDetalleVenta()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Detalle Venta ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el ID del Producto: ");
                        var productoId = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la cantidad: ");
                        var cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el precio unitario: ");
                        var precioUnitario = decimal.Parse(Console.ReadLine());
                        _service.AgregarDetalleVenta(productoId, cantidad, precioUnitario);
                        break;
                    case "2":
                        _service.ListarDetalleVenta();
                        break;
                    case "3":
                        Console.Write("Ingrese el ID del Detalle de Venta a editar: ");
                        var idEditar = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo ID de Producto: ");
                        var nuevoProductoId = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la nueva cantidad: ");
                        var nuevaCantidad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo precio unitario: ");
                        var nuevoPrecioUnitario = decimal.Parse(Console.ReadLine());
                        _service.EditarDetalleVenta(idEditar, nuevoProductoId, nuevaCantidad, nuevoPrecioUnitario);
                        break;
                    case "4":
                        Console.Write("Ingrese el ID del Detalle de Venta a eliminar: ");
                        var idEliminar = int.Parse(Console.ReadLine());
                        _service.EliminarDetalleVenta(idEliminar);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void SubmenuFactura()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Factura ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            Console.Write("Ingrese el ID del Cliente: ");
                            var clienteId = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese la fecha de la factura (yyyy-MM-dd): ");
                            var fechaInput = Console.ReadLine();
                            DateTime fecha;

                            if (!DateTime.TryParse(fechaInput, out fecha))
                            {
                                Console.WriteLine("La fecha ingresada no es válida.");
                                break;
                            }

                            Console.Write("Ingrese el ID del empleado: ");
                            int empleadoId = int.Parse(Console.ReadLine());

                            Console.Write("Ingrese el total: ");
                            var total = decimal.Parse(Console.ReadLine());

                            // Validación de datos
                            if (clienteId <= 0 || total <= 0)
                            {
                                Console.WriteLine("Los valores ingresados son inválidos.");
                                break;
                            }

                            _service.AgregarFactura(fecha, clienteId, empleadoId);


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":
                        _service.ListarFactura();
                        break;

                    case "3":
                        try
                        {
                            Console.Write("Ingrese el ID de la Factura a editar: ");
                            if (!int.TryParse(Console.ReadLine(), out var idEditar))
                            {
                                Console.WriteLine("ID de factura no válido.");
                                break;
                            }

                            Console.Write("Ingrese el nuevo ID de Cliente: ");
                            if (!int.TryParse(Console.ReadLine(), out var nuevoClienteId) || nuevoClienteId <= 0)
                            {
                                Console.WriteLine("ID de cliente no válido.");
                                break;
                            }

                            Console.Write("Ingrese la nueva fecha (yyyy-MM-dd): ");
                            var nuevaFechaInput = Console.ReadLine();
                            DateTime nuevaFecha;

                            if (!DateTime.TryParse(nuevaFechaInput, out nuevaFecha))
                            {
                                Console.WriteLine("La fecha ingresada no es válida.");
                                break;
                            }

                            Console.Write("Ingrese el nuevo ID de Empleado: ");
                            if (!int.TryParse(Console.ReadLine(), out var nuevoEmpleadoId) || nuevoEmpleadoId <= 0)
                            {
                                Console.WriteLine("El ID de empleado debe ser mayor que cero.");
                                break;
                            }

                            Console.Write("Ingrese el nuevo total: ");
                            if (!decimal.TryParse(Console.ReadLine(), out var nuevoTotal) || nuevoTotal <= 0)
                            {
                                Console.WriteLine("El total debe ser mayor que cero.");
                                break;
                            }

                            _service.EditarFactura(idEditar, nuevaFecha, nuevoClienteId, nuevoEmpleadoId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;


                    case "4":
                        try
                        {
                            Console.Write("Ingrese el ID de la Factura a eliminar: ");
                            var idEliminar = int.Parse(Console.ReadLine());
                            _service.EliminarFactura(idEliminar);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void SubmenuCompra()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Compra ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Ingrese el ID del Proveedor: ");
                            var proveedorId = int.Parse(Console.ReadLine()); // Se debe manejar el error si no se ingresa un número válido
                            Console.Write("Ingrese la fecha de la compra (Formato: dd/MM/yyyy): ");
                            var fecha = DateTime.Parse(Console.ReadLine()); // Manejamos el formato de fecha
                            _service.AgregarCompra(proveedorId, fecha);
                            break;
                        case "2":
                            _service.ListarCompra();
                            break;
                        case "3":
                            Console.Write("Ingrese el ID de la Compra a editar: ");
                            var idEditar = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nuevo ID de Proveedor: ");
                            var nuevoProveedorId = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese la nueva fecha (Formato: dd/MM/yyyy): ");
                            var nuevaFecha = DateTime.Parse(Console.ReadLine());
                            _service.EditarCompra(idEditar, nuevoProveedorId, nuevaFecha);
                            break;
                        case "4":
                            Console.Write("Ingrese el ID de la Compra a eliminar: ");
                            var idEliminar = int.Parse(Console.ReadLine());
                            _service.EliminarCompra(idEliminar);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error al ingresar los datos. Por favor, asegúrese de introducir valores válidos.");
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
        private void SubmenuDetalleCompra()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Detalle Compra ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            Console.Write("Ingrese el ID de la Compra: ");
                            var compraId = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el ID del Producto: ");
                            var productoId = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese la cantidad: ");
                            var cantidad = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el precio unitario: ");
                            var precioUnitario = decimal.Parse(Console.ReadLine());

                            // Validar valores antes de agregar
                            if (compraId <= 0 || productoId <= 0 || cantidad <= 0 || precioUnitario <= 0)
                            {
                                Console.WriteLine("Los valores ingresados son inválidos.");
                                break;
                            }

                            _service.AgregarDetalleCompra(compraId, productoId, cantidad, precioUnitario);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":
                        _service.ListarDetalleCompra();
                        break;

                    case "3":
                        try
                        {
                            Console.Write("Ingrese el ID del Detalle de Compra a editar: ");
                            var idEditar = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nuevo ID de Compra: ");
                            var nuevaCompraId = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nuevo ID de Producto: ");
                            var nuevoProductoId = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese la nueva cantidad: ");
                            var nuevaCantidad = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nuevo precio unitario: ");
                            var nuevoPrecioUnitario = decimal.Parse(Console.ReadLine());

                            if (nuevaCompraId <= 0 || nuevoProductoId <= 0 || nuevaCantidad <= 0 || nuevoPrecioUnitario <= 0)
                            {
                                Console.WriteLine("Los valores ingresados son inválidos.");
                                break;
                            }

                            _service.EditarDetalleCompra(idEditar, nuevaCompraId, nuevoProductoId, nuevaCantidad, nuevoPrecioUnitario);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "4":
                        try
                        {
                            Console.Write("Ingrese el ID del Detalle de Compra a eliminar: ");
                            var idEliminar = int.Parse(Console.ReadLine());
                            _service.EliminarDetalleCompra(idEliminar);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

    }
}
