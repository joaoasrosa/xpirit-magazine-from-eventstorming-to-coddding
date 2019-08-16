using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnemicDomain
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required] 
        [MaxLength(500)]
        public string Name { get; set; }

        [Required] 
        public List<string> Rows { get; set; }

        [Required] 
        public int NumberOfSeatsPerRow { get; set; }

        //  RowName plus List of seats
        [Required] 
        public Dictionary<int, List<Seat>> Seats { get; set; }
    }
}