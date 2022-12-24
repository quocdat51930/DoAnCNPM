using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DXApplication1.Report;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frm_KHACHHANG : DevExpress.XtraEditors.XtraForm
    {
        public frm_KHACHHANG()
        {
            InitializeComponent();
        }
        class_KHACHHANG _khachhang;
        bool _them;
        string _MAKH;
        List<KHACHHANG> _lsKH;
        private void frm_KHACHHANG_Load(object sender, EventArgs e)
        {
            _them = false;
            _khachhang = new class_KHACHHANG();
            _showHide(true);
            loadData();

        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            txt_MAKH.Enabled = !kt;
            splitContainer1.Panel1Collapsed = kt;
        }
        private void gvDachSach_click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _MAKH = gvDanhSach.GetFocusedRowCellValue("MAKH").ToString();
                var kh = _khachhang.getItem(_MAKH);
                txt_MAKH.Text = kh.MAKH;
                txt_TENKH.Text = kh.TENKH;
                txt_EMAIL.Text = kh.EMAIL;
                txt_SDT.Text = kh.SDT;
            }

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _khachhang.Delete(_MAKH);
                loadData();
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
            XtraMessageBox.Show("Dữ liệu đã được lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void loadData()
        {
            gcDanhSach.DataSource = _khachhang.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lsKH = _khachhang.getList();
        }
        void SaveData()
        {
            if (_them)
            {
                KHACHHANG kh = new KHACHHANG();
                kh.MAKH = txt_MAKH.Text.Trim();
                kh.TENKH = txt_TENKH.Text.Trim();
                kh.EMAIL = txt_EMAIL.Text.Trim();
                kh.SDT = txt_SDT.Text.Trim();
                _khachhang.Add(kh);
            }
            else
            {
                var kh = _khachhang.getItem(_MAKH);
                kh.MAKH = txt_MAKH.Text.Trim();
                kh.TENKH = txt_TENKH.Text.Trim();
                kh.EMAIL = txt_EMAIL.Text.Trim();
                kh.SDT = txt_SDT.Text.Trim();
                _khachhang.Update(kh);
            }
        }

        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rp_KHACHHANG _rp = new rp_KHACHHANG(_lsKH);
            _rp.ShowRibbonPreview();
        }
    }
}