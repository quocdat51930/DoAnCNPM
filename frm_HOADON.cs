using DevExpress.XtraEditors;
using DXApplication1.DTO;
using DXApplication1.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace DXApplication1
{
    public partial class frm_HOADON : DevExpress.XtraEditors.XtraForm
    {
        public frm_HOADON()
        {
            InitializeComponent();
        }
        class_HOADON _hoadon;
        class_KHACHHANG _khachhang;
        class_NHANVIEN _nhanvien;
        class_DICHVU _dichvu;
        class_PHONG _phong;
        List<HOADON_DTO> _lsHDDTO;
        bool _them;
        string _MAHD, _MADV, _MAPHONG;
        private void frm_HOADON_Load(object sender, EventArgs e)
        {
            _them = false;
            _hoadon = new class_HOADON();
            _khachhang = new class_KHACHHANG();
            _nhanvien = new class_NHANVIEN();
            _dichvu = new class_DICHVU();
            _phong = new class_PHONG();
            _showHide(true);
            loadData();
            loadCBO();
            txt_TIEN.Enabled = false;
            loadtxt_TIEN();
        }
        void loadtxt_TIEN()
        {
            var dv = _dichvu.getItem(cbo_MADV.SelectedValue.ToString());
            var phong = _phong.getItem(cbo_MAPHONG.SelectedValue.ToString());
            //hd.TIEN = int.Parse(txt_TIEN.Text.Trim());
            txt_TIEN.Text = (dv.GIA + phong.GIA).ToString();
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            txt_MAHD.Enabled = !kt;
            cbo_MANV.Enabled = !kt;
            cbo_MADV.Enabled = !kt;
            cbo_MAKH.Enabled = !kt;
            cbo_MAPHONG.Enabled = !kt;
            dtp_NGAY.Enabled = !kt;
            splitContainer1.Panel1Collapsed = kt;
        }

        private void gvDanhSach_click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _MAHD = gvDanhSach.GetFocusedRowCellValue("MAHD").ToString();
                var hd = _hoadon.getItem(_MAHD);
                txt_MAHD.Text = hd.MAHD;
                cbo_MAKH.SelectedValue = hd.MAKH;
                cbo_MANV.SelectedValue = hd.MANV;
                cbo_MAPHONG.SelectedValue = hd.MAPHONG;
                cbo_MADV.SelectedValue = hd.MADV;
                txt_TIEN.Text = hd.TIEN.ToString();
                dtp_NGAY.Value = hd.NGAY.Value;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            _reset();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _hoadon.Delete(_MAHD);
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
            _reset();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void loadData()
        {
            gcDanhSach.DataSource = _hoadon.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lsHDDTO = _hoadon.getListFull();
        }

        private void cbo_MADV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadtxt_TIEN();
        }

        private void cbo_MAPHONG_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadtxt_TIEN();
        }

        void SaveData()
        {
            if (_them)
            {
                HOADON hd = new HOADON();
                hd.MAHD = txt_MAHD.Text.Trim();
                hd.MAKH = cbo_MAKH.SelectedValue.ToString();
                hd.MANV = cbo_MANV.SelectedValue.ToString();
                hd.MADV = cbo_MADV.SelectedValue.ToString();
                var dv = _dichvu.getItem(hd.MADV);
                hd.MAPHONG = cbo_MAPHONG.SelectedValue.ToString();
                var phong = _phong.getItem(hd.MAPHONG);
                hd.NGAY = dtp_NGAY.Value;
                //hd.TIEN = int.Parse(txt_TIEN.Text.Trim());
                hd.TIEN = dv.GIA + phong.GIA;
                //_MAHD = gvDanhSach.GetFocusedRowCellValue("MAHD").ToString();
                //var hd = _hoadon.getItem(_MAHD);
                _hoadon.Add(hd);
            }
            else
            {
                var hd = _hoadon.getItem(_MAHD);
                hd.MAHD = txt_MAHD.Text.Trim();
                hd.MAKH = cbo_MAKH.SelectedValue.ToString();
                hd.MANV = cbo_MANV.SelectedValue.ToString();
                hd.MADV = cbo_MADV.SelectedValue.ToString();
                var dv = _dichvu.getItem(hd.MADV);
                hd.MAPHONG = cbo_MAPHONG.SelectedValue.ToString();
                var phong = _phong.getItem(hd.MAPHONG);
                hd.NGAY = dtp_NGAY.Value;
                //hd.TIEN = int.Parse(txt_TIEN.Text.Trim());
                hd.TIEN = dv.GIA + phong.GIA;
                //_MAHD = gvDanhSach.GetFocusedRowCellValue("MAHD").ToString();
                //var hd = _hoadon.getItem(_MAHD);
                _hoadon.Update(hd);
            }
            
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rp_HOADON _rp = new rp_HOADON(_lsHDDTO);
            _rp.ShowRibbonPreview();
        }

        void loadCBO()
        {
            cbo_MAKH.DataSource = _khachhang.getList();
            cbo_MAKH.DisplayMember = "TENKH";
            cbo_MAKH.ValueMember = "MAKH";

            cbo_MANV.DataSource = _nhanvien.getList();
            cbo_MANV.DisplayMember = "TENNV";
            cbo_MANV.ValueMember = "MANV";


            cbo_MAPHONG.DataSource = _phong.getList();
            cbo_MAPHONG.DisplayMember = "TENPHONG";
            cbo_MAPHONG.ValueMember = "MAPHONG";

            cbo_MADV.DataSource = _dichvu.getList();
            cbo_MADV.DisplayMember = "TENDV";
            cbo_MADV.ValueMember = "MADV";
        }
        void _reset()
        {
            txt_MAHD.Text = string.Empty;
            
        }
    }
}