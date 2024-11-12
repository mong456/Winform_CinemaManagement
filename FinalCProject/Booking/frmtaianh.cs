using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FinalCProject.Booking
{
    public partial class frmtaianh : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string API_URL = "http://localhost:5000/predict";

        public frmtaianh()
        {
            InitializeComponent();
        }

        private async void btntaianh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh phim";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Hiển thị hình ảnh
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                        // Chuyển ảnh sang base64
                        string base64Image = ConvertImageToBase64(openFileDialog.FileName);

                        // Gọi API dự đoán
                        var prediction = await PredictGenre(base64Image);

                        // Kiểm tra nếu dự đoán không null
                        if (prediction != null)
                        {
                            // Lọc và lấy tên 3 thể loại có xác suất cao nhất
                            var topGenres = prediction.Probabilities
                                .OrderByDescending(kvp => kvp.Value) // Sắp xếp theo xác suất giảm dần
                                .Take(2) // Lấy 3 thể loại có xác suất cao nhất
                                .ToDictionary(kvp => kvp.Key);

                            if (topGenres.Count > 0)
                            {
                                PredictionStorage.ketqua = string.Join(", ", topGenres.Select(kvp => $"{kvp.Key}"));
                            }
                            else
                            {
                                MessageBox.Show("Không có kết quả dự đoán nào.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có kết quả dự đoán.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}");
                    }
                }
            }
        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }

        private async Task<PredictionResult> PredictGenre(string base64Image)
        {
            var request = new
            {
                image = base64Image
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json"
            );

            // Gọi API dự đoán với API_URL
            var response = await client.PostAsync(API_URL, content);

            // Kiểm tra mã trạng thái phản hồi
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PredictionResult>(jsonResponse);
            }
            else
            {
                // Xử lý lỗi nếu không thành công
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi từ API: {errorMessage}");
            }
        }

        private void frmtaianh_Load(object sender, EventArgs e)
        {
            
        }

        public class PredictionResult
        {
            [JsonProperty("genre")]
            public string Genre { get; set; }

            [JsonProperty("probabilities")]
            public Dictionary<string, double> Probabilities { get; set; }           
        }

        public static class PredictionStorage
        {
            public static string ketqua { get; set; }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            frmchonphim cp = new frmchonphim();
            if (!string.IsNullOrEmpty(PredictionStorage.ketqua))
            {
                cp.UpdateTextBox(PredictionStorage.ketqua); // Gọi phương thức cập nhật Kết quả dự đoán
            }
            else
            {
                MessageBox.Show("Chưa có kết quả dự đoán để tìm kiếm.");
            }            
            this.Hide();
            cp.ShowDialog();
            this.Show();
        }
    }
}

