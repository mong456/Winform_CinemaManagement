using FinalCProject.Booking;
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

namespace FinalCProject
{

    public partial class frmdannhap : Form
    {
        

        public frmdannhap()
        {
            InitializeComponent();
            
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string email = txtgmail.Text;
            string password = txtmatkhau.Text;

            GetInfor.Username = txtgmail.Text; // Lưu gmail đăng nhập

            // Gọi hàm kiểm tra đăng nhập
            if (Login(email, password))
            {
                GetInfor.Email = email;
                frmtrangchu c = new frmtrangchu();
                this.Hide();
                c.ShowDialog();
                this.Close(); // Đóng form đăng nhập
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không chính xác!");
            }
        }
        public bool Login(string email, string password)
        {
            string query = "select count(*) from Customer where email= @Email AND Passwords = @Password";

            // Thực thi ExcuteScalar và truyền tham số email, password
            object result = DataProvider.Instance.ExcuteScalar(query, new object[] { email, password });

            // Kiểm tra nếu kết quả khác 0, tức là có tài khoản hợp lệ
            return Convert.ToInt32(result) > 0;
        }

        private void btnttaikhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnttaikhoan_Click_1(object sender, EventArgs e)
        {
            frmtaotaikhoan tk = new frmtaotaikhoan();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmdannhap_Load(object sender, EventArgs e)
        {
            this.Size = new Size(690, 500);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
