using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom_HungTrietThanh
{
    public partial class frmDNHT : Form
    {
        public frmDNHT()
        {
            InitializeComponent();
        }
        private void frmDNHT_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();    
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "MRTHO" && txtPassword.Text == "123")
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmHTQLDV.KhoaVaMo.chứcNăngToolStripMenuItem.Enabled = true;
                frmHTQLDV.KhoaVaMo.trợGiúpToolStripMenuItem.Enabled = true;
                this.Close();              
            }
            else
            {
                MessageBox.Show("Bạn vui lòng nhập lại", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát không?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                DialogResult ret = MessageBox.Show("Bạn có muốn thoát không?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                    this.Close();
                else
                {
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
