using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Machine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual MachineProduction Production { get; set; }
    }
}
