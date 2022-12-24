using DevExpress.XtraReports.UI;
using DXApplication1.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace DXApplication1.Report
{
    public partial class rp_HOADON : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_HOADON()
        {
            InitializeComponent();
        }
        List<HOADON_DTO> _ls_HDDTO;

        public rp_HOADON(List<HOADON_DTO> lsHDDTO)
        {
            InitializeComponent();
            this._ls_HDDTO = lsHDDTO;
            this.DataSource = _ls_HDDTO;
            loadData();
        }
        void loadData()
        {
            lbMAHD.DataBindings.Add("Text", _ls_HDDTO, "MAHD");
            lbTENNV.DataBindings.Add("Text", _ls_HDDTO, "TENNV");
            lbTENKH.DataBindings.Add("Text", _ls_HDDTO, "TENKH");
            lbTENDV.DataBindings.Add("Text", _ls_HDDTO, "TENDV");
            lbTENPHONG.DataBindings.Add("Text", _ls_HDDTO, "TENPHONG");
            lbNGAY.DataBindings.Add("Text", _ls_HDDTO, "NGAY");
            lbTIEN.DataBindings.Add("Text", _ls_HDDTO, "TIEN");
        }
    }
}
