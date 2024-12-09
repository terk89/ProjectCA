using System.ComponentModel.DataAnnotations;

namespace ProjectCA.Models
{
    public class CalibrationRecordDto
    {
        public DateTime CalibrationDate { get; set; }
        public string UserID { get; set; }
        public IFormFile? CalibrationCert { get; set; } // To handle the file upload
    }
}
