using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Device name is required.")]
        [StringLength(100)]
        [Display(Name = "Device Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Device code is required.")]
        [StringLength(50)]
        [Display(Name = "Device Code")]
        public string Code { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(DeviceStatus))]
        [Display(Name = "Device Status")]
        public DeviceStatus Status { get; set; } = DeviceStatus.InUse;

        [DataType(DataType.Date)]
        [Display(Name = "Date of Entry")]
        public DateTime DateOfEntry { get; set; } = DateTime.Today;

        [Display(Name = "Device Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public DeviceCategory? Category { get; set; }
    }
}