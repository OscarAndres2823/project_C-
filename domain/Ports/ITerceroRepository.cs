using MiniprojectC_.domain.Entities;
using MySql.Data.MySqlClient;

namespace MiniprojectC_.infrastructure.mysql.Repositories
{
    public class TerceroRepository
    {
        private readonly string _connectionString;

        // Este es el constructor correcto
        public TerceroRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Crear(Tercero t)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO terceros (Nombre, Apellidos, Email, TipoDocumentoId, TipoTerceroId, CiudadId) VALUES (@Nombre, @Apellidos, @Email, @TipoDocumentoId, @TipoTerceroId, @CiudadId)", conn);
            cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", t.Apellidos);
            cmd.Parameters.AddWithValue("@Email", t.Email);
            cmd.Parameters.AddWithValue("@TipoDocumentoId", t.TipoDocumentoId);
            cmd.Parameters.AddWithValue("@TipoTerceroId", t.TipoTerceroId);
            cmd.Parameters.AddWithValue("@CiudadId", t.CiudadId);
            cmd.ExecuteNonQuery();
        }

        public List<Tercero> ObtenerTodos()
        {
            var lista = new List<Tercero>();
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM terceros", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Tercero
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
            return lista;
        }

        public Tercero? ObtenerPorId(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM terceros WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Tercero
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Apellidos = reader.GetString("Apellidos"),
                    Email = reader.GetString("Email"),
                    TipoDocumentoId = reader.GetInt32("TipoDocumentoId"),
                    TipoTerceroId = reader.GetInt32("TipoTerceroId"),
                    CiudadId = reader.GetInt32("CiudadId")
                };
            }
            return null;
        }

        public void Actualizar(Tercero t)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("UPDATE terceros SET Nombre = @Nombre, Apellidos = @Apellidos, Email = @Email, TipoDocumentoId = @TipoDocumentoId, TipoTerceroId = @TipoTerceroId, CiudadId = @CiudadId WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", t.Apellidos);
            cmd.Parameters.AddWithValue("@Email", t.Email);
            cmd.Parameters.AddWithValue("@TipoDocumentoId", t.TipoDocumentoId);
            cmd.Parameters.AddWithValue("@TipoTerceroId", t.TipoTerceroId);
            cmd.Parameters.AddWithValue("@CiudadId", t.CiudadId);
            cmd.Parameters.AddWithValue("@Id", t.Id);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM terceros WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
