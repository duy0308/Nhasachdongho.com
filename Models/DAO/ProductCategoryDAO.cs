using Models.EF;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class ProductCategoryDAO
    {
        DataContextModel db = null;
        public ProductCategoryDAO()
        {
            db = new DataContextModel();
        }
        public List<M1ProductCategory> ProductGroupMenu(bool Active, int Level)
        {
            return db.M1ProductCategory.Where(x => x.Status == Active & x.ShowOnHome == true & x.Level == Level).ToList();
        }
    }
}
