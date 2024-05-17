
using System.ComponentModel.DataAnnotations;
namespace LogansArchive.Models
{
    public class Show
    {
        public int showId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? firstDateAired { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? lastDateAired { get; set; }

        [Required]
        public int episodeCount { get; set; }
        [Required]
        public string Director { get; set; }

        //Collection Navigation Property
        public virtual ICollection<Show>? Shows { get; set; }
    }
}
