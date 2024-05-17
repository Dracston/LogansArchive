using System.ComponentModel.DataAnnotations;

namespace LogansArchive.Models
{
    public class Director
    {
        public int directorId { get; set; }
       
      

        [Required]
        public string Name { get; set; }
        
        
        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

       //Nullable Navigation Property
      
       
    }
}
