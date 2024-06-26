﻿
using System.ComponentModel.DataAnnotations;
namespace LogansArchive.Models
{
    public class Game
    {


        public int gameId { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Console { get; set; }

       

        //Collection Navigation Property
        public virtual ICollection<Connection> Connections { get; set; }

    }
}
