using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductGetDAO
    {
        DataContextModel db = null;
        public ProductGetDAO()
        {
            db = new DataContextModel();
        }
        public List<M1Product> GetByGroupID(int GroupID)
        {
            var clientIdParameter = new SqlParameter("@id", GroupID);
            var sanpham = db.Database.SqlQuery<M1Product>("sp_GetAllMatHangbyMHLDefault @id",
            new SqlParameter("@id", GroupID)).Take(12).ToList();
            return sanpham;
        }
    }
}
