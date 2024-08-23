using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Controllers;
using VehicleManagement.Data;
using VehicleManagement.Repository;

namespace TestVehicle
{
    public class VehicleTestingController
    {

        private readonly VehicleController _controller;
        private readonly IVehicleRepository _service;

        public VehicleTestingController()
        {
            _service = new VehicleRepositroyFake() { };
            _controller = new VehicleController(_service);
        }


        [Fact]
        public void Get_WhenCalled_ReturnsOk()
        {
            //Act
            var OkResult = _controller.GetAllVechiles();
            Assert.IsType<OkObjectResult>(OkResult as OkObjectResult);
        }


        [Fact]

        public void Get_WhenCalled_ReturnsAllVehicles()
        {
            var okResult=_controller.GetAllVechiles() as OkObjectResult;

            var items = Assert.IsType<List<VehicleDto>>(okResult.Value);

            Assert.Equal(3, items.Count);
        }






    }
}
