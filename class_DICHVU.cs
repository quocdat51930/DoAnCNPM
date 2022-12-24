using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class class_DICHVU
    {
        MANE_GYMEntities db = new MANE_GYMEntities();
        public List<DICHVU> getList()
        {
            return db.DICHVUs.ToList();
        }
        public DICHVU getItem(string maDICHVU)
        {
            return db.DICHVUs.FirstOrDefault(x => x.MADV.Equals(maDICHVU));
        }
        public DICHVU Add(DICHVU dv)
        {
            try
            {
                db.DICHVUs.Add(dv);
                db.SaveChanges();
                return dv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public DICHVU Update(DICHVU dv)
        {
            try
            {
                var _dv = db.DICHVUs.FirstOrDefault(x => x.MADV.Equals(dv.MADV));
                _dv.MADV = dv.MADV;
                _dv.TENDV = dv.TENDV;
                _dv.GIA = int.Parse(dv.GIA.ToString());
                db.SaveChanges();
                return dv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string maDICHVU)
        {
            try
            {
                var _dv = db.DICHVUs.FirstOrDefault(x => x.MADV.Equals(maDICHVU));
                db.DICHVUs.Remove(_dv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }

        }
    }
}
