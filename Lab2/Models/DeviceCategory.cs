using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Device> Devices { get; set; }
            = new List<Device>();
    }
}