﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Data;
using VehicleManagement.Repository;

namespace TestVehicle
{
    internal class VehicleRepositroyFake : IVehicleRepository

    {

        private readonly List<VehicleDto>  _vehicles;

        public VehicleRepositroyFake() {
            _vehicles = new List<VehicleDto>()
            {
                new VehicleDto() {Regno="Ts21",Model="Suv",Mfgdate= new DateTime(2020,12,12)},
                new VehicleDto() {Regno="Ts08", Model="Sedan",Mfgdate =new DateTime(2024,08,23) }
            };
        }


        public bool AddVehicle(VehicleDto vehicle)
        {
            _vehicles.Add(vehicle);
            return true;
        }

        public bool DeleteVehicle(int Id)
        {
           _vehicles.Remove(GetVehicleById(Id));
            return true;
        }

        public IEnumerable<VehicleDto> GetAllVehicles()
        {
            return _vehicles;
        }

        public VehicleDto GetVehicleById(int Id)
        {
            var vehicle = _vehicles[Id];
            return vehicle;
        }

        public bool UpdateVehicle(int Id, VehicleDto vehicle)
        {
            return true;
        }
    }
}
