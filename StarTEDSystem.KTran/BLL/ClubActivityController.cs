using StarTEDSystem.Data.KTran;
using StarTEDSystem.KTran.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTEDSystem.KTran.BLL
{   [DataObject]
    public class ClubActivityController
    {
        
        public List<ClubActivity> List_ClubActivity()
        {
            using (var context = new StarTEDContext())
            {
                return context.ClubActivities.ToList();
            }
        }

        public ClubActivity GetClubActivity(int id)
        {
            using (var context = new StarTEDContext())
            {
                return context.ClubActivities.Find(id);
            }
        }

        #region CRUD
        public int AddClubActivity(ClubActivity item)
        {
            using (var context = new StarTEDContext())
            {
                ClubActivity addeditem = context.ClubActivities.Add(item);
                context.SaveChanges();
                return addeditem.ActivityID;
            }
        }

        public void UpdateClubActivity(ClubActivity item)
        {
            using (var context = new StarTEDContext())
            {
                var exisiting = context.Entry(item);
                exisiting.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteClubActivity(int id)
        {
            using (var context = new StarTEDContext())
            {
                var exisiting = context.ClubActivities.Find(id);
                context.ClubActivities.Remove(exisiting);
                context.SaveChanges();
            }
        }
        #endregion


        public List<ClubActivity> GetClubActivityByDate(string searchid)
        {
            throw new NotImplementedException();
        }


        public List<ClubActivity> Find_ClubActivityClubDate(string clubid, DateTime startdate)
        {
            using (var context = new StarTEDContext())
            {
                string sql = "EXEC ClubActivities_FindByClubAndDate @p0, @p1";
                var result = context.Database.SqlQuery<ClubActivity>(sql, clubid, startdate);
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ClubActivity> Find_ClubActivityClub(string clubid)
        {
            using (var context = new StarTEDContext())
            {
                string sql = "EXEC ClubActivities_FindByClub @p0";
                var result = context.Database.SqlQuery<ClubActivity>(sql, clubid);
                var finalresult = result.ToList();
                return finalresult;
            }
        }
    }
}
