using System;
using System.Collections.Generic;
using System.Data.OleDb;
using PryRentaAutosBarrera.Entities;

namespace PryRentaAutosBarrera.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        // ─── LISTAR TODOS ───────────────────────────────────────────
        public List<Vehiculo> GetAll()
        {
            var lista = new List<Vehiculo>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Vehiculos WHERE Activo = True";

                using (var cmd = new OleDbCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearVehiculo(reader));
                    }
                }
            }

            return lista;
        }

        // ─── OBTENER POR ID ─────────────────────────────────────────
        public Vehiculo GetById(int id)
        {
            Vehiculo vehiculo = null;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Vehiculos WHERE Id = @Id";

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            vehiculo = MapearVehiculo(reader);
                    }
                }
            }

            return vehiculo;
        }

        // ─── AGREGAR ────────────────────────────────────────────────
        public void Add(Vehiculo v)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Vehiculos 
                               (Patente, Marca, Modelo, Anio, Color, PrecioPorDia, Estado, Activo)
                               VALUES (@Patente, @Marca, @Modelo, @Anio, @Color, @PrecioPorDia, @Estado, @Activo)";

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Patente", v.Patente);
                    cmd.Parameters.AddWithValue("@Marca", v.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", v.Modelo);
                    cmd.Parameters.AddWithValue("@Anio", v.Anio);
                    cmd.Parameters.AddWithValue("@Color", v.Color);
                    cmd.Parameters.AddWithValue("@PrecioPorDia", v.PrecioPorDia);
                    cmd.Parameters.AddWithValue("@Estado", v.Estado.ToString());
                    cmd.Parameters.AddWithValue("@Activo", true);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─── EDITAR ─────────────────────────────────────────────────
        public void Update(Vehiculo v)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Vehiculos SET
                               Patente      = @Patente,
                               Marca        = @Marca,
                               Modelo       = @Modelo,
                               Anio         = @Anio,
                               Color        = @Color,
                               PrecioPorDia = @PrecioPorDia,
                               Estado       = @Estado
                               WHERE Id = @Id";

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Patente", v.Patente);
                    cmd.Parameters.AddWithValue("@Marca", v.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", v.Modelo);
                    cmd.Parameters.AddWithValue("@Anio", v.Anio);
                    cmd.Parameters.AddWithValue("@Color", v.Color);
                    cmd.Parameters.AddWithValue("@PrecioPorDia", v.PrecioPorDia);
                    cmd.Parameters.AddWithValue("@Estado", v.Estado.ToString());
                    cmd.Parameters.AddWithValue("@Id", v.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─── BAJA LÓGICA ────────────────────────────────────────────
        public void Delete(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Vehiculos SET Activo = False WHERE Id = @Id";

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ─── MAPPER PRIVADO ─────────────────────────────────────────
        private Vehiculo MapearVehiculo(OleDbDataReader reader)
        {
            return new Vehiculo
            {
                Id = Convert.ToInt32(reader["Id"]),
                Patente = reader["Patente"].ToString(),
                Marca = reader["Marca"].ToString(),
                Modelo = reader["Modelo"].ToString(),
                Anio = Convert.ToInt32(reader["Anio"]),
                Color = reader["Color"].ToString(),
                PrecioPorDia = Convert.ToDecimal(reader["PrecioPorDia"]),
                Estado = (EstadoVehiculo)Enum.Parse(
                                typeof(EstadoVehiculo), reader["Estado"].ToString()),
                Activo = Convert.ToBoolean(reader["Activo"])
            };
        }
    }
}