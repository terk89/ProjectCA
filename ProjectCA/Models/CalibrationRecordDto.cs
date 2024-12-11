using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    // Data tranfer object representing calibration record
    public class CalibrationRecordDto
    {
        // calibration date
        public DateTime CalibrationDate { get; set; }

        // person performing calibration
        public string UserID { get; set; }

        // the uploaded calibration certificate file
        public IFormFile? CalibrationCert { get; set; } 
    }
}
