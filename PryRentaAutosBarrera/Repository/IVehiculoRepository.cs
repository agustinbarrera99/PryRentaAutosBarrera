using System.Collections.Generic;
using PryRentaAutosBarrera.Entities;

namespace PryRentaAutosBarrera.Repository
{
    public interface IVehiculoRepository
    {
        List<Vehiculo> GetAll();
        Vehiculo GetById(int id);
        void Add(Vehiculo vehiculo);
        void Update(Vehiculo vehiculo);
        void Delete(int id);
    }
}