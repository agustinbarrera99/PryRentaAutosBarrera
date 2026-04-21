using System;
using System.Collections.Generic;
using PryRentaAutosBarrera.Entities;
using PryRentaAutosBarrera.Repository;

namespace PryRentaAutosBarrera.Controllers
{
    public class VehiculoController
    {
        private readonly IVehiculoRepository _repository;

        public VehiculoController()
        {
            _repository = new VehiculoRepository();
        }

        // ─── LISTAR ─────────────────────────────────────────────────
        public List<Vehiculo> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        // ─── OBTENER POR ID ─────────────────────────────────────────
        public Vehiculo ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        // ─── AGREGAR ────────────────────────────────────────────────
        public void Agregar(Vehiculo vehiculo)
        {
            ValidarVehiculo(vehiculo);
            _repository.Add(vehiculo);
        }

        // ─── EDITAR ─────────────────────────────────────────────────
        public void Editar(Vehiculo vehiculo)
        {
            ValidarVehiculo(vehiculo);
            _repository.Update(vehiculo);
        }

        // ─── ELIMINAR (baja lógica) ──────────────────────────────────
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID de vehículo inválido.");

            _repository.Delete(id);
        }

        // ─── VALIDACIONES ────────────────────────────────────────────
        private void ValidarVehiculo(Vehiculo v)
        {
            if (string.IsNullOrWhiteSpace(v.Patente))
                throw new Exception("La patente es obligatoria.");

            if (string.IsNullOrWhiteSpace(v.Marca))
                throw new Exception("La marca es obligatoria.");

            if (string.IsNullOrWhiteSpace(v.Modelo))
                throw new Exception("El modelo es obligatorio.");

            if (v.Anio < 1990 || v.Anio > DateTime.Now.Year + 1)
                throw new Exception($"El año debe estar entre 1990 y {DateTime.Now.Year + 1}.");

            if (v.PrecioPorDia <= 0)
                throw new Exception("El precio por día debe ser mayor a cero.");
        }
    }
}