using System;
using System.Data;
using System.Data.SqlClient;

namespace PryRentaAutosBarrera
{
    /// <summary>
    /// Clase centralizada de conexión a SQL Server.
    /// El connection string se inyecta desde frmPrincipal al instanciar la aplicación.
    /// </summary>
    public class clsConexion : IDisposable
    {
        // ─────────────────────────────────────────────
        //  CAMPOS PRIVADOS
        // ─────────────────────────────────────────────
        private readonly string _connectionString;
        private SqlConnection _conexion;
        private bool _disposed = false;

        // ─────────────────────────────────────────────
        //  CONSTRUCTOR  — recibe el connection string
        // ─────────────────────────────────────────────
        /// <summary>
        /// Inicializa la clase con el connection string proporcionado por frmPrincipal.
        /// </summary>
        /// <param name="connectionString">
        /// Ejemplo: "Server=.\SQLEXPRESS;Database=GestionFlotas;Integrated Security=True;"
        /// </param>
        public clsConexion(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString),
                    "El connection string no puede estar vacío.");

            _connectionString = connectionString;
            _conexion = new SqlConnection(_connectionString);
        }

        // ─────────────────────────────────────────────
        //  PROPIEDADES
        // ─────────────────────────────────────────────
        /// <summary>Expone la conexión activa (lectura).</summary>
        public SqlConnection Conexion => _conexion;

        /// <summary>Estado actual de la conexión.</summary>
        public ConnectionState Estado => _conexion.State;

        // ─────────────────────────────────────────────
        //  ABRIR / CERRAR
        // ─────────────────────────────────────────────
        /// <summary>Abre la conexión si no está ya abierta.</summary>
        public void Abrir()
        {
            if (_conexion.State != ConnectionState.Open)
                _conexion.Open();
        }

        /// <summary>Cierra la conexión si está abierta.</summary>
        public void Cerrar()
        {
            if (_conexion.State == ConnectionState.Open)
                _conexion.Close();
        }

        // ─────────────────────────────────────────────
        //  MÉTODO: Probar conexión
        // ─────────────────────────────────────────────
        /// <summary>
        /// Intenta abrir y cerrar la conexión para verificar que los datos son correctos.
        /// </summary>
        /// <returns>True si la conexión es exitosa.</returns>
        public bool ProbarConexion()
        {
            try
            {
                Abrir();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Cerrar();
            }
        }

        // ─────────────────────────────────────────────
        //  MÉTODO: Ejecutar comando sin retorno
        // ─────────────────────────────────────────────
        /// <summary>Ejecuta un INSERT, UPDATE o DELETE.</summary>
        /// <returns>Número de filas afectadas.</returns>
        public int EjecutarComando(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                Abrir();
                using (var cmd = new SqlCommand(sql, _conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                Cerrar();
            }
        }

        // ─────────────────────────────────────────────
        //  MÉTODO: Ejecutar consulta → DataTable
        // ─────────────────────────────────────────────
        /// <summary>Ejecuta un SELECT y devuelve los resultados en un DataTable.</summary>
        public DataTable EjecutarConsulta(string sql, SqlParameter[] parametros = null)
        {
            var tabla = new DataTable();
            try
            {
                Abrir();
                using (var cmd = new SqlCommand(sql, _conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    using (var adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(tabla);
                }
            }
            finally
            {
                Cerrar();
            }
            return tabla;
        }

        // ─────────────────────────────────────────────
        //  MÉTODO: Ejecutar scalar (ej. COUNT, MAX, identity)
        // ─────────────────────────────────────────────
        /// <summary>Ejecuta una consulta y devuelve el primer valor de la primera fila.</summary>
        public object EjecutarScalar(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                Abrir();
                using (var cmd = new SqlCommand(sql, _conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    return cmd.ExecuteScalar();
                }
            }
            finally
            {
                Cerrar();
            }
        }

        // ─────────────────────────────────────────────
        //  MÉTODO: Stored Procedure
        // ─────────────────────────────────────────────
        /// <summary>Ejecuta un procedimiento almacenado y devuelve un DataTable.</summary>
        public DataTable EjecutarProcedimiento(string nombreProcedimiento, SqlParameter[] parametros = null)
        {
            var tabla = new DataTable();
            try
            {
                Abrir();
                using (var cmd = new SqlCommand(nombreProcedimiento, _conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    using (var adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(tabla);
                }
            }
            finally
            {
                Cerrar();
            }
            return tabla;
        }

        // ─────────────────────────────────────────────
        //  DISPOSE
        // ─────────────────────────────────────────────
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Cerrar();
                    _conexion?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}