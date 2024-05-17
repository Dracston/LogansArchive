
using System.ComponentModel.DataAnnotations;
namespace LogansArchive.Models
{
    public class Show
    {
        public int showId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? firstDateAired { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? lastDateAired { get; set; }

        [Required]
        public int episodeCount { get; set; }
        [Required]
        public string Director { get; set; }

        //Collection Navigation Property
        
    }
}
