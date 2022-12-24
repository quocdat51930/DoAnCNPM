using System.Collections.Generic;

namespace DXApplication1.Report
{
    public partial class rp_KHACHHANG : DevExpress.XtraReports.UI.XtraReport
    {

        public rp_KHACHHANG()
        {
            InitializeComponent();
        }
        List<KHACHHANG> _ls_KH;

        public rp_KHACHHANG(List<KHACHHANG> lsKH)
        {
            InitializeComponent();
            this._ls_KH = lsKH;
            this.DataSource = _ls_KH;
            loadData();
        }
        void loadData()
        {
            lb_MAKH.DataBindings.Add("Text", _ls_KH, "MAKH");
            lb_TENKH.DataBindings.Add("Text", _ls_KH, "TENKH");
            lb_SDT.DataBindings.Add("Text", _ls_KH, "SDT");
            lb_EMAIL.DataBindings.Add("Text", _ls_KH, "EMAIL");
        }

    }
}
