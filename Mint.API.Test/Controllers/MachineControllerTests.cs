using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.API.Controllers;
using Mint.API.ViewModels.MachineViewModels;
using Mint.Repository.Entities;
using Mint.Repository.Exceptions;
using Mint.Repository.Interfaces;
using Mint.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mint.API.Test.Controllers
{
    public class MachineControllerTests
    {
        private readonly List<Machine> fakeMachineList = new List<Machine>
        {
            new Machine
            {
                Name = "Machine 1" ,
                Description = "Description 1",
                MachineId = 1,
                Production = new MachineProduction
                {
                    MachineId = 1 ,
                    MachineProductionId = 1,
                    TotalProduction = 3
                }
            },
            new Machine
            {
                Name = "Machine 2" ,
                Description = "Description 2",
                MachineId = 2,
                Production = new MachineProduction
                {
                    MachineId = 2 ,
                    MachineProductionId = 2,
                    TotalProduction = 5
                }
            },
            new Machine
            {
                Name = "Machine 3" ,
                Description = "Description 3",
                MachineId = 2,
                Production = new MachineProduction
                {
                    MachineId = 3,
                    MachineProductionId = 3,
                    TotalProduction = 2
                }
            },
        };

        public MachineControllerTests()
        {

        }

        [Fact]
        public async Task GetMachinesShouldResponseWithOKWhenDataIsNotNull()
        {
            //Arrange 
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.GetMachinesAsync()).ReturnsAsync(fakeMachineList);

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.GetMachines() as OkObjectResult;
            var dataResult = actionResult.Value as IEnumerable<MachineWithProductionViewModel>;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode.Value);
            Assert.NotNull(actionResult);
            Assert.NotNull(dataResult);
            Assert.IsAssignableFrom<IEnumerable<MachineWithProductionViewModel>>(dataResult);
            Assert.Equal(fakeMachineList.Count, dataResult.Count());
        }

        [Fact]
        public async Task GetMachinesShouldResponseWith204WhenDataIsNull()
        {
            //Arrange 
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.GetMachinesAsync()).ReturnsAsync(default(List<Machine>));

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.GetMachines() as NoContentResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async void GetMachineByIdShouldResponseWithOK()
        {
            //Arrange
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.GetMachineByIdAsync(It.IsAny<int>())).ReturnsAsync(fakeMachineList[0]);

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.GetMachine(1) as OkObjectResult;
            var dataResult = actionResult.Value as MachineViewModel;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(dataResult);
            Assert.IsAssignableFrom<MachineViewModel>(dataResult);
            Assert.Equal(fakeMachineList[0].Name, dataResult.Name);
        }


        [Fact]
        public async void GetMachineByIdShouldResponseWith404WhenIdIsNotFound()
        {
            //Arrange
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.GetMachineByIdAsync(It.IsAny<int>())).ReturnsAsync(default(Machine));

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.GetMachine(1) as NotFoundResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task GetMachineProductionShouldResponseWithOK()
        {
            //Arrange
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.GetMachineTotalProduction(It.IsAny<int>())).ReturnsAsync(1);

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.GetTotalProduction(1) as OkObjectResult;
            var dataResult = actionResult.Value as TotalProdutionViewModel;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode.Value);
            Assert.NotNull(actionResult);
            Assert.NotNull(dataResult);
            Assert.IsAssignableFrom<TotalProdutionViewModel>(dataResult);
            Assert.Equal(1, dataResult.TotalProdution);
        }

        [Fact]
        public async Task GetMachineProduction_Should_Responsed_With404_When_Id_Is_Not_Found()
        {
            //Arrange
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.GetMachineTotalProduction(It.IsAny<int>())).ThrowsAsync(new MachineNotFoundException());

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.GetTotalProduction(1) as NotFoundResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task DeleteMachine_Should_Responsed_WithOk()
        {
            //Arrange
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.DeleteMachine(It.IsAny<int>())).ReturnsAsync(1);

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.DeleteMachine(1) as ObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<ObjectResult>(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
            Assert.IsType<int>(actionResult.Value);
            Assert.Equal(1, actionResult.Value);
        }

        [Fact]
        public async Task DeleteMachine_Should_Returns_0_when_no_data_was_deleted()
        {
            //Arrange
            var machineService = new Mock<IMachineServices>();
            machineService.Setup(x => x.DeleteMachine(It.IsAny<int>())).ThrowsAsync(new MachineNotFoundException());

            var machineController = new MachineController(machineService.Object);

            //Act
            var actionResult = await machineController.DeleteMachine(1) as ObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<ObjectResult>(actionResult);
            Assert.IsType<int>(actionResult.Value);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
            Assert.Equal(0, actionResult.Value);
        }
    }
}
