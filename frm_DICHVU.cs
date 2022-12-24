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
    public partial class frm_DICHVU : DevExpress.XtraEditors.XtraForm
    {
        public frm_DICHVU()
        {
            InitializeComponent();
        }
        class_DICHVU _dichvu;
        bool _them;
        string _MADV;
        private void frm_DICHVU_Load(object sender, EventArgs e)
        {
            _them = false;
            _dichvu = new class_DICHVU();
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
            txt_MADV.Enabled = !kt;
            txt_TENDV.Enabled = !kt;
            txt_GIA.Enabled = !kt;
            splitContainer1.Panel1Collapsed = kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _dichvu.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void gvDanhSach_click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _MADV = gvDanhSach.GetFocusedRowCellValue("MADV").ToString();
                var dv = _dichvu.getItem(_MADV);
                txt_MADV.Text = dv.MADV;
                txt_TENDV.Text = dv.TENDV;
                txt_GIA.Text = dv.GIA.ToString();

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
                _dichvu.Delete(_MADV);
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
                DICHVU dv = new DICHVU();
                dv.MADV = txt_MADV.Text.Trim();
                dv.TENDV = txt_TENDV.Text.Trim();
                dv.GIA = int.Parse(txt_GIA.Text.Trim());
                _dichvu.Add(dv);
            }
            else
            {
                var dv = _dichvu.getItem(_MADV);
                dv.MADV = txt_MADV.Text.Trim();
                dv.TENDV = txt_TENDV.Text.Trim();
                dv.GIA = int.Parse(txt_GIA.Text.Trim());
                _dichvu.Update(dv);
            }
        }
    }
}