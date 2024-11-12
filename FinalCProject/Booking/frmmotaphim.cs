using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCProject.Booking
{
    public partial class frmmotaphim : Form
    {
        public frmmotaphim()
        {
            InitializeComponent();
        }

        private void frmmotaphim_Load(object sender, EventArgs e)
        {

        }
        public void LoadMovieInfor(Image movieImage, string genre, string director, string desc)
        {
            ptbanhphim.Image = movieImage;
            txtmotaphim.Text = "- Genre: " + genre + Environment.NewLine +
                               "- Director: " + director + Environment.NewLine +
                               "- Description: " + desc;

            txtmotaphim.Font = new Font(txtmotaphim.Font.FontFamily, 12);
        }



        private void ptbanhphim_Click(object sender, EventArgs e)
        {
            
        }

        private void btnmuave_Click(object sender, EventArgs e)
        {
            frmthongtindatve dv = new frmthongtindatve();
            this.Hide();
            dv.ShowDialog();
            this.Show();
        }
    }
}
