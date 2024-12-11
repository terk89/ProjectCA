using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    public class InstrumentType
    {
        // Type ID
        [Key]
        public int InstrumentTypeID { get; set; }
        // Description of a type
        [Required]
        public string Type { get; set; }
        // Calibration validity (no of months)
        public int? CalibrationInterval { get; set; }
        // Collection of Equipment items related to this type
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();

    }
}
