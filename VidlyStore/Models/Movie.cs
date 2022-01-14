using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }

        public int NumberInStock { get; set; }


    }
}