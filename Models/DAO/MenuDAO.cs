using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MenuDAO
    {
        DataContextModel db = null;
        public MenuDAO()
        {
            db = new DataContextModel();
        }
        public List<M1Menu> MenuByGroupID(int GroupID)
        {
            return db.M1Menu.Where(x => x.TypeID == GroupID & x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
