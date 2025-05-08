using System;
using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;

namespace MiniprojectC_.application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AgregarCliente(ClienteDTO cliente)
        {
            _clienteRepository.AgregarCliente(cliente);
        }

        public List<ClienteDTO> ListarClientes()
        {
            return _clienteRepository.ObtenerClientes();
        }

        public void ActualizarCliente(ClienteDTO cliente)
        {
            _clienteRepository.ActualizarCliente(cliente);
        }

        public void EliminarCliente(int id)
        {
            _clienteRepository.EliminarCliente(id);
        }
    }
}