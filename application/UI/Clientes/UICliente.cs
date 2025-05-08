using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MiniprojectC_.application.Services;

namespace MiniprojectC_.UI.Clientes
{
    public class UICliente
    {
        private readonly ClienteService _clienteService;

        public UICliente(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void AgregarCliente()
        {
            Console.WriteLine("Ingrese el ID del cliente:");
            int id = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Ingrese la fecha de nacimiento (dd/MM/yyyy):");
            DateTime fechaNacimiento = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);

            Console.WriteLine("Ingrese la fecha de compra (dd/MM/yyyy):");
            DateTime fechaCompra = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);

            var cliente = new ClienteDTO
            {
                Id = id,
                FechaNacimiento = fechaNacimiento,
                FechaCompra = fechaCompra
            };

            _clienteService.AgregarCliente(cliente);
            Console.WriteLine("Cliente agregado exitosamente.");
        }   
    }
}

    public class ClienteDTO
    {
        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCompra { get; set; }
    }
