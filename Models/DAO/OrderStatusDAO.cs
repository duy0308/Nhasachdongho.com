using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderStatusDAO
    {
        DataContextModel db = null;
        public OrderStatusDAO()
        {
            db = new DataContextModel();
        }
        public List<M1OrderStatus> GetStatus()
        {
            return db.M1OrderStatus.OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
