using Repository.Entities;
using Repository.Exceptions;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class MachineServices : IMachineServices
    {
        private readonly IMachineRepository _machineRepo;

        public MachineServices(IMachineRepository machineRepository)
        {
            _machineRepo = machineRepository;
        }

        public Task<int> DeleteMachine(int id)
        {
            return _machineRepo.DeleteMachine(id);
        }

        public Task<Machine> GetMachineByIdAsync(int id)
        {
            return _machineRepo.GetMachineByIdAsync(id);
        }

        public Task<IList<Machine>> GetMachinesAsync()
        {
            return _machineRepo.GetMachinesAsync();
        }

        public Task<int?> GetMachineTotalProduction(int id)
        {
            return _machineRepo.GetMachineTotalProduction(id);
        }
    }
}
