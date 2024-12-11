using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace ProjectCA.Models
{
    public class EquipmentItem
    {
        // ID
        [Key]
        public int EquipmentID { get; set; }
        // Owner ID
        public string UserID { get; set; } // Id of the owner
        // Specific type of instrument
        public int InstrumentTypeID { get; set; }
        // Specific manufacturer
        public int ManufacturerID { get; set; }
        // unique catalog number
        public string? CatNumber { get; set; } // specific catalog number 
        // claibration due date
        public DateTime CalibrationDue { get; set; }
        // instruments serial number
        public string? SerialNumber { get; set; }
        // status: in service, awaiting calibration, damaged, lost
        public string? Status { get; set; }
        // collection of related Calibration Records for this instrument
        public ICollection<CalibrationRecord> CalibrationRecords { get; set; } = new List<CalibrationRecord>();

        public ApplicationUser? User { get; set; }
        public InstrumentType? InstrumentType { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
