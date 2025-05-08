using System;
using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.domain.Ports
{
    public interface IClienteRepository
    {
        void AgregarCliente(ClienteDTO cliente);
        List<ClienteDTO> ObtenerClientes();
        void ActualizarCliente(ClienteDTO cliente);
        void EliminarCliente(int id);
    }
}