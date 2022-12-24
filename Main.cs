using DevExpress.XtraBars;
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
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
        }
        void openForm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frm_NHANVIEN));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frm_PHONG));
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frm_KHACHHANG));
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frm_THIETBI));
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frm_HOADON));
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frm_DICHVU));

        }


    }
}