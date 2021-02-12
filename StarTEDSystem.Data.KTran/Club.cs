using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.Data.KTran
{
    [Table("Clubs", Schema = "dbo")]
    public class Club
    {
        [Key]
        public string ClubID { get; set; }
        public string ClubName { get; set; }
        public bool Active { get; set; }
        public int? EmployeeID { get; set; }
        public decimal Fee { get; set; }

    }
}
