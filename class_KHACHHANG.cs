using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class class_KHACHHANG
    {
        MANE_GYMEntities db = new MANE_GYMEntities();
        public List<KHACHHANG> getList()
        {
            return db.KHACHHANGs.ToList();
        }
        public KHACHHANG getItem(string maKHACHHANG)
        {
            return db.KHACHHANGs.FirstOrDefault(x => x.MAKH.Equals(maKHACHHANG));
        }
        public KHACHHANG Add(KHACHHANG kh)
        {
            try
            {
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                return kh;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public KHACHHANG Update(KHACHHANG kh)
        {
            try
            {
                var _kh = db.KHACHHANGs.FirstOrDefault(x => x.MAKH.Equals(kh.MAKH));
                _kh.MAKH = kh.MAKH;
                _kh.TENKH = kh.TENKH;
                _kh.EMAIL= kh.EMAIL;
                _kh.SDT = kh.SDT;
                db.SaveChanges();
                return kh;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string maKHACHHANG)
        {
            try
            {
                var _kh = db.KHACHHANGs.FirstOrDefault(x => x.MAKH.Equals(maKHACHHANG));
                db.KHACHHANGs.Remove(_kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }

        }
    }
}
