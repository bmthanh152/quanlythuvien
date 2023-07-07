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
    public partial class frmQLS : Form
    {
        public frmQLS()
        {
            InitializeComponent();
        }
        ThongKeKH DS = new ThongKeKH();
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            KhachHang KH = new KhachHang();
            KH.TenKH = txtTenKH.Text;
            
            KH.LaSV = chkLaSV.Checked;
            if (txtTenKH.Text == "")
            {
                lblThanhTien.Text = null;
                txtTenKH.Text = "";
                txtSLSach.Text = "";
                MessageBox.Show("Bạn vui lòng nhập lại, tên khách hàng không được trống!", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();                               
            }             
            else
                KH.SLSach = int.Parse(txtSLSach.Text);
            { 
                if (KH.TenKH != null && KH.TenKH != "")
                {
                    DS.KHMua(KH);
                    lblThanhTien.Text = KH.TinhTien + " Đồng";
                }                              
            }           
        }
            
        private void btnTiep_Click(object sender, EventArgs e)
        {
            txtTenKH.Clear();
            txtTenKH.Clear();
            txtSLSach.Clear();
            chkLaSV.Checked = false;
            lblThanhTien.Text = "";
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {           
                txtTongKH.Text = DS.TongSoKH + " Người";
                txtTongSV.Text = DS.TongSoSV + " SV";
                txtTongDT.Text = DS.TongDT + " Đồng";                                                              
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát không?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                this.Close();
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && 
                !char.IsDigit(e.KeyChar) && e.KeyChar 
                != (char)Keys.Back && e.KeyChar 
                != (char)Keys.Space;
        }

        private void txtSLSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
        private void frmQLS_Load(object sender, EventArgs e)
        {
            btnTinhTien.Enabled = false;
        }

        private void txtSLSach_TextChanged(object sender, EventArgs e)
        {
            if (txtSLSach.Text == "")
            {
                btnTinhTien.Enabled = false;
                lblThanhTien.Text = "0";
            }
            else
                btnTinhTien.Enabled = true;
            txtSLSach.Focus();
        }      
    }
}
