
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places.Models
{

    public class Place
    {

        public uint PlaceID { get; set; }

        [Required, MaxLength(50), Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required, Column(TypeName = "decimal(14,5)")]
        public decimal Latitude { get; set; }

        [Required, Column(TypeName = "decimal(15,5)")]
        public decimal Longitude { get; set; }
    }

}