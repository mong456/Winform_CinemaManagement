using FinalCProject.DTH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCProject.Management
{
    public partial class frmqlphongchieu : Form
    {
        public frmqlphongchieu()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadData()//Load dữ liệu lên datagird view
        {
            string query = "select *from room ";
            dgqlphongchieu.DataSource = DataProvider.Instance.ExcuteQuery(query);
            dgqlphongchieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void frmqlphongchieu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            LoadData();

        }

        private string selectedFunction = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            selectedFunction = comboBox1.SelectedItem?.ToString();

            // Đặt mặc định cho các TextBox
            txtid.Enabled = false;
            txtmarap.Enabled = false;
            txtsochongoi.Enabled = false;

            // Cập nhật trạng thái của các TextBox theo chức năng được chọn
            switch (selectedFunction)
            {
                case "Thêm":
                    txtid.Enabled = true;
                    txtmarap.Enabled = true;
                    txtsochongoi.Enabled = true;
                    break;

                case "Sửa":
                    txtid.Enabled = true;
                    txtmarap.Enabled = true;
                    txtsochongoi.Enabled = true;
                    break;

                case "Xóa":
                    txtid.Enabled = true;
                    break;

                case "Tìm kiếm":
                    txtid.Enabled = true;
                    txtmarap.Enabled = true;
                    txtsochongoi.Enabled = true;
                    break;
            }
        }

        private void btnthuchien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFunction))
            {
                MessageBox.Show("Vui lòng chọn chức năng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thực hiện chức năng dựa trên giá trị được chọn
                switch (selectedFunction)
                {
                    case "Thêm":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC Insertroom '{txtid.Text}', '{txtmarap.Text}', '{txtsochongoi.Text}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Sửa":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC updateroom '{txtid.Text}', '{txtmarap.Text}', '{txtsochongoi.Text}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi sửa phòng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Xóa":
                        // Hiển thị hộp thoại xác nhận trước khi xóa
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                DataProvider.Instance.ExcuteQuery($"EXEC delete_room {txtid.Text}");
                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;

                    case "Tìm kiếm":
                        try
                        {
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tìm kiếm phòng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        MessageBox.Show("Chức năng không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgqlphongchieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được nhấn
                DataGridViewRow row = dgqlphongchieu.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ các cột dựa trên chỉ số cột vào các TextBox
                txtid.Text = row.Cells[0].Value?.ToString();         // Cột đầu tiên
                txtmarap.Text = row.Cells[1].Value?.ToString();      // Cột thứ hai
                txtsochongoi.Text = row.Cells[2].Value?.ToString();  // Cột thứ ba
            }
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtmarap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgqlphongchieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
