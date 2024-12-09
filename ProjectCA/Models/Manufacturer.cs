using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();

    }
}

