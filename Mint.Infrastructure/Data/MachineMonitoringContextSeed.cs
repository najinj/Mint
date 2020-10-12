using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Mint.Repository.Entities;

namespace Mint.Repository.Data
{
    public class MachineMonitoringContextSeed
    {
        public static async Task SeedAsync(MachineMonitoringContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Machines.Any())
                {
                    var machines = new List<Machine>
                    {
                        new Machine
                        {
                            Name = "Machine 1",
                            Description = "This is a description for Machine 1"
                        },
                        new Machine
                        {
                            Name = "Machine 2",
                            Description = "This is a description for Machine 2"
                        },
                        new Machine
                        {
                            Name = "Machine 3",
                            Description = "This is a description for Machine 3"
                        },
                    };
                    context.Machines.AddRange(machines);
                    await context.SaveChangesAsync();
                }
                if (!context.MachineProductions.Any())
                {
                    var machinesProductions = new List<MachineProduction>
                    {
                        new MachineProduction
                        {
                            MachineId = 1,
                            TotalProduction = 1,
                        },
                        new MachineProduction
                        {
                            MachineId = 2,
                            TotalProduction = 2,
                        },
                        new MachineProduction
                        {
                            MachineId = 3,
                            TotalProduction = 3,
                        },
                    };
                    context.MachineProductions.AddRange(machinesProductions);
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MachineMonitoringContext>();
                logger.LogError(ex, "Error while seeding data");
            }
        }
    }
}
