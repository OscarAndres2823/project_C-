using MySql.Data.MySqlClient;
using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;

namespace MiniprojectC_.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly string _connectionString;

    public ProductoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Agregar(Producto producto)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var cmd = new MySqlCommand("INSERT INTO producto (nombre, stock, stock_minimo, stock_maximo, createdAt, updatedAt, bar_code) VALUES (@nombre, @stock, @stockMinimo, @stockMaximo, @createdAt, @updatedAt, @barCode)", connection);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@stock", producto.Stock);
        cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);
        cmd.Parameters.AddWithValue("@stockMaximo", producto.StockMaximo);
        cmd.Parameters.AddWithValue("@createdAt", producto.CreatedAt);
        cmd.Parameters.AddWithValue("@updatedAt", producto.UpdatedAt);
        cmd.Parameters.AddWithValue("@barCode", producto.BarCode);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Producto producto)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var cmd = new MySqlCommand("UPDATE producto SET nombre = @nombre, stock = @stock, stock_minimo = @stockMinimo, stock_maximo = @stockMaximo, createdAt = @createdAt, updatedAt = @updatedAt, bar_code = @barCode WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@stock", producto.Stock);
        cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);
        cmd.Parameters.AddWithValue("@stockMaximo", producto.StockMaximo);
        cmd.Parameters.AddWithValue("@createdAt", producto.CreatedAt);
        cmd.Parameters.AddWithValue("@updatedAt", producto.UpdatedAt);
        cmd.Parameters.AddWithValue("@barCode", producto.BarCode);
        cmd.Parameters.AddWithValue("@id", producto.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var cmd = new MySqlCommand("DELETE FROM producto WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public Producto? ObtenerPorId(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var cmd = new MySqlCommand("SELECT * FROM producto WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Producto
            {
                Id = reader.GetInt32("id"),
                Nombre = reader.GetString("nombre"),
                Stock = reader.GetInt32("stock"),
                StockMinimo = reader.GetInt32("stock_minimo"),
                StockMaximo = reader.GetInt32("stock_maximo"),
                CreatedAt = reader.GetDateTime("createdAt"),
                UpdatedAt = reader.GetDateTime("updatedAt"),
                BarCode = reader.GetString("bar_code")
            };
        }

        return null;
    }

    public List<Producto> ObtenerTodos()
    {
        var productos = new List<Producto>();
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var cmd = new MySqlCommand("SELECT * FROM producto", connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            productos.Add(new Producto
            {
                Id = reader.GetInt32("id"),
                Nombre = reader.GetString("nombre"),
                Stock = reader.GetInt32("stock"),
                StockMinimo = reader.GetInt32("stock_minimo"),
                StockMaximo = reader.GetInt32("stock_maximo"),
                CreatedAt = reader.GetDateTime("createdAt"),
                UpdatedAt = reader.GetDateTime("updatedAt"),
                BarCode = reader.GetString("bar_code")
            });
        }

        return productos;
    }
}
