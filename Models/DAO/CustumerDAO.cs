using Models.EF;
using System.Linq;
namespace Models.DAO
{

    public class CustumerDAO
    {
        DataContextModel db = null;
        public CustumerDAO()
        {
            db = new DataContextModel();
        }    
        public bool Login(string Username, string Password)
        {
            var kq = db.M1Custumers.Count(x => x.UserName == Username && x.Password == Password);
            if (kq > 0) return true;
            else return false;

        }
       
    }
}
