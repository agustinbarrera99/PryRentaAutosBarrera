namespace PryRentaAutosBarrera.Entities
{
    public enum EstadoVehiculo
    {
        Disponible,
        Alquilado,
        Mantenimiento
    }

    public class Vehiculo
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public decimal PrecioPorDia { get; set; }
        public EstadoVehiculo Estado { get; set; }
        public bool Activo { get; set; }
    }
}