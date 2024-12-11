using Microsoft.AspNetCore.Identity;

namespace ProjectCA.Models
{
    // Creating a database Model for the ApplicationUser, using IdentityUser
    public class ApplicationUser: IdentityUser
    {
        //Full Name of the User
        public string FullName { get; set; }
        // Technical proficiency Level
        public string? TechnicalLevel { get; set; }
        // Collection of EquipmentItems associated with the user
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();
        // Collection of CalibrationRecords associated with the user
        public ICollection<CalibrationRecord> CalibrationRecords { get; set; } = new List<CalibrationRecord>();
    }
}
