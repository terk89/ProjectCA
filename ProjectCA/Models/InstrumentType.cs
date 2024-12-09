using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    public class InstrumentType
    {
        [Key]
        public int InstrumentTypeID { get; set; }

        [Required(ErrorMessage = "The Type is required.")]
        public string Type { get; set; }

        public int? CalibrationInterval { get; set; }

        public ICollection<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();

    }
}
