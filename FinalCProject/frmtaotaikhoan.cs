using FinalCProject.DTH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCProject
{
    public partial class frmtaotaikhoan : Form
    {
        public frmtaotaikhoan()
        {
            InitializeComponent();
        }

        private void btndangki_Click(object sender, EventArgs e)
        {
            string email = txtgmail.Text;
            string password = txtmatkhau.Text;
            string fname = txtho.Text;
            string lname = txtten.Text;
            int age = int.Parse(txttuoi.Text);
            string phonenumber = txtsodienthoai.Text;

            // Gọi hàm tạo tài khoản
            if (CreateAccount(email, password, fname, lname, age, phonenumber))
            {
                // Hiển thị thông báo tạo tài khoản thành công
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển về form đăng nhập
                frmdannhap loginForm = new frmdannhap();
                this.Hide(); // Ẩn form tạo tài khoản
                loginForm.ShowDialog();
                this.Close(); // Đóng form tạo tài khoản sau khi form đăng nhập đóng
            }
        }
        public bool CreateAccount(string email, string password, string fname, string lname, int age, string phonenumber)
        {
            try
            {
                // Chuỗi truy vấn gọi Store Procedure để thêm tài khoản
                string query = "EXEC Add_Customer  @FirstName,@LastName, @Age,@PhoneNumber,@Email,@Password";

                // Tạo danh sách tham số
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Email", email));
                parameters.Add(new SqlParameter("@Password", password));
                parameters.Add(new SqlParameter("@FirstName", fname));
                parameters.Add(new SqlParameter("@LastName", lname));
                parameters.Add(new SqlParameter("@Age", age));
                parameters.Add(new SqlParameter("@PhoneNumber", phonenumber));

                // Thực thi câu truy vấn với tham số
                int result = DataProvider.Instance.ExcuteNoneQuery1(query, parameters.ToArray());

                // Nếu kết quả trả về khác 0, tức là tài khoản đã được tạo
                return result > 0;
            }
            catch (SqlException ex)
            {
                // Nếu xảy ra lỗi (ví dụ: Email đã tồn tại)
                MessageBox.Show(ex.Message, "Thông báo");
                return false;
            }
        }

        private void frmtaotaikhoan_Load(object sender, EventArgs e)
        {
            this.Size = new Size(690, 500);
        }
    }
}
