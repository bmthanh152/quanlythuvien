using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Nhom_HungTrietThanh
{

    public partial class frmQuanLySV : Form
    {
        public frmQuanLySV()
        {
            InitializeComponent();
        }
        private void FormQuanLySV_Load(object sender, EventArgs e)
        {
            loadData();
            btnLuu.Enabled = false;
            KhoaCN();
        }
        SqlCommand command = new SqlCommand();
        SqlConnection conn = null;
        string strConn = "server=DESKTOP-J45M7FE\\SQLEXPRESS; database=SinhVienBUH;integrated security=true";

        SqlDataAdapter da = null;
        DataTable data = null;

        //bool them;

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.ReadOnly = false;
            int i;
            i = dataGridView1.CurrentRow.Index;


            txtMaSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtHoSV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTenSv.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dtNgaySinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbGioiTinh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtMaKhoa.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }
        private void KhoaCN()
        {
            txtHoSV.Enabled = false;
            txtMaKhoa.Enabled = false;
            txtMaSV.Enabled = false;
            txtTenSv.Enabled = false;
            dtNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
        }
        private void MoCN()
        {
            txtHoSV.Enabled = true;
            txtMaKhoa.Enabled = true;
            txtMaSV.Enabled = true;
            txtTenSv.Enabled = true;
            dtNgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
        }
        public bool CheckData()

        {
            if(string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSv.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtNgaySinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgaySinh.Focus();
                return false;
            }
            if (dtNgaySinh.Value < DateTime.MinValue || dtNgaySinh.Value > DateTime.MaxValue)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgaySinh.Focus();
                return false;
            }           
            if (string.IsNullOrEmpty(cbGioiTinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGioiTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaKhoa.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Focus();
                return false;
            }
            return true;                  
        }
        void loadData()
        {
            try
            {
                conn = new SqlConnection(strConn);
                da = new SqlDataAdapter("Select * from SinhVien", conn);
                data = new DataTable();

                data.Clear();
                da.Fill(data);
                dataGridView1.DataSource = data;
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            MoCN();
            txtMaSV.ResetText();
            txtHoSV.ResetText();
            txtTenSv.ResetText();
            txtMaKhoa.ResetText();
            cbGioiTinh.ResetText();
            dtNgaySinh.ResetText();
            txtMaSV.Focus();         
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //them = true;
            string sql = "";
            {
                if (conn == null)
                    conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand command = new SqlCommand();
                
                if( CheckData())
                {
                    txtMaSV.Focus();
                    command.Connection = conn;

                    if (txtMaSV.Text == "")
                    {
                        MessageBox.Show("Bạn không để trống mã sinh viên!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Kiểm tra xem mã sinh viên đã tồn tại chưa đẻ tránh việc insert mới bị lỗi 
                        sql = "Select Count(*) From SinhVien Where MaSV ='" + txtMaSV.Text + "'";
                        //command = new SqlCommand(sql, conn);
                        command.CommandText = sql;
                        int val = (int)command.ExecuteScalar();
                        if (val > 0)
                        {
                            MessageBox.Show("Mã Sinh viên trùng trong cơ sở dữ liệu","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        else
                        {
                            //Insert vao CSDL
                            sql = "Insert into SinhVien(MaSV,HoSV,TenSV,NgaySinh,GioiTinh,MaKhoa)" +
                           "values(" + txtMaSV.Text + ",N'" + txtHoSV.Text + "',N'" + txtTenSv.Text + "','" + dtNgaySinh.Value.Date + "',N'" + cbGioiTinh.Text + "','" + txtMaKhoa.Text + "')";
                            command.CommandText = sql;
                        }

                        int ret = command.ExecuteNonQuery();
                        if (ret > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                            dataGridView1.DataSource = data;
                            KhoaCN();
                        }
                        else
                            MessageBox.Show("Thêm sinh viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                 
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {

            btnLuu.Enabled = true;
            btnChinhSua.Enabled = false;
            txtMaSV.ReadOnly = true;
            MoCN();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            string sql = "update SinhVien set HoSV=N'" + txtHoSV.Text + "',TenSV=N'" + txtTenSv.Text + "',NgaySinh='" + dtNgaySinh.Value.Date + "', GioiTinh= N'" + cbGioiTinh.Text + "', MaKhoa='" + txtMaKhoa.Text + "'where MaSV = " + txtMaSV.Text;
            command.CommandText = sql;
            command.Connection = conn;


            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Chỉnh sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                dataGridView1.DataSource = data;
                btnChinhSua.Enabled = true;
                btnLuu.Enabled = false;
                KhoaCN();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLuu.Enabled = false;
                btnChinhSua.Enabled = true;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {           
            {
                DialogResult Xoa = MessageBox.Show("Bạn muốn xóa SV ?", "Thông báo",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
                if (Xoa == DialogResult.Yes)
                {
                    if (conn == null)
                        conn = new SqlConnection(strConn);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.Connection = conn;

                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    string sql = "delete from SinhVien where MaSV=" + txtMaSV.Text;
                    command.CommandText = sql;

                    int ret = command.ExecuteNonQuery();
                    if (ret > 0)
                    {

                        MessageBox.Show("Xóa sinh viên thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        dataGridView1.DataSource = data;
                    }
                    else
                        MessageBox.Show("Xóa sinh viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }     

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult Huy = MessageBox.Show("Bạn muốn hủy ?", "Thông báo",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
            if (Huy == DialogResult.Yes)
            {
                txtMaSV.Text = "";
                txtHoSV.Text = "";
                txtTenSv.Text = "";
                dtNgaySinh.Text = "";
                cbGioiTinh.Text = "";
                txtMaKhoa.Text = "";
                txtMaSV.Focus();
                btnLuu.Enabled = false;
                //btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnChinhSua.Enabled = true;
                dataGridView1.Enabled = true;
                KhoaCN();
            }        
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát không?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                this.Close();
        }

        private void txtHoSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtTenSv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}

        
    




