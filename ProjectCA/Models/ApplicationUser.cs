using Microsoft.AspNetCore.Identity;

namespace ProjectCA.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public string? TechnicalLevel { get; set; }
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();
        public ICollection<CalibrationRecord> CalibrationRecords { get; set; } = new List<CalibrationRecord>();
    }
}
