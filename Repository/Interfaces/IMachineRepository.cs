using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Entities;


namespace Repository.Interfaces
{
    public interface IMachineRepository
    {
        Task<Machine> GetMachineByIdAsync(int id);
        Task<IList<Machine>> GetMachinesAsync();
        Task<int> GetMachineTotalProduction(int id);
        Task<int> DeleteMachine(int id);
    }
}
