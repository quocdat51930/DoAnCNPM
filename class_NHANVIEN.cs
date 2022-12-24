using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class class_NHANVIEN
    {
        MANE_GYMEntities db = new MANE_GYMEntities();
        public List<NHANVIEN> getList()
        {
            return db.NHANVIENs.ToList();
        }
        public NHANVIEN getItem(string maNV)
        {
            return db.NHANVIENs.FirstOrDefault(x => x.MANV.Equals(maNV));
        }
        public NHANVIEN Add(NHANVIEN nv)
        {
            try
            {
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public NHANVIEN Update(NHANVIEN nv)
        {
            try
            {
                var _nv = db.NHANVIENs.FirstOrDefault(x => x.MANV.Equals(nv.MANV));
                _nv.MANV = nv.MANV;
                _nv.TENNV = nv.TENNV;
                _nv.EMAIL = nv.EMAIL;
                _nv.CMND = nv.CMND;
                _nv.DIACHI = nv.DIACHI;
                _nv.NGAYSINH = nv.NGAYSINH;
                _nv.GIOITINH = nv.GIOITINH;
                _nv.LUONG = int.Parse(nv.LUONG.ToString());
                _nv.SDT = nv.SDT;
                _nv.ROLE = nv.ROLE;
                _nv.PASS = nv.PASS;
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string maNV)
        {
            try
            {
                var _nv = db.NHANVIENs.FirstOrDefault(x => x.MANV.Equals(maNV));
                db.NHANVIENs.Remove(_nv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }

        }
    }
}
