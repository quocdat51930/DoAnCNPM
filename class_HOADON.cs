using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXApplication1.DTO;
namespace DXApplication1
{
    class class_HOADON
    {
        MANE_GYMEntities db = new MANE_GYMEntities();
        public List<HOADON> getList()
        {
            return db.HOADONs.ToList();
        }
        
        public List<HOADON_DTO> getListFull()
        {
            var lsHD = db.HOADONs.ToList();
            List<HOADON_DTO> lsHDDTO = new List<HOADON_DTO>();
            HOADON_DTO hdDTO;
            foreach (var item in lsHD)
            {
                hdDTO = new HOADON_DTO();
                hdDTO.MAHD = item.MAHD;
                hdDTO.MAKH = item.MAKH;
                hdDTO.MANV = item.MANV;
                hdDTO.MAPHONG = item.MAPHONG;
                hdDTO.MADV = item.MADV;
                
                hdDTO.NGAY = item.NGAY;
                var _kh = db.KHACHHANGs.FirstOrDefault(x => x.MAKH.Equals(item.MAKH));
                hdDTO.TENKH = _kh.TENKH;

                var _nv = db.NHANVIENs.FirstOrDefault(x => x.MANV.Equals(item.MANV));
                hdDTO.TENNV = _nv.TENNV;

                var _phong = db.PHONGs.FirstOrDefault(x => x.MAPHONG.Equals(item.MAPHONG));
                hdDTO.TENPHONG = _phong.TENPHONG;
                hdDTO.GIAPHONG = _phong.GIA.ToString();
                var _dv = db.DICHVUs.FirstOrDefault(x => x.MADV.Equals(item.MADV));
                hdDTO.TENDV = _dv.TENDV;
                hdDTO.GIADV = _dv.GIA.ToString();
                hdDTO.TIEN = (_phong.GIA+_dv.GIA);
                lsHDDTO.Add(hdDTO);
            }
            return lsHDDTO;
        }
        public HOADON getItem(string maHOADON)
        {
            return db.HOADONs.FirstOrDefault(x => x.MAHD.Equals(maHOADON));
        }
        public HOADON Add(HOADON hd)
        {
            try
            {
                db.HOADONs.Add(hd);
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public HOADON Update(HOADON hd)
        {
            try
            {
                var _hd = db.HOADONs.FirstOrDefault(x => x.MAHD.Equals(hd.MAHD));
                _hd.MAHD = hd.MAHD;
                _hd.MAKH = hd.MAKH;
                _hd.MANV = hd.MANV;
                _hd.MAPHONG = hd.MAPHONG;
                _hd.MADV = hd.MADV;
                _hd.TIEN = hd.TIEN;
                _hd.NGAY = hd.NGAY;
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string maHOADON)
        {
            try
            {
                var _hd = db.HOADONs.FirstOrDefault(x => x.MAHD.Equals(maHOADON));
                db.HOADONs.Remove(_hd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }

        }
    }
}
