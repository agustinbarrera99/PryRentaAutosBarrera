using System;
using System.Data;
using System.Data.SqlClient;

namespace PryRentaAutosBarrera
{
    public class clsConexion : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _conexion;
        private bool _disposed = false;
        public clsConexion(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString),
                    "El connection string no puede estar vacío.");

            _connectionString = connectionString;
            _conexion = new SqlConnection(_connectionString);
        }

        public SqlConnection Conexion => _conexion;

        public ConnectionState Estado => _conexion.State;

        public void Abrir()
        {
            if (_conexion.State != ConnectionState.Open)
                _conexion.Open();
        }

        public void Cerrar()
        {
            if (_conexion.State == ConnectionState.Open)
                _conexion.Close();
        }

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