using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.Data.KTran
{
    [Table("ClubActivities", Schema = "dbo")]
    public class ClubActivity
    {
        [Key]
        public int ActivityID { get; set; }
        public string ClubID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Location { get; set; }
        public bool OffCampus { get; set; }
        public int CampusVenueID { get; set; }

    }
}
