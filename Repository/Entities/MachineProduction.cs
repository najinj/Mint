using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class MachineProduction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineProductionId { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int TotalProduction { get; set; }
    }
}
