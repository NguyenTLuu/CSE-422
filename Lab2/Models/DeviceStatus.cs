using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public enum DeviceStatus
    {
        [Display(Name = "In use")]
        InUse = 1,

        [Display(Name = "Broken")]
        Broken = 2,

        [Display(Name = "Under maintenance")]
        UnderMaintenance = 3
    }
}