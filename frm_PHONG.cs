using System;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class frm_PHONG : DevExpress.XtraEditors.XtraForm
    {
        public frm_PHONG()
        {
            InitializeComponent();
        }
        class_PHONG _phong;
        bool _them;
        string _MAPHONG;
        private void frm_PHONG_Load(object sender, EventArgs e)
        {
            _them = false;
            _phong = new class_PHONG();
            _showHide(true);
            loadData();
        }
        void loadData()
        {
            gcDanhSach.DataSource = _phong.getList();
            gvDanhSach.OptionsBehavior.Editable = false;

        }


        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            txt_MAPHONG.Enabled = !kt;
            splitContainer1.Panel1Collapsed = kt;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txt_MAPHONG.Text = string.Empty;
            txt_TENPHONG.Text = string.Empty;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _phong.Delete(_MAPHONG);
                loadData();
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _showHide(true);
            _them = false;

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            _them = false;
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                PHONG p = new PHONG();
                p.MAPHONG = txt_MAPHONG.Text;
                p.TENPHONG = txt_TENPHONG.Text;
                p.GIA = int.Parse(txt_GIA.Text.Trim());
                _phong.Add(p);
            }
            else
            {
                var p = _phong.getItem(_MAPHONG);
                p.MAPHONG = txt_MAPHONG.Text;
                p.TENPHONG = txt_TENPHONG.Text;
                p.GIA = int.Parse(txt_GIA.Text.Trim());
                _phong.Update(p);

            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _MAPHONG = gvDanhSach.GetFocusedRowCellValue("MAPHONG").ToString();
                var p = _phong.getItem(_MAPHONG);
                txt_MAPHONG.Text = p.MAPHONG;
                txt_TENPHONG.Text = p.TENPHONG;
                txt_GIA.Text = p.GIA.ToString();
            }
        }
    }
}