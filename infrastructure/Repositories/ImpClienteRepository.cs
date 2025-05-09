using System;
using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;
using MiniprojectC_.infrastructure.mysql;
using MySql.Data.MySqlClient;


namespace MiniprojectC_.infrastructure.mysql.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connectionString;

    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Cliente> GetAll()
    {
        var clientes = new List<Cliente>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "SELECT * FROM cliente";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            clientes.Add(new Cliente
            {
                Id = reader.GetInt32("id"),
                FechaNacimiento = reader.GetDateTime("fecha_nacimiento"),
                FechaCompra = reader.GetDateTime("fecha_compra")
            });
        }
        return clientes;
    }

    public void Add(Cliente cliente)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "INSERT INTO cliente (id, fecha_nacimiento, fecha_compra) VALUES (@id, @fn, @fc)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", cliente.Id);
        cmd.Parameters.AddWithValue("@fn", cliente.FechaNacimiento);
        cmd.Parameters.AddWithValue("@fc", cliente.FechaCompra);
        cmd.ExecuteNonQuery();
    }

    public void Update(Cliente cliente)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "UPDATE cliente SET fecha_nacimiento=@fn, fecha_compra=@fc WHERE id=@id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", cliente.Id);
        cmd.Parameters.AddWithValue("@fn", cliente.FechaNacimiento);
        cmd.Parameters.AddWithValue("@fc", cliente.FechaCompra);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "DELETE FROM cliente WHERE id=@id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
