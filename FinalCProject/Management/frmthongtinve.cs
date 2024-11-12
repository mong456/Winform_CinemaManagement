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
    public partial class frmthongtinve : Form
    {
        public frmthongtinve()
        {
            InitializeComponent();
        }

        private void frmthongtinve_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);

            string query = $"select *from ttve where Email='{GetInfor.Email}'";
            DataTable table = DataProvider.Instance.ExcuteQuery(query);
            dgthongtinve.DataSource = table;
            dgthongtinve.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
