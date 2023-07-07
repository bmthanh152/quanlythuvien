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
    public partial class frmHTQLDV : Form
    {
        public static frmHTQLDV KhoaVaMo;
        private void frmHTQLDV_Load(object sender, EventArgs e)
        {
           chứcNăngToolStripMenuItem.Enabled = false;
           trợGiúpToolStripMenuItem.Enabled = false;
        }
        public frmHTQLDV()
        {
            InitializeComponent();          
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDNHT = new frmDNHT();
            frmDNHT.Show();           
            chứcNăngToolStripMenuItem.Enabled = false;
            trợGiúpToolStripMenuItem.Enabled = false; ;
            KhoaVaMo = this;
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmThongTin = new frmThongTin();
            frmThongTin.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát không?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                this.Close();
        }

        private void quảnLýBánSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmQLS = new frmQLS();
            frmQLS.Show();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmQuanLySV = new frmQuanLySV();
            frmQuanLySV.Show();
        }
       
    }
}
