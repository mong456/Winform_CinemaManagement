namespace FinalCProject.Booking
{
    partial class frmtrangchu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtrangchu));
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuphim = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuphimdangchieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnupsapchieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuquanly = new System.Windows.Forms.ToolStripMenuItem();
            this.tấtCảCácRạpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rạpĐặcBiệtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chỉTiêuThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinVéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.véCủaBạnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptbAnh = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(252, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1660, 220);
            this.panel2.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuphim,
            this.mnuquanly,
            this.thốngKêToolStripMenuItem,
            this.thôngTinVéToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1660, 58);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuphim
            // 
            this.mnuphim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.mnuphim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuphimdangchieu,
            this.mnupsapchieu});
            this.mnuphim.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuphim.ForeColor = System.Drawing.Color.Black;
            this.mnuphim.Name = "mnuphim";
            this.mnuphim.Size = new System.Drawing.Size(132, 54);
            this.mnuphim.Text = "Phim";
            // 
            // mnuphimdangchieu
            // 
            this.mnuphimdangchieu.BackColor = System.Drawing.Color.Black;
            this.mnuphimdangchieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnuphimdangchieu.Name = "mnuphimdangchieu";
            this.mnuphimdangchieu.Size = new System.Drawing.Size(359, 58);
            this.mnuphimdangchieu.Text = "Đang chiếu";
            this.mnuphimdangchieu.Click += new System.EventHandler(this.mnuphimdangchieu_Click);
            // 
            // mnupsapchieu
            // 
            this.mnupsapchieu.BackColor = System.Drawing.Color.Black;
            this.mnupsapchieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnupsapchieu.Name = "mnupsapchieu";
            this.mnupsapchieu.Size = new System.Drawing.Size(359, 58);
            this.mnupsapchieu.Text = "Sắp chiều";
            // 
            // mnuquanly
            // 
            this.mnuquanly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.mnuquanly.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tấtCảCácRạpToolStripMenuItem,
            this.rạpĐặcBiệtToolStripMenuItem,
            this.quảnLýPhimToolStripMenuItem,
            this.quảnLyToolStripMenuItem});
            this.mnuquanly.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuquanly.Name = "mnuquanly";
            this.mnuquanly.Size = new System.Drawing.Size(154, 54);
            this.mnuquanly.Text = "Quản lý";
            this.mnuquanly.Click += new System.EventHandler(this.rạpToolStripMenuItem_Click);
            // 
            // tấtCảCácRạpToolStripMenuItem
            // 
            this.tấtCảCácRạpToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.tấtCảCácRạpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tấtCảCácRạpToolStripMenuItem.Name = "tấtCảCácRạpToolStripMenuItem";
            this.tấtCảCácRạpToolStripMenuItem.Size = new System.Drawing.Size(468, 54);
            this.tấtCảCácRạpToolStripMenuItem.Text = "Quản lý phòng chiếu";
            this.tấtCảCácRạpToolStripMenuItem.Click += new System.EventHandler(this.tấtCảCácRạpToolStripMenuItem_Click);
            // 
            // rạpĐặcBiệtToolStripMenuItem
            // 
            this.rạpĐặcBiệtToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.rạpĐặcBiệtToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rạpĐặcBiệtToolStripMenuItem.Name = "rạpĐặcBiệtToolStripMenuItem";
            this.rạpĐặcBiệtToolStripMenuItem.Size = new System.Drawing.Size(468, 54);
            this.rạpĐặcBiệtToolStripMenuItem.Text = "Quản lý rạp chiếu";
            this.rạpĐặcBiệtToolStripMenuItem.Click += new System.EventHandler(this.rạpĐặcBiệtToolStripMenuItem_Click);
            // 
            // quảnLýPhimToolStripMenuItem
            // 
            this.quảnLýPhimToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText;
            this.quảnLýPhimToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quảnLýPhimToolStripMenuItem.Name = "quảnLýPhimToolStripMenuItem";
            this.quảnLýPhimToolStripMenuItem.Size = new System.Drawing.Size(468, 54);
            this.quảnLýPhimToolStripMenuItem.Text = "Quản lý phim";
            this.quảnLýPhimToolStripMenuItem.Click += new System.EventHandler(this.quảnLýPhimToolStripMenuItem_Click);
            // 
            // quảnLyToolStripMenuItem
            // 
            this.quảnLyToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quảnLyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quảnLyToolStripMenuItem.Name = "quảnLyToolStripMenuItem";
            this.quảnLyToolStripMenuItem.Size = new System.Drawing.Size(468, 54);
            this.quảnLyToolStripMenuItem.Text = "Quản lý show";
            this.quảnLyToolStripMenuItem.Click += new System.EventHandler(this.quảnLyToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.DarkGray;
            this.guna2Separator1.FillColor = System.Drawing.Color.Black;
            this.guna2Separator1.Location = new System.Drawing.Point(2, 224);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1910, 10);
            this.guna2Separator1.TabIndex = 4;
            this.guna2Separator1.Click += new System.EventHandler(this.guna2Separator1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.ptbAnh);
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1912, 804);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chỉTiêuThốngKêToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thốngKêToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(181, 54);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // chỉTiêuThốngKêToolStripMenuItem
            // 
            this.chỉTiêuThốngKêToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chỉTiêuThốngKêToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.chỉTiêuThốngKêToolStripMenuItem.Name = "chỉTiêuThốngKêToolStripMenuItem";
            this.chỉTiêuThốngKêToolStripMenuItem.Size = new System.Drawing.Size(416, 54);
            this.chỉTiêuThốngKêToolStripMenuItem.Text = "Chỉ tiêu thống kê";
            this.chỉTiêuThốngKêToolStripMenuItem.Click += new System.EventHandler(this.chỉTiêuThốngKêToolStripMenuItem_Click);
            // 
            // thôngTinVéToolStripMenuItem
            // 
            this.thôngTinVéToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.thôngTinVéToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.véCủaBạnToolStripMenuItem});
            this.thôngTinVéToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinVéToolStripMenuItem.Name = "thôngTinVéToolStripMenuItem";
            this.thôngTinVéToolStripMenuItem.Size = new System.Drawing.Size(229, 54);
            this.thôngTinVéToolStripMenuItem.Text = "Thông tin vé";
            // 
            // véCủaBạnToolStripMenuItem
            // 
            this.véCủaBạnToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.véCủaBạnToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.véCủaBạnToolStripMenuItem.Name = "véCủaBạnToolStripMenuItem";
            this.véCủaBạnToolStripMenuItem.Size = new System.Drawing.Size(359, 54);
            this.véCủaBạnToolStripMenuItem.Text = "Vé của bạn";
            this.véCủaBạnToolStripMenuItem.Click += new System.EventHandler(this.véCủaBạnToolStripMenuItem_Click);
            // 
            // ptbAnh
            // 
            this.ptbAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.ptbAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbAnh.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ptbAnh.ErrorImage")));
            this.ptbAnh.Location = new System.Drawing.Point(685, 89);
            this.ptbAnh.Name = "ptbAnh";
            this.ptbAnh.Size = new System.Drawing.Size(618, 624);
            this.ptbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAnh.TabIndex = 1;
            this.ptbAnh.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FinalCProject.Properties.Resources.z5919486903104_7f71a48142ff9bff616fc5b415a2473c;
            this.pictureBox1.Location = new System.Drawing.Point(2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmtrangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 1056);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmtrangchu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtrangchu";
            this.Load += new System.EventHandler(this.frmtrangchu_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ptbAnh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuphim;
        private System.Windows.Forms.ToolStripMenuItem mnuphimdangchieu;
        private System.Windows.Forms.ToolStripMenuItem mnupsapchieu;
        private System.Windows.Forms.ToolStripMenuItem mnuquanly;
        private System.Windows.Forms.ToolStripMenuItem tấtCảCácRạpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rạpĐặcBiệtToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLyToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chỉTiêuThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinVéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem véCủaBạnToolStripMenuItem;
    }
}