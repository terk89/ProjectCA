using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace ProjectCA.Models
{
    public class EquipmentItem
    {

        [Key]
        public int EquipmentID { get; set; }

        public string UserID { get; set; } // Id of the owner

        public int InstrumentTypeID { get; set; }

        public int ManufacturerID { get; set; }

        public string? CatNumber { get; set; } // specific catalog number 

        public DateTime CalibrationDue { get; set; }

        public string? SerialNumber { get; set; }

        public string? Status { get; set; }

        public ICollection<CalibrationRecord> CalibrationRecords { get; set; } = new List<CalibrationRecord>();
        //public ICollection<InstrumentType> InstrumentTypes { get; set; } = new List<InstrumentType>();

        public ApplicationUser? User { get; set; }
        public InstrumentType? InstrumentType { get; set; }
        // Derived property (not mapped to the database)
        public Manufacturer? Manufacturer { get; set; }
    }
}
