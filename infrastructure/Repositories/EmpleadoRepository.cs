using MySql.Data.MySqlClient;
using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;

namespace MiniprojectC_.Repositories;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly string _connectionString;

    public EmpleadoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Agregar(Empleado empleado)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var cmd = new MySqlCommand("INSERT INTO empleado (tercero_id, fecha_ingreso, salario_base, eps_id, arl_id) VALUES (@tercero, @fecha, @salario, @eps, @arl)", connection);
        cmd.Parameters.AddWithValue("@tercero", empleado.TerceroId);
        cmd.Parameters.AddWithValue("@fecha", empleado.FechaIngreso);
        cmd.Parameters.AddWithValue("@salario", empleado.SalarioBase);
        cmd.Parameters.AddWithValue("@eps", empleado.EpsId);
        cmd.Parameters.AddWithValue("@arl", empleado.ArlId);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Empleado empleado)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var cmd = new MySqlCommand("UPDATE empleado SET tercero_id = @tercero, fecha_ingreso = @fecha, salario_base = @salario, eps_id = @eps, arl_id = @arl WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@tercero", empleado.TerceroId);
        cmd.Parameters.AddWithValue("@fecha", empleado.FechaIngreso);
        cmd.Parameters.AddWithValue("@salario", empleado.SalarioBase);
        cmd.Parameters.AddWithValue("@eps", empleado.EpsId);
        cmd.Parameters.AddWithValue("@arl", empleado.ArlId);
        cmd.Parameters.AddWithValue("@id", empleado.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var cmd = new MySqlCommand("DELETE FROM empleado WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public Empleado? ObtenerPorId(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var cmd = new MySqlCommand("SELECT * FROM empleado WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Empleado
            {
                Id = reader.GetInt32("id"),
                TerceroId = reader.GetInt32("tercero_id"),
                FechaIngreso = reader.GetDateTime("fecha_ingreso"),
                SalarioBase = reader.GetDecimal("salario_base"),
                EpsId = reader.GetInt32("eps_id"),
                ArlId = reader.GetInt32("arl_id")
            };
        }
        return null;
    }

    public List<Empleado> ObtenerTodos()
    {
        var empleados = new List<Empleado>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var cmd = new MySqlCommand("SELECT * FROM empleado", connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            empleados.Add(new Empleado
            {
                Id = reader.GetInt32("id"),
                TerceroId = reader.GetInt32("tercero_id"),
                FechaIngreso = reader.GetDateTime("fecha_ingreso"),
                SalarioBase = reader.GetDecimal("salario_base"),
                EpsId = reader.GetInt32("eps_id"),
                ArlId = reader.GetInt32("arl_id")
            });
        }
        return empleados;
    }
}
