using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataLayer;

namespace DXApplication1.DTO
{
    public class HOADON_DTO
    {
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public string TENKH { get; set; }

        public string MANV { get; set; }
        public string TENNV { get; set; }

        public string MAPHONG { get; set; }
        public string TENPHONG { get; set; }
        public string GIAPHONG { get; set; }
        public string MADV { get; set; }
        public string TENDV { get; set; }
        public string GIADV { get; set; }
        public Nullable<int> TIEN { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }

        public virtual DICHVU DICHVU { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual PHONG PHONG { get; set; }
    }
}
