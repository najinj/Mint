using Mint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mint.Services
{
    public interface IMachineServices
    {
        Task<Machine> GetMachineByIdAsync(int id);
        Task<IList<Machine>> GetMachinesAsync();
        Task<int> GetMachineTotalProduction(int id);
        Task<int> DeleteMachine(int id);
    }
}
