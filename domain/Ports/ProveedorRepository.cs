using MiniprojectC_.domain.Entities;
using MySql.Data.MySqlClient;

namespace MiniprojectC_.infrastructure.mysql.repositories;

public class ProveedorRepository
{
    private readonly string _connectionString;

    public ProveedorRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Agregar(Proveedor proveedor)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "INSERT INTO proveedor (id, tercero_id, documento, dia_pago) VALUES (@id, @tercero_id, @documento, @dia_pago)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", proveedor.Id);
        cmd.Parameters.AddWithValue("@tercero_id", proveedor.TerceroId);
        cmd.Parameters.AddWithValue("@documento", proveedor.Documento);
        cmd.Parameters.AddWithValue("@dia_pago", proveedor.DiaPago);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Proveedor proveedor)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "UPDATE proveedor SET tercero_id = @tercero_id, documento = @documento, dia_pago = @dia_pago WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", proveedor.Id);
        cmd.Parameters.AddWithValue("@tercero_id", proveedor.TerceroId);
        cmd.Parameters.AddWithValue("@documento", proveedor.Documento);
        cmd.Parameters.AddWithValue("@dia_pago", proveedor.DiaPago);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "DELETE FROM proveedor WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public List<Proveedor> ObtenerTodos()
    {
        var proveedores = new List<Proveedor>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var query = "SELECT * FROM proveedor";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            proveedores.Add(new Proveedor
            {
                Id = reader.GetInt32("id"),
                TerceroId = reader.GetInt32("tercero_id"),
                Documento = reader.GetString("documento"),
                DiaPago = reader.GetInt32("dia_pago")
            });
        }
        return proveedores;
    }
}
