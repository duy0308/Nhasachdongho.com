using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductPhotoDAO
    {
        DataContextModel db = null;
        public ProductPhotoDAO()
        {
            db = new DataContextModel();
        }
        public List<M1ProductPhoto> GetPhotoByID(int idProduct)
        {
            return db.M1ProductPhoto.Where(x => x.ProductID == idProduct).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
