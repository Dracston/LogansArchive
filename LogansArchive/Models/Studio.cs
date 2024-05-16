using System.ComponentModel.DataAnnotations;

namespace LogansArchive.Models
{
    public class Studio
    {

        public int studioId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateOnly yearEstablished { get; set; }

        [Required]
        
        public string Address { get; set; }

        //Collection Navigation Property
        public virtual ICollection<Studio>? Studios { get; set; }
    }
}
