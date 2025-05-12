using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MiniprojectC_.Domain;

namespace MiniprojectC_.infrastructure.mysql.repositories
{
    public class PaisRepository
    {
        private readonly string _connectionString;

        public PaisRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Crear(Pais pais)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var cmd = new MySqlCommand("INSERT INTO pais (id, nombre) VALUES (@id, @nombre)", connection);
            cmd.Parameters.AddWithValue("@id", pais.Id);
            cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
            cmd.ExecuteNonQuery();
        }

        public List<Pais> ObtenerTodos()
        {
            var lista = new List<Pais>();
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var cmd = new MySqlCommand("SELECT * FROM pais", connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Pais
                {
                    Id = reader.GetInt32("id"),
                    Nombre = reader.GetString("nombre")
                });
            }

            return lista;
        }

        public void Actualizar(Pais pais)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var cmd = new MySqlCommand("UPDATE pais SET nombre = @nombre WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
            cmd.Parameters.AddWithValue("@id", pais.Id);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            var cmd = new MySqlCommand("DELETE FROM pais WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
