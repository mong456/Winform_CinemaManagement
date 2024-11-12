using FinalCProject.DTH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalCProject.Booking
{
    public partial class frmthongtindatve : Form
    {
        private string ngaydat;
        private TimeSpan giodat;    
       
        public frmthongtindatve()
        {
            InitializeComponent();
            LoadDataToComboBox();
           cmbrapchieu.SelectedIndexChanged += cmbrapchieu_SelectedIndexChanged;
        }

        private void Cmbdiadiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frmthongtindatve_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 505);

            if (cmbdiadiem.Items.Count >0)
                cmbdiadiem.SelectedIndex = 0;

            if (cmbrapchieu.Items.Count > 0)
                cmbrapchieu.SelectedIndex = 0;

            DayinMonth();           
            
        }

        private System.Windows.Forms.Label selectedLabel = null; // Biến lưu trữ label đang được chọn

        public void DayinMonth()//Lấy ngày trong 1 tháng và load lên
        {
            int curMonth = DateTime.Now.Month;
            int curYear = DateTime.Now.Year;
            int dayInMonth = DateTime.DaysInMonth(curYear, curMonth);

            flngay.Controls.Clear();

            for (int day = 1; day <= dayInMonth; day++)
            {
                System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                lb.Text = day.ToString();
                lb.Size = new Size(30, 25);
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.Margin = new Padding(2, 5, 2, 5);
                flngay.Controls.Add(lb);

                // Biến để lưu màu ban đầu của mỗi label
                Color originalColor = lb.BackColor;

                // Sự kiện Click để thay đổi màu khi nhấp chuột
                lb.Click += (s, e) =>
                {
                    // Nếu có Label đang được chọn trước đó và khác với Label hiện tại
                    if (selectedLabel != null && selectedLabel != lb)
                    {
                        selectedLabel.BackColor = originalColor; // Trả về màu cũ của Label trước
                    }

                    // Cập nhật Label đang được chọn và đổi màu
                    lb.BackColor = Color.LightBlue;
                    selectedLabel = lb;

                    ngaydat = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00") + "-" + lb.Text.PadLeft(2, '0');

                    LoadDataToComboBox();
               
                };
            }
        }


        private void LoadDataToComboBox()
        {
            string query = $"select distinct diadiem from diadiem where ngay = '{ngaydat}'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            if (data.Rows.Count > 0)
            {
                cmbdiadiem.DisplayMember = "Diadiem";
                cmbdiadiem.DataSource = data;
            }
            else
            {
                cmbdiadiem.DataSource = null;               
            }
        }

        private void LoadRapByDiaDiem(string diadiem)
        {
            string query = "SELECT TheaterName FROM Theater WHERE Location = @diadiem";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { diadiem });
            if (data.Rows.Count > 0)
            {
                cmbrapchieu.DisplayMember = "TheaterName";
                cmbrapchieu.DataSource = data;
            }
            else
            {
                cmbrapchieu.DataSource = null;
            }
        }
        private void cmbdiadiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cDiadiem = cmbdiadiem.Text;
            LoadRapByDiaDiem(cDiadiem);
            
        }

        private System.Windows.Forms.Label selectedLabel2 = null;
        private void LoadGioDat(string rapChieu) // Load giờ chiếu phim lên FlowPanel
        {
            string query = $"SELECT giodat FROM datve WHERE movie = '{GetInfor.Movieid}' AND diadiem = N'{cmbdiadiem.Text}' AND rapchieu = N'{cmbrapchieu.Text}' AND ngaydat = '{ngaydat}'";
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            flthoigian.Controls.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                TimeSpan time = (TimeSpan)row["giodat"];
                System.Windows.Forms.Label timeLabel = new System.Windows.Forms.Label
                {
                    Text = time.ToString(@"hh\:mm"),
                    AutoSize = true,
                    Padding = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };
                flthoigian.Controls.Add(timeLabel);

                Color originalColor = timeLabel.BackColor;

                // Sự kiện Click để thay đổi màu khi nhấp chuột
                timeLabel.Click += (s, e) =>
                {
                    // Nếu có Label đang được chọn trước đó và khác với Label hiện tại
                    if (selectedLabel2 != null && selectedLabel2 != timeLabel)
                    {
                        selectedLabel2.BackColor = originalColor; // Trả về màu cũ của Label trước
                    }

                    // Cập nhật Label đang được chọn và đổi màu
                    timeLabel.BackColor = Color.LightBlue;
                    selectedLabel2 = timeLabel;

                    // Lưu giờ đặt vào biến giodat
                    giodat = time;
                    Loadphongchieu();
               
                };
            }
        }



        private void cmbrapchieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbrapchieu.SelectedIndex != -1)
            {
                // Lấy giá trị được chọn từ combobox
                string selectedRap = cmbrapchieu.GetItemText(cmbrapchieu.SelectedItem);

                // Load giờ chiếu dựa trên rạp được chọn
                LoadGioDat(selectedRap);
            }
        }
        private void Loadphongchieu()//Load phòng chiếu
        {
            string query = $"select maphong from datve where diadiem=N'{cmbdiadiem.Text}' and rapchieu=N'{cmbrapchieu.Text}' and giodat='{giodat}' and ngaydat='{ngaydat}' ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                cmbphongchieu.DisplayMember = "maphong";
                cmbphongchieu.DataSource = data;
            }
            else
            {
                cmbphongchieu.DataSource = null;
            }

        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                string email = GetInfor.Email;
                int movieId = int.Parse(GetInfor.Movieid);
                string location = cmbdiadiem.Text;
                string theater = cmbrapchieu.Text;
                string roomid = cmbphongchieu.Text;

                             
                string showDate = ngaydat;
                string showTime = giodat.ToString();
                string paymentMethod = cmbthanhtoan.Text;

                // Tạo câu query với tham số trực tiếp
                string query = string.Format(
                    "EXEC Booking_ticket '{0}', {1}, '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}'",
                    email, movieId, showDate, location, theater, roomid, showTime, paymentMethod);

                int result = DataProvider.Instance.ExcuteNoneQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Đặt vé thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể đặt vé. Vui lòng thử lại.");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu: " + fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt vé: " + ex.Message);
            }
        }








        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
