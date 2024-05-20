using System.ComponentModel.DataAnnotations;

namespace LogansArchive.Models
{
    public class Studio
    {

        public int studioId { get; set; }

        
       

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? yearEstablished { get; set; }

        [Required]
        
        public string Address { get; set; }

        //Nullable Navigation Property
        public virtual ICollection<Connection> Connections { get; set; }
        
    }
}
