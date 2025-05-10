using MySql.Data.MySqlClient;
using MiniprojectC_.domain.Entities;
using MiniprojectC_.application.Ports;

namespace MiniprojectC_.infrastructure.mysql.Repositories;

public class TerceroRepository : ITerceroRepository
{
    private readonly string _connectionString;

    public TerceroRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Tercero tercero)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var query = @"INSERT INTO Tercero (Nombre, Apellidos, Email, TipoDocumentoId, TipoTerceroId, CiudadId) 
                      VALUES (@Nombre, @Apellidos, @Email, @TipoDocumentoId, @TipoTerceroId, @CiudadId)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Nombre", tercero.Nombre);
        cmd.Parameters.AddWithValue("@Apellidos", tercero.Apellidos);
        cmd.Parameters.AddWithValue("@Email", tercero.Email);
        cmd.Parameters.AddWithValue("@TipoDocumentoId", tercero.TipoDocumentoId);
        cmd.Parameters.AddWithValue("@TipoTerceroId", tercero.TipoTerceroId);
        cmd.Parameters.AddWithValue("@CiudadId", tercero.CiudadId);
        cmd.ExecuteNonQuery();
    }

    public List<Tercero> GetAll()
    {
        var terceros = new List<Tercero>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var query = "SELECT * FROM Tercero";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            terceros.Add(new Tercero
            {
                Id = reader.GetInt32("Id"),
                Nombre = reader.GetString("Nombre"),
                Apellidos = reader.GetString("Apellidos"),
                Email = reader.GetString("Email"),
                TipoDocumentoId = reader.GetInt32("TipoDocumentoId"),
                TipoTerceroId = reader.GetInt32("TipoTerceroId"),
                CiudadId = reader.GetInt32("CiudadId")
            });
        }
        return terceros;
    }

    public void Update(Tercero tercero)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var query = @"UPDATE Tercero SET Nombre = @Nombre, Apellidos = @Apellidos, Email = @Email, 
                      TipoDocumentoId = @TipoDocumentoId, TipoTerceroId = @TipoTerceroId, CiudadId = @CiudadId 
                      WHERE Id = @Id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Nombre", tercero.Nombre);
        cmd.Parameters.AddWithValue("@Apellidos", tercero.Apellidos);
        cmd.Parameters.AddWithValue("@Email", tercero.Email);
        cmd.Parameters.AddWithValue("@TipoDocumentoId", tercero.TipoDocumentoId);
        cmd.Parameters.AddWithValue("@TipoTerceroId", tercero.TipoTerceroId);
        cmd.Parameters.AddWithValue("@CiudadId", tercero.CiudadId);
        cmd.Parameters.AddWithValue("@Id", tercero.Id);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var query = "DELETE FROM Tercero WHERE Id = @Id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }
}
