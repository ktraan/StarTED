using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTEDSystem.Data.KTran;


namespace StarTEDSystem.KTran.DAL
{
    internal class StarTEDContext : DbContext
    {
        #region Constructors
        public StarTEDContext() : base("name=StarTEDDb")
        {
            Database.SetInitializer<StarTEDContext>(null);
        }
        #endregion

        #region Properties
        public DbSet<CampusVenue> CampusVenues { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubActivity> ClubActivities { get; set; }
        #endregion

    }
}
