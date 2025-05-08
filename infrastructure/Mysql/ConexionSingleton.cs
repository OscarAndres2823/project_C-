using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MiniprojectC_.infrastructure.mysql;
public class ConexionSingleton
{
    private static ConexionSingleton? _instancia;
    private readonly string _connectionString;
    private MySqlConnection? _conexion;
    public ConexionSingleton(string connectionString)
    {
        _connectionString = connectionString;
    }
    public static ConexionSingleton Instancia(string connectionString)
    {
       _instancia ??= new ConexionSingleton(connectionString);
        return _instancia;
        
    }
}

