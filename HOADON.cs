//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADON
    {
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public string MANV { get; set; }
        public string MAPHONG { get; set; }
        public string MADV { get; set; }
        public Nullable<int> TIEN { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual PHONG PHONG { get; set; }
    }
}
