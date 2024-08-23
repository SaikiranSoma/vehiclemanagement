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



        [Fact]
        public void GetId_WhenCalled_ReturnsOk()
        {
            //Act 
            var Id = 1;
            var Okresult = _controller.GetVehicleById(Id) as OkObjectResult;
            //Assert

            Assert.IsType<OkObjectResult>(Okresult );
        }


        [Fact]
        public void AddVehicel_Whencalled_ReturnsCreatedResponse() 
        {
            VehicleDto tesetitem=new VehicleDto() { 
                Regno="Ts15",
                Model="Innova",
                Mfgdate=new DateTime(2013,03,09)
            
            };

            var createdresponse=_controller.AddVehicle(tesetitem) as OkObjectResult;

            Assert.IsType<OkObjectResult>(createdresponse);
        }


        [Fact]

        public void UpdateVehicle_whenCalled_ReturnsOk()
        {
            var id=1;
            VehicleDto tesetitem = new VehicleDto()
            {
                Regno = "Ts07",
                Model = "Innova",
                Mfgdate = new DateTime(2020, 08, 23)

            };

            var Okresult = _controller.UpdateVehicle(id, tesetitem) as OkObjectResult;
            Assert.IsType<OkObjectResult>(Okresult);

        }


        [Fact]

        public void DeleteVehicle_whenCalled_ReturnsOk() 
        {
            var Id = 1;
            var okresult = _controller.DeleteVehicle(Id) as OkObjectResult;

            Assert.IsType<OkObjectResult>(okresult);
        }

    }
}
