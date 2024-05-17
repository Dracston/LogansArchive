using System.ComponentModel.DataAnnotations;

namespace LogansArchive.Models
{
    public class Director
    {
        public int directorId { get; set; }
        public int showId { get; set; }
        public int movieId { get; set; }

        [Required]
        public string Name { get; set; }
        
        
        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

       //Collection Navigation Property
       public virtual ICollection<Director>? Directors { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual Show? Show { get; set; }
    }
}
