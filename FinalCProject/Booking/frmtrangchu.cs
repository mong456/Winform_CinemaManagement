using FinalCProject.DTH;
using FinalCProject.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalCProject.Booking
{
    public partial class frmtrangchu : Form
    {
        private string[] imagePaths;
        private int currentImageIndex = 0;
        private Timer timer;
        // Kiểm tra xem ControlsPanel đã được khai báo chưa
        private Panel ControlsPanel;
        public frmtrangchu()
        {
            InitializeComponent();
            imagePaths = new string[]
            {
                @"E:\WinformImage\Function\phim\3 idiots.jpg",
                @"E:\WinformImage\Function\phim\Black Panther.jpg",
                @"E:\WinformImage\Function\phim\Deadpool and Wolverine.jpg",
                @"E:\WinformImage\Function\phim\Tee Yod Qủy ăn tạng.jpg",
                @"E:\WinformImage\Function\phim\Doraemon Nobita và bản giao hưởng.jpg",
                @"E:\posterfilm\No_Hard_Feelings.jpg",
                @"E:\posterfilm\Creed_III.jpg",
                
                // Thêm các ảnh khác vào đây
            };

            // Khởi tạo PictureBox
            ptbAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAnh.ImageLocation = imagePaths[currentImageIndex];

            timer = new Timer();
            timer.Interval = 2000; // Đặt khoảng thời gian 8 giây
            timer.Tick += timer1_Tick;
            timer.Start();
          
        }

        private void frmtrangchu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(970, 580);
            if (GetInfor.Email == "admin")
            {
                mnuphim.Visible = true;
                mnuquanly.Visible = true;
                thốngKêToolStripMenuItem.Visible = true;
                thôngTinVéToolStripMenuItem.Visible = true;
            }
            else
            {
                mnuphim.Enabled = true;
                mnuquanly.Visible = true;//flase;
                thốngKêToolStripMenuItem.Visible = true;//false;
                thôngTinVéToolStripMenuItem.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Tăng chỉ mục của ảnh hiện tại
            currentImageIndex++;

            // Nếu đến cuối danh sách ảnh, quay lại ảnh đầu tiên
            if (currentImageIndex >= imagePaths.Length)
            {
                currentImageIndex = 0;
            }

            // Cập nhật ảnh trong PictureBox
            ptbAnh.ImageLocation = imagePaths[currentImageIndex];
        }

        private void rạpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuphimdangchieu_Click(object sender, EventArgs e)
        {
            AddControls(new frmchonphim());

        }

        private void tấtCảCácRạpToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            AddControls(new frmqlphongchieu());
        }

        private void rạpĐặcBiệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControls (new frmqlrapchieu());
            
        }

        private void quảnLýPhimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControls( new frmquanliphim());
            
        }

        private void quảnLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControls(new frmshow());                    
            
        }
        public void AddControls(Form f)
        {
            panel1.Controls.Clear();
            f.Dock= DockStyle.Fill;
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show(); 
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmtrangchu tc = new frmtrangchu();
            tc.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void chỉTiêuThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControls(new frmthongke());
        }

        private void véCủaBạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControls(new frmthongtinve());
        }

        
    }
}
