
using System.ComponentModel.DataAnnotations;
namespace LogansArchive.Models
{
    public class Game
    {


        public int gameId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string ReleaseDate { get; set; }

        [Required]
        public string Console { get; set; }

        //Collection Navigation Property
        public virtual ICollection<Game>? Games { get; set; }

    }
}
