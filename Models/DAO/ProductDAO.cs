using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.SqlClient;

namespace Models.DAO
{
    public class ProductDAO
    {
        private DbSet<M1Product> db;

        public ProductDAO()
        {
            DataContextModel DbContext = new DataContextModel();
            db = DbContext.M1Product;
        }

        /// <summary>
        /// Lấy chỉ tiết 1 sản phẩm
        /// </summary>
        /// <param name="id">ID của sản phẩm</param>
        /// <returns>Sản phẩm có ID tương ứng. NULL nếu không tồn tại sản phẩm có mã ID</returns>
        public M1Product GetProductDetail(int id)
        {
            return db.Find(id);
        }

        /// <summary>
        /// Lấy danh sách sản phẩm để sử dụng trong action Product/ListView
        /// </summary>
        /// <param name="pageNumber">Dùng để lấy các bản ghi ở trang số pageNumber</param>
        /// <returns>Trả về danh sách sản phẩm ở trang số pageNumber</returns>
        public IPagedList<M1Product> GetLstNewProduct(int pageNumber, int pageSize = 30)
        {
            //return db.Where(m => m.Status == true && m.Showhome == true).OrderByDescending(p => p.CreatedDate).Take(120).ToPagedList(pageNumber, pageSize);
            return db.SqlQuery("sp_GetLstNewProduct").ToPagedList(pageNumber, pageSize);
        }

        /// <summary>
        /// Lấy tất cả danh sách sản phẩm (có phân trang)
        /// </summary>
        /// <param name="pageNumber">Dùng để lấy các bản ghi ở trang số pageNumber</param>
        /// <param name="pageSize">Một trang có pageSize bản ghi</param>
        /// <returns></returns>
        public IPagedList<M1Product> GetAllProduct(int pageNumber, int pageSize = 30)
        {
            //return db.OrderByDescending(p => p.ModifiedDate).ToPagedList(pageNumber, pageSize);
            return db.SqlQuery("sp_GetAllProduct").ToPagedList(pageNumber, pageSize);
        }

        /// <summary>
        /// Lấy sản phẩm theo GroupID
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IPagedList<M1Product> GetProductByGroupID(int pGroupID,int pPageNumber, int pPageSize = 30)
        {
            //================================================
            //var result = db.SqlQuery("sp_GetAllMatHangbyMHLDefault @id", pGroupID).ToPagedList(pPageNumber, pPageSize);
            //var result = db.SqlQuery("sp_GetAllMatHangbyMHLDefault @id", new SqlParameter("id", pGroupID)).ToPagedList(pPageNumber, pPageSize);
            //var result = db.SqlQuery("sp_GetAllMatHangbyMHLDefault", new SqlParameter("id", pGroupID)).ToPagedList(pPageNumber, pPageSize);
            //===Không hiểu vì sao EF bị lỗi, không nhận tham số truyển vào
            var result = db.SqlQuery("sp_GetAllMatHangbyMHLDefault " + pGroupID.ToString()).ToPagedList(pPageNumber, pPageSize);
            return result;
        }
    }
}
