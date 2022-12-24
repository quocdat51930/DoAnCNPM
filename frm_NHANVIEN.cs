using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frm_NHANVIEN : DevExpress.XtraEditors.XtraForm
    {
        public frm_NHANVIEN()
        {
            InitializeComponent();
        }
        class_NHANVIEN _nhanvien;
        bool _them;
        string _MANV;
        string checkGT = "";
        private void Form_NhanSu_Load(object sender, EventArgs e)
        {
            _them = false;
            _nhanvien = new class_NHANVIEN();
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
            txt_MANV.Enabled = !kt;
            splitContainer1.Panel1Collapsed = kt;
        }
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;

        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhanvien.Delete(_MANV);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }
        void loadData()
        {
           gcDanhSach.DataSource = _nhanvien.getList();
           gvDanhSach.OptionsBehavior.Editable = false;
        }
        void SaveData()
        {
            if (rb_GIOITINH.Checked)
            { checkGT = "Nam"; }
            else checkGT = "Nu";
            if (_them)
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = txt_MANV.Text.Trim();
                nv.TENNV = txt_TENNV.Text.Trim();
                nv.EMAIL = txt_EMAIL.Text.Trim();
                nv.CMND = txt_CMND.Text.Trim();
                nv.DIACHI = txt_DIACHI.Text.Trim();
                nv.NGAYSINH = dtp_NGAYSINH.Value;
                nv.GIOITINH =checkGT;
                nv.LUONG = int.Parse(txt_LUONG.Text.Trim());
                nv.SDT = txt_SDT.Text.Trim();
                nv.ROLE = cb_ROLE.Text.Trim();
                nv.PASS = txt_PASS.Text.Trim();
                _nhanvien.Add(nv);
            }
            else
            {
                var nv = _nhanvien.getItem(_MANV);
                nv.MANV = txt_MANV.Text.Trim();
                nv.TENNV = txt_TENNV.Text.Trim();
                nv.EMAIL = txt_EMAIL.Text.Trim();
                nv.CMND = txt_CMND.Text.Trim();
                nv.DIACHI = txt_DIACHI.Text.Trim();
                nv.NGAYSINH = dtp_NGAYSINH.Value;
                nv.GIOITINH = checkGT;
                nv.LUONG = int.Parse(txt_LUONG.Text.Trim());
                nv.SDT = txt_SDT.Text.Trim();
                nv.ROLE = cb_ROLE.Text.Trim();
                nv.PASS = txt_PASS.Text.Trim();
                _nhanvien.Update(nv);
            }
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _MANV = gvDanhSach.GetFocusedRowCellValue("MANV").ToString();
                var nv = _nhanvien.getItem(_MANV);
                txt_MANV.Text = nv.MANV;
                txt_TENNV.Text = nv.TENNV;
                txt_EMAIL.Text = nv.EMAIL;
                txt_CMND.Text = nv.CMND;
                txt_DIACHI.Text = nv.DIACHI;
                dtp_NGAYSINH.Value = nv.NGAYSINH.Value;
                if (nv.GIOITINH.Equals("Nam"))
                { rb_GIOITINH.Checked = true; }
                else rb_GIOITINH.Checked = false;
                txt_LUONG.Text = nv.LUONG.ToString();
                txt_SDT.Text = nv.SDT;
                cb_ROLE.Text = nv.ROLE;
                txt_PASS.Text = nv.PASS;
            }

        }

        
    }
}