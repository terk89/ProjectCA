using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    // Model for a single calibration record related to specific EquipmentItem
    public class CalibrationRecord
    {
        [Key]
        public int CalibrationRecordID { get; set; }
       
        // ID of corresponding EquipmentItem
        public int EquipmentID { get; set; }
        public EquipmentItem? Equipment { get; set; }

        public DateTime CalibrationDate { get; set; }

        //ID of person condunctin calibrations
        public string UserID { get; set; }
        public ApplicationUser? User { get; set; }

        // Calibration certificate stored in PDF format
        public byte[] CalibrationCert { get; set; } 

    }
}
