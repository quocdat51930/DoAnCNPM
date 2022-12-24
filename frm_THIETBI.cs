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
    public partial class frm_THIETBI : DevExpress.XtraEditors.XtraForm
    {
        public frm_THIETBI()
        {
            InitializeComponent();
        }
        class_THIETBI _thietbi;
        bool _them;
        string _MATB;
        private void frm_THIETBI_Load(object sender, EventArgs e)
        {
            _them = false;
            _thietbi = new class_THIETBI();
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
            txt_MATB.Enabled = !kt;
            splitContainer1.Panel1Collapsed = kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _thietbi.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
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
                _thietbi.Delete(_MATB);
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
        void SaveData()
        {

            if (_them)
            {
                THIETBI tb = new THIETBI();
                tb.MATB = txt_MATB.Text.Trim();
                tb.TENTB = txt_TENTB.Text.Trim();
                tb.SOLUONG = int.Parse(txt_SOLUONG.Text.Trim());
                _thietbi.Add(tb);
            }
            else
            {
                var tb = _thietbi.getItem(_MATB);
                tb.MATB = txt_MATB.Text.Trim();
                tb.TENTB = txt_TENTB.Text.Trim();
                tb.SOLUONG = int.Parse(txt_SOLUONG.Text.Trim());
                _thietbi.Update(tb);
            }
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _MATB = gvDanhSach.GetFocusedRowCellValue("MATB").ToString();
                var tb = _thietbi.getItem(_MATB);
                txt_MATB.Text = tb.MATB;
                txt_TENTB.Text = tb.TENTB;
                txt_SOLUONG.Text = tb.SOLUONG.ToString();
         
            }

        }
    }
}