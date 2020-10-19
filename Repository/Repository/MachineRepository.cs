using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Data;
using Repository.Entities;
using Repository.Exceptions;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private readonly MachineMonitoringContext _context;
        private readonly ILogger _logger;
        public MachineRepository(MachineMonitoringContext context, ILogger<MachineRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> DeleteMachine(int id)
        {
            var machine = await GetMachineByIdAsync(id);
            if (machine == null)
            {
                _logger.LogError($"Deleting machine failed : Machine with the id {id} was not found");
                throw new MachineNotFoundException();
            }
            var machineProduction = await _context.MachineProductions
               .FirstOrDefaultAsync(p => p.MachineId == id);
            
            if(machineProduction != null)
            {
                _logger.Log(LogLevel.Information, $"Deleting machineproduction for Machine with the id {id} ");
                _context.MachineProductions.Remove(machineProduction);
            }

            _logger.Log(LogLevel.Information, $"Deleting Machine with the id {id} ");
            _context.Machines.Remove(machine);

            return await _context.SaveChangesAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            _logger.Log(LogLevel.Information, $"fetching Machine with the id : {id} ");
            return await _context.Machines
                        .FirstOrDefaultAsync(p => p.MachineId == id);
        }

        public async Task<IList<Machine>> GetMachinesAsync()
        {
            _logger.Log(LogLevel.Information, "fetching all Machines");
            return await _context.Machines
                         .Include(p => p.Production)
                         .ToListAsync();
        }

        public  async Task<int> GetMachineTotalProduction(int id)
        {
            _logger.Log(LogLevel.Information, $"fetching all productions for machine withe id : {id}");
            var productions = await _context.MachineProductions
                .FirstOrDefaultAsync(p => p.MachineId == id);
            if (productions == null)
            {
                _logger.LogError($"No production was found for machine with id : {id}");
                throw new MachineProductionNotFoundException(string.Format("No production was found for machine with id : {0}", id));
            }

            return productions.TotalProduction;
        }

    }
}
