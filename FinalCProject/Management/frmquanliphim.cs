using FinalCProject.DTH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCProject.Management
{
    public partial class frmquanliphim : Form
    {
        public string pathImage;
        public frmquanliphim()
        {
            InitializeComponent();
            
            
        }

        private void frmquanliphim_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);

            if (comboBox1.Items.Count>0)
                comboBox1.SelectedIndex = 0;

            LoadData();
        }
        public void LoadData()//Load dữ liệu lên datagird view
        {
            string query = "select *from movie";
            dgquanliphim.DataSource = DataProvider.Instance.ExcuteQuery(query);
            dgquanliphim.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2VSeparator2_Click(object sender, EventArgs e)
        {

        }

        
        private void dgquanliphim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dgquanliphim.Rows[e.RowIndex];

                // Gán giá trị từ các cột vào các TextBox tương ứng dựa trên chỉ số cột
                txtid.Text=row.Cells[0].Value.ToString();
                txttieude.Text = row.Cells[1].Value.ToString();       
                txttheloai.Text = row.Cells[2].Value.ToString();       
                txtdaodien.Text = row.Cells[3].Value.ToString();    
                txtmotaphim.Text = row.Cells[4].Value.ToString(); 

                // Load ảnh vào PictureBox
                string posterPath = row.Cells[5].Value.ToString(); 
                if (File.Exists(posterPath)) 
                {
                    ptbposter.Image = Image.FromFile(posterPath);  // Load ảnh
                }
                else
                {                    
                    ptbposter.Image = Image.FromFile("E:\\WinformImage\\Function\\icon\\jjjj.jpg");
                }
            }
        }

        private void btnthuchien_Click(object sender, EventArgs e)
        {
            string selectedFunction = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedFunction))
            {
                MessageBox.Show("Vui lòng chọn chức năng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (selectedFunction)
                {
                    case "Thêm":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC Add_movie N'{txttieude.Text}', N'{txttheloai.Text}', N'{txtdaodien.Text}', N'{txtmotaphim.Text}', N'{pathImage}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thêm phim: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Sửa":
                        try
                        {
                            DataProvider.Instance.ExcuteQuery(
                                $"EXEC update_movie {txtid.Text},N'{txttieude.Text}', N'{txttheloai.Text}', N'{txtdaodien.Text}', N'{txtmotaphim.Text}', N'{pathImage}'");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi sửa phim: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "Xóa":
                        // Hiển thị hộp thoại xác nhận
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phim này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                DataProvider.Instance.ExcuteQuery($"EXEC delete_movie {txtid.Text}");
                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xóa phim: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Lỗi khi tìm kiếm phim: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txttieude.Text = "";
            txttheloai.Text = "";
            txtdaodien.Text = "";
            txtmotaphim.Text = "";

            // Đặt PictureBox về rỗng
            ptbposter.Image = null;

            // Xóa đường dẫn ảnh đã chọn
            pathImage = string.Empty;
        }

        private void btnposter_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                ofd.Title = "Chọn ảnh phim";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = ofd.FileName;

                    // Hiển thị ảnh trong PictureBox nếu bạn có
                    ptbposter.Image = Image.FromFile(imagePath);

                    // Lưu đường dẫn ảnh vào TextBox (có thể dùng để lưu vào cơ sở dữ liệu sau này)
                    pathImage = imagePath;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Kiểm tra chức năng được chọn
            string selectedFunction = comboBox1.SelectedItem?.ToString();

            // Đặt mặc định cho các TextBox
            txtid.Enabled = false;
            txttieude.Enabled = false;
            txttheloai.Enabled = false;
            txtdaodien.Enabled = false;
            txtmotaphim.Enabled = false;
            btnposter.Enabled = false;

            // Cập nhật trạng thái của các TextBox theo chức năng được chọn
            switch (selectedFunction)
            {
                case "Thêm":
                    ClearFields();
                    txttieude.Enabled = true;
                    txttheloai.Enabled = true;
                    txtdaodien.Enabled = true;
                    txtmotaphim.Enabled = true;
                    btnposter.Enabled = true;
                    break;

                case "Sửa":
                    txtid.Enabled = true;
                    txttieude.Enabled = true;
                    txttheloai.Enabled = true;
                    txtdaodien.Enabled = true;
                    txtmotaphim.Enabled = true;
                    btnposter.Enabled = true;
                    break;

                case "Xóa":;
                    txtid.Enabled = true;
                    break;

                case "Tìm kiếm":
                    txttieude.Enabled = true;
                    txttheloai.Enabled = true;
                    txtdaodien.Enabled = true;
                    break;
            }
        }
    }
}
