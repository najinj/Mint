using Microsoft.EntityFrameworkCore;
using Mint.Repository.Data;
using Mint.Repository.Entities;
using Mint.Repository.Exceptions;
using Mint.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mint.Repository.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private readonly MachineMonitoringContext _context;
        public MachineRepository(MachineMonitoringContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteMachine(int id)
        {
            var machine = await GetMachineByIdAsync(id);
            if (machine == null)
                throw new MachineNotFoundException();

            var machineProduction = await _context.MachineProductions
               .FirstOrDefaultAsync(p => p.MachineId == id);
            
            if(machineProduction != null)
                _context.MachineProductions.Remove(machineProduction);

            _context.Machines.Remove(machine);

            return await _context.SaveChangesAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            return await _context.Machines
                        .FirstOrDefaultAsync(p => p.MachineId == id);
        }

        public async Task<IList<Machine>> GetMachinesAsync()
        {
            return await _context.Machines
                         .Include(p => p.Production)
                         .ToListAsync();
        }

        public  async Task<int> GetMachineTotalProduction(int id)
        {
            var productions = await _context.MachineProductions
                .FirstOrDefaultAsync(p => p.MachineId == id);
            if (productions == null)
                throw new MachineProductionNotFoundException(string.Format("Machine with {0} was not found",id));

            return productions.TotalProduction;
        }

    }
}
