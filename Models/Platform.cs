using System;
namespace PlatformService.Models
{
    
    public class Platform
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}