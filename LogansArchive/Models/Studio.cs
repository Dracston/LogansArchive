using System.ComponentModel.DataAnnotations;

namespace LogansArchive.Models
{
    public class Studio
    {

        public int studioId { get; set; }

        public int gameId { get; set; }
       

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateOnly yearEstablished { get; set; }

        [Required]
        
        public string Address { get; set; }

        //Nullable Navigation Property
        public virtual Game? Games { get; set; }
        
    }
}
