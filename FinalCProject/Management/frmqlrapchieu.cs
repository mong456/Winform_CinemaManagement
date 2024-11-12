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
    public partial class frmqlrapchieu : Form
    {
        public frmqlrapchieu()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmqlrapchieu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            LoadData();
        }
        public void LoadData()//Load dữ liệu lên datagird view
        {
            string query = "select *from theater ";
            dgquanlirap.DataSource = DataProvider.Instance.ExcuteQuery(query);
            dgquanlirap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                                $"EXEC InsertTheater '{txtid.Text}', '{txttenrap.Text}', '{txtsophong.Text}','{txtkhuvuc.Text}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thêm rạp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Sửa":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC updatetheater '{txtid.Text}', '{txttenrap.Text}', '{txtsophong.Text}','{txtkhuvuc.Text}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi sửa rạp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Xóa":
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa rạp này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                DataProvider.Instance.ExcuteQuery($"EXEC deletetheater {txtid.Text}");
                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xóa rạp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Lỗi khi tìm kiếm rạp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        MessageBox.Show("Chức năng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string selectedFunction = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            selectedFunction = comboBox1.SelectedItem?.ToString();

            // Đặt mặc định cho các TextBox
            txtid.Enabled = false;
            txttenrap.Enabled = false;
            txtsophong.Enabled = false;
            txtkhuvuc.Enabled = false;

            // Cập nhật trạng thái của các TextBox dựa trên chức năng được chọn
            switch (selectedFunction)
            {
                case "Thêm":
                    txtid.Enabled = true;
                    txttenrap.Enabled = true;
                    txtsophong.Enabled = true;
                    txtkhuvuc.Enabled = true;
                    break;

                case "Sửa":
                    txtid.Enabled = true;
                    txttenrap.Enabled = true;
                    txtsophong.Enabled = true;
                    txtkhuvuc.Enabled = true;
                    break;

                case "Xóa":
                    txtid.Enabled = true;
                    break;

                case "Tìm kiếm":
                    txtid.Enabled = true;
                    txttenrap.Enabled = true;
                    txtsophong.Enabled = true;
                    txtkhuvuc.Enabled = true;
                    break;
            }
        }

        private void dgquanlirap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgquanlirap.Rows[e.RowIndex];

                // Lấy giá trị từ các ô và hiển thị vào TextBox
                txtid.Text = row.Cells[0].Value?.ToString();
                txttenrap.Text = row.Cells[1].Value?.ToString();
                txtsophong.Text = row.Cells[3].Value?.ToString();
                txtkhuvuc.Text = row.Cells[2].Value?.ToString();

                // Cập nhật trạng thái TextBox dựa trên chức năng đã chọn
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
