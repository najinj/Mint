using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.API.ViewModels.MachineViewModels;
using Mint.Services;

namespace Mint.API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    public class MachineController : ControllerBase
    {
        private readonly IMachineServices _machineService;

        public MachineController(IMachineServices machineRepository)
        {
            _machineService = machineRepository;
        }

        [ProducesResponseType(typeof(List<MachineWithProductionViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("/Machines")]
        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            var machines = await _machineService.GetMachinesAsync();
            if (machines == null || !machines.Any())
                return NoContent();

            var machinesWithProductions =  machines.Select(m => new MachineWithProductionViewModel
            {
                Name = m.Name,
                MachineId = m.MachineId,
                Production = m.Production.MachineProductionId
            }).ToList();
            return Ok(machinesWithProductions);
        }



        [ProducesResponseType(typeof(MachineViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/Machine/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMachine(int id)
        {
            var machine =  await _machineService.GetMachineByIdAsync(id);
            if (machine == null)
                return NotFound();

            var machineViewModel = new MachineViewModel
            {
                Description = machine.Description,
                Name = machine.Name,
                MachineId = machine.MachineId
            };
            return Ok(machineViewModel);
        }


        [ProducesResponseType(typeof(TotalProdutionViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/Machine/totalProduction")]
        [HttpGet]
        public async Task<IActionResult> GetTotalProduction(int id)
        {
            try
            {
                var totalProdution = await _machineService.GetMachineTotalProduction(id);
                return Ok(new TotalProdutionViewModel { TotalProdution = totalProdution });
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            
        }


        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/Machine/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            try
            {
                await _machineService.DeleteMachine(id);
                return Ok(1);
            }
            catch (Exception ex)
            {
                return NotFound(0);
            }
        }
    }
}
