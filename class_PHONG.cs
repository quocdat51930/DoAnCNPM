using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class class_PHONG
    {
        MANE_GYMEntities db = new MANE_GYMEntities();
        public List<PHONG> getList()
        {
            return db.PHONGs.ToList();
        }
        public PHONG getItem(string maPhong)
        {
            return db.PHONGs.FirstOrDefault(x => x.MAPHONG.Equals(maPhong));
        }
        public PHONG Add(PHONG p)
        {
            try
            {
                db.PHONGs.Add(p);
                db.SaveChanges();
                return p;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public PHONG Update(PHONG p)
        {
            try
            {
                var _p = db.PHONGs.FirstOrDefault(x => x.MAPHONG.Equals(p.MAPHONG));
                _p.MAPHONG = p.MAPHONG;
                _p.TENPHONG = p.TENPHONG;
                _p.GIA = int.Parse(p.GIA.ToString());
                db.SaveChanges();
                return p;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string maPhong)
        {
            try
            {
                var _p = db.PHONGs.FirstOrDefault(x => x.MAPHONG.Equals(maPhong));
                db.PHONGs.Remove(_p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }

        }

    }
}
