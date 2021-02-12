using StarTEDSystem.Data.KTran;
using StarTEDSystem.KTran.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.KTran.BLL
{
    public class ClubController
    {
        public List<Club> Club_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.Clubs.ToList();
            }
        }

        public Club Club_Find(int clubid)
        {
            using (var context = new StarTEDContext())
            {
                return context.Clubs.Find(clubid);
            }
        }
    }
}
