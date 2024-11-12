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
    public partial class frmshow : Form
    {
        public frmshow()
        {
            InitializeComponent();
        }

        private void frmshow_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            LoadData();
        }
        public void LoadData()//Load dữ liệu lên datagird view
        {
            string query = "select *from show";
            dgqlshow.DataSource = DataProvider.Instance.ExcuteQuery(query);
            dgqlshow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgqlshow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgqlshow.Rows[e.RowIndex];

                txtmashow.Text = row.Cells[0].Value?.ToString();
                txtmaphim.Text = row.Cells[1].Value?.ToString();
                txtmaphong.Text = row.Cells[2].Value?.ToString();
                txtgia.Text = row.Cells[3].Value?.ToString();

                // Tách ngày và giờ từ ShowTime (cell 4)
                if (row.Cells[4].Value != null)
                {
                    string showTimeStr = row.Cells[4].Value.ToString();
                    if (DateTime.TryParse(showTimeStr, out DateTime dateTime))
                    {
                        // Tách riêng ngày và giờ
                        txtngay.Text = dateTime.ToString("dd/MM/yyyy");
                        txtgio.Text = dateTime.ToString("HH:mm");
                    }
                    else
                    {
                        // Nếu parse thất bại, hiển thị nguyên chuỗi gốc
                        txtngay.Text = showTimeStr;
                        txtgio.Text = "";
                    }
                }
                else
                {
                    txtngay.Text = "";
                    txtgio.Text = "";
                }

                txtsoghe.Text = row.Cells[5].Value?.ToString();
            }
        }

        private void btnthuchien_Click(object sender, EventArgs e)
        {            

            if (string.IsNullOrEmpty(selectedFunction))
            {
                MessageBox.Show("Vui lòng chọn chức năng!");
                return;
            }

            // Thực hiện chức năng dựa trên giá trị được chọn
            try
            {
                switch (selectedFunction)
                {
                    case "Thêm":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC Add_show '{txtmaphim.Text}', '{txtmaphong.Text}', '{txtgia.Text}', '{txtngay.Text}', '{txtgio.Text}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thêm show: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Sửa":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC update_show '{txtmashow.Text}','{txtmaphim.Text}', '{txtmaphong.Text}', '{txtgia.Text}', '{txtngay.Text}', '{txtgio.Text}','{int.Parse(txtsoghe.Text)}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi sửa show: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Xóa":
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa show này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                DataProvider.Instance.ExcuteQuery($"EXEC delete_show {txtmashow.Text}");
                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xóa show: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Lỗi khi tìm kiếm show: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ClearFields()
        {
            txtmashow.Text = "";
            txtmaphim.Text = "";
            txtmaphong.Text = "";
            txtgia.Text = "";
            txtgio.Text = " ";
            txtngay.Text = "";
            txtsoghe.Text = "";
          
        }
       
        private string selectedFunction ="";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFunction = comboBox1.Text;

            switch (selectedFunction)
            {
                case "Thêm":
                    ClearFields();
                    // Khóa các TextBox không cần thiết
                    txtmashow.Enabled = false;
                    txtsoghe.Enabled = false;

                    // Mở khóa các TextBox cần nhập
                    txtmaphim.Enabled = true;
                    txtmaphong.Enabled = true;
                    txtgia.Enabled = true;
                    txtngay.Enabled = true;
                    txtgio.Enabled = true;

                    
                    break;

                case "Sửa":
                    // Mở khóa các trường có thể sửa
                    txtmashow.Enabled = false;
                    txtmaphim.Enabled = true;
                    txtmaphong.Enabled = true;
                    txtgia.Enabled = true;
                    txtngay.Enabled = true;
                    txtgio.Enabled = true;
                    txtsoghe.Enabled = true;
                    break;

                case "Xóa":
                    // Chỉ cho phép xem thông tin, không cho sửa
                    txtmashow.Enabled = true;
                    txtmaphim.Enabled = false;
                    txtmaphong.Enabled = false;
                    txtgia.Enabled = false;
                    txtngay.Enabled = false;
                    txtgio.Enabled = false;
                    txtsoghe.Enabled = false;
                    break;

                case "Tìm kiếm":
                    // Mở tất cả các trường để tìm kiếm
                    txtmashow.Enabled = true;
                    txtmaphim.Enabled = true;
                    txtmaphong.Enabled = true;
                    txtgia.Enabled = true;
                    txtngay.Enabled = true;
                    txtgio.Enabled = true;
                    txtsoghe.Enabled = true;
                    break;

                default:
                    // Khóa tất cả TextBox
                    txtmashow.Enabled = false;
                    txtmaphim.Enabled = false;
                    txtmaphong.Enabled = false;
                    txtgia.Enabled = false;
                    txtngay.Enabled = false;
                    txtgio.Enabled = false;
                    txtsoghe.Enabled = false;
                    break;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
