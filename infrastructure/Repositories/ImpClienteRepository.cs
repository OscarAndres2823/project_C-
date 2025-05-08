using System;
using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;
using MiniprojectC_.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace MiniprojectC_.infrastructure.Repositories
{
    public class ImpClienteRepository 
    {
        private readonly string _connectionString;
        private readonly MySqlConnection _conexion;

        public ImpClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
            _conexion = new MySqlConnection(_connectionString);
        }

        public void AgregarCliente(ClienteDTO cliente)
        {
            try
            {
                _conexion.Open();
                var query = "INSERT INTO clientes (nombre, apellido, fecha_nacimiento, fecha_compra) VALUES (@nombre, @apellido, @fecha_nacimiento, @fecha_compra)";
                using var command = new MySqlCommand(query, _conexion);
                command.Parameters.AddWithValue("@fecha_nacimiento", cliente.FechaNacimiento);
                command.Parameters.AddWithValue("@fecha_compra", cliente.FechaCompra);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente: " + ex.Message);
            }
            finally
            {
                _conexion.Close();
            }
        }
    }
}