using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FPTExam.Models
{
    public class ArtistModel
    {
        public int ArtistID { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public string AlbumName { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public double Price { get; set; }
        public string SampleUrl { get; set; }

    }
}
