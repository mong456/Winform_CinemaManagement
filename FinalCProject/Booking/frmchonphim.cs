using FinalCProject.DTH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCProject.Booking
{
    public partial class frmchonphim : Form
    {
        public frmchonphim()
        {
            InitializeComponent();
            LoadImagesToFlowPanel("");
        }
        private string ketquadudoan ="";
        private void frmchonphim_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);
        }
        private void LoadImagesToFlowPanel(string genres) // Load image into FlowLayoutPanel
        {
            // Xóa các ảnh trước đó trong FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            string title = txttimkiem.Text.Trim();

            // Xác định câu truy vấn
            string query;
            if (string.IsNullOrEmpty(genres))
            {
                // Nếu không có thể loại nào được cung cấp, tải tất cả phim
                query = "SELECT Top(10) * FROM Movie";
            }
            else if (!string.IsNullOrEmpty(title))
            {
                query = $"SELECT * FROM Movie WHERE Title LIKE '%{title}%'";
            }
            else
            {
                // Nếu có thể loại được cung cấp, tạo câu truy vấn với điều kiện LIKE
                string[] genreList = genres.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                query = "SELECT * FROM Movie WHERE MainGenre LIKE '%" + string.Join("%' OR MainGenre LIKE '%", genreList) + "%'";
            }

            ResultTable(query);
        }
        private void ResultTable(string query)
        {
            DataTable movieTable = DataProvider.Instance.ExcuteQuery(query);

            if (movieTable.Rows.Count == 0)
            {
                Label noDataLabel = new Label
                {
                    Text = "Không có thông tin tìm kiếm",
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Margin = new Padding(20)
                };

                // Thêm Label vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(noDataLabel);
                flowLayoutPanel1.Refresh(); // Làm mới FlowLayoutPanel
                return;
            }

            foreach (DataRow row in movieTable.Rows)
            {
                string movieid = row["Movieid"].ToString();
                string movietitle = row["Title"].ToString();
                string genre = row["MainGenre"].ToString();
                string imagePath = row["Poster"].ToString();
                string director = row["Director"].ToString() ;
                string desc = row["Description"].ToString();

                PictureBox pictureBox = new PictureBox();
                if (File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath); // Tải ảnh từ file
                }
                else
                {
                    string defaultImagePath = @"E:\WinformImage\Function\phim\The Shawshank.jpg";
                    if (File.Exists(defaultImagePath))
                    {
                        pictureBox.Image = Image.FromFile(defaultImagePath);
                    }
                }

                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 168;
                pictureBox.Height = 205;
                pictureBox.Padding = new Padding(5);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;

                // Thay đổi giao diện khi di chuột vào PictureBox
                pictureBox.MouseEnter += (s, e) =>
                {
                    pictureBox.BackColor = Color.LightGray; // Đổi màu nền để nhận biết
                    pictureBox.Cursor = Cursors.Hand; // Thay đổi con trỏ chuột thành dạng bàn tay
                };

                // Trở lại giao diện ban đầu khi chuột rời PictureBox
                pictureBox.MouseLeave += (s, e) =>
                {
                    pictureBox.BackColor = Color.Transparent; // Trở lại màu nền ban đầu
                    pictureBox.Cursor = Cursors.Default; // Trở lại con trỏ chuột mặc định
                };

                // Tạo Label để hiển thị tên phim
                Label lblMovieName = new Label();
                lblMovieName.Text = "Genre: "+genre;
                lblMovieName.TextAlign = ContentAlignment.MiddleCenter;
                lblMovieName.AutoSize = true; // Cho phép kích thước tự động điều chỉnh

                // Tạo Label để hiển thị ID phim
                Label lblMovieId = new Label();
                lblMovieId.Text = "Title: " + movietitle;
                lblMovieId.TextAlign = ContentAlignment.MiddleCenter;
                lblMovieId.AutoSize = true; // Cho phép kích thước tự động điều chỉnh

                // Tạo một Panel để chứa PictureBox và các Label
                Panel panel = new Panel();
                panel.Width = pictureBox.Width + 10;
                panel.Height = pictureBox.Height + lblMovieId.Height + lblMovieName.Height + 20; // Tăng chiều cao để không bị chồng chéo
                panel.Padding = new Padding(5);

                // Thêm PictureBox và các Label vào Panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblMovieId);
                panel.Controls.Add(lblMovieName);

                // Đặt vị trí của các control bên trong Panel
                pictureBox.Location = new Point(0, 0);
                lblMovieId.Location = new Point(0, pictureBox.Bottom + 5);
                lblMovieName.Location = new Point(0, lblMovieId.Bottom + 5);

                // Xử lý sự kiện khi nhấn vào ảnh
                pictureBox.Click += (s, eArgs) =>
                {
                    GetInfor.Movieid = movieid;
                    frmmotaphim mov = new frmmotaphim();
                    mov.LoadMovieInfor(pictureBox.Image, genre,director,desc); // Truyền dữ liệu ảnh và tên phim
                    mov.ShowDialog();
                };


                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            frmtaianh ta = new frmtaianh();
            this.Hide();
            ta.ShowDialog();
            this.Show();
        }
        public void UpdateTextBox(string ketqua)
        {
            if (!string.IsNullOrEmpty(ketqua))
            {
                ketquadudoan = ketqua;
                LoadImagesToFlowPanel(ketquadudoan);
            }
            else
            {
               MessageBox.Show( "Không có kết quả dự đoán.");
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string title = txttimkiem.Text.Trim(); // Lấy tiêu đề phim từ TextBox

            if (!string.IsNullOrEmpty(title))
            {
                // Tìm kiếm theo tiêu đề nếu có tiêu đề nhập vào
                LoadImagesToFlowPanel(title);
            }
            else
            {
                // Nếu không có tiêu chí nào, hiển thị tất cả phim
                LoadImagesToFlowPanel(null);
            }
        }
    }
}
