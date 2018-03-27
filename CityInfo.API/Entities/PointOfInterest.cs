using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //[MaxLength(250)]
        //public string Description { get; set; } // saving for migrations

        [ForeignKey("CityId")] // not necessary since we're following conventions
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
