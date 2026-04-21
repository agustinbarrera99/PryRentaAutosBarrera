using System;
using System.IO;
using System.Data.OleDb;

namespace PryRentaAutosBarrera.Repository
{
    public class DatabaseConnection
    {
        private static readonly string _connectionString = BuildConnectionString();

        private static string BuildConnectionString()
        {
            string dbPath = GetDbPath();
            return $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }

        private static string GetDbPath()
        {
            // Sube niveles desde bin\Debug hasta encontrar la carpeta DB
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (dir != null)
            {
                string posibleRuta = Path.Combine(dir.FullName, "DB", "RentaAutos.accdb");

                if (File.Exists(posibleRuta))
                    return posibleRuta;

                dir = dir.Parent;
            }

            throw new Exception("No se encontró el archivo RentaAutos.accdb en ninguna carpeta del proyecto.");
        }

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(_connectionString);
        }
    }
}