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
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public frm_Login()
        {
            InitializeComponent();
            // Set to no text.
            txtPass.Text = "";
            // The password character is an asterisk.
            txtPass.PasswordChar = '•';
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập !!", "Thông báo");
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Vui lòng điền mật khẩu!!", "Thông báo");
            }
            else if (txtUser.Text == "a" && txtPass.Text == "1")
            {
                this.Hide();
                Main frm2 = new Main();
                frm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!!!", "Thông báo");
            }
        }
    }
}