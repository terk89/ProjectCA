using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    public class Manufacturer
    {
        // Manufacturer ID
        [Key]
        public int ManufacturerID { get; set; }
        // Manufacturer Name
        [Required]
        public string Name { get; set; }
        // Collection of Equipment Items related to this manufacturer
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();

    }
}

