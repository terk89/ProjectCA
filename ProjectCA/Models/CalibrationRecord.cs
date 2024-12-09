using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    public class CalibrationRecord
    {
        [Key]
        public int CalibrationRecordID { get; set; }

        public int EquipmentID { get; set; }
        public EquipmentItem? Equipment { get; set; }

        public DateTime CalibrationDate { get; set; }

        public string UserID { get; set; }
        public ApplicationUser? User { get; set; }

        public byte[] CalibrationCert { get; set; } // PDF Calibration Certificate

    }
}
