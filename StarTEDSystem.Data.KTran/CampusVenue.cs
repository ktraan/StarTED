using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.Data.KTran
{
    [Table("CampusVenues", Schema = "dbo")]
    public class CampusVenue
    {
        [Key]
        public int CampusVenueID { get; set; }  // int, not null
        public string Location   { get; set; }  // varchar(30), not null
    }
}
