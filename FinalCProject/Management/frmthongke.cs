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

namespace FinalCProject.Management
{
    public partial class frmthongke : Form
    {
        public frmthongke()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    LoadViewToDataGridView("dtrap");
                    break;
                case 1:
                    LoadViewToDataGridView("dtphim");
                    break;
                case 2:
                    LoadViewToDataGridView("khachhang"); 
                    break;
                case 3:
                    LoadViewToDataGridView("phimhot");
                    break;
                default:
                    MessageBox.Show("Please select a valid option.");
                    break;
            }
        }
        private void LoadViewToDataGridView(string viewName)
        {
            
            try
            {
                string query = $"Select *from {viewName}";
                DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);           
                dgthongke.DataSource = dataTable; 
                dgthongke.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            }
           catch (Exception ex)
           {
                    MessageBox.Show($"Error loading data: {ex.Message}");
           }
            
        }

        private void frmthongke_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
