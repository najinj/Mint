using System.Collections.Generic;
using System.Threading.Tasks;
using Mint.Repository.Entities;


namespace Mint.Repository.Interfaces
{
    public interface IMachineRepository
    {
        Task<Machine> GetMachineByIdAsync(int id);
        Task<IList<Machine>> GetMachinesAsync();
        Task<int> GetMachineTotalProduction(int id);
        Task<int> DeleteMachine(int id);
    }
}
