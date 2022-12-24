using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class class_THIETBI
    {
        MANE_GYMEntities db = new MANE_GYMEntities();
        public List<THIETBI> getList()
        {
            return db.THIETBIs.ToList();
        }
        public THIETBI getItem(string maTHIETBI)
        {
            return db.THIETBIs.FirstOrDefault(x => x.MATB.Equals(maTHIETBI));
        }
        public THIETBI Add(THIETBI tb)
        {
            try
            {
                db.THIETBIs.Add(tb);
                db.SaveChanges();
                return tb;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public THIETBI Update(THIETBI tb)
        {
            try
            {
                var _tb = db.THIETBIs.FirstOrDefault(x => x.MATB.Equals(tb.MATB));
                _tb.MATB = tb.MATB;
                _tb.TENTB = tb.TENTB;
                _tb.SOLUONG = int.Parse(tb.SOLUONG.ToString());
                db.SaveChanges();
                return tb;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string maTHIETBI)
        {
            try
            {
                var _tb = db.THIETBIs.FirstOrDefault(x => x.MATB.Equals(maTHIETBI));
                db.THIETBIs.Remove(_tb);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }

        }
    }
}
