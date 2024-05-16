﻿using System.ComponentModel.DataAnnotations;

namespace LogansArchive.Models
{
    public class Movie
    {
       
        public int movieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string MovieFormat { get; set; }

        [Required]
        public string Studio {  get; set; }


    }
}