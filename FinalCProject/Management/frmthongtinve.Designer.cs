namespace FinalCProject.Management
{
    partial class frmthongtinve
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
            this.dgthongtinve = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgthongtinve)).BeginInit();
            this.SuspendLayout();
            // 
            // dgthongtinve
            // 
            this.dgthongtinve.BackgroundColor = System.Drawing.Color.White;
            this.dgthongtinve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgthongtinve.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgthongtinve.Location = new System.Drawing.Point(0, 151);
            this.dgthongtinve.Name = "dgthongtinve";
            this.dgthongtinve.RowHeadersWidth = 82;
            this.dgthongtinve.RowTemplate.Height = 33;
            this.dgthongtinve.Size = new System.Drawing.Size(1652, 630);
            this.dgthongtinve.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(691, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vé đã đặt";
            // 
            // frmthongtinve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1652, 781);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgthongtinve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmthongtinve";
            this.Text = "frmthongtinve";
            this.Load += new System.EventHandler(this.frmthongtinve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgthongtinve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgthongtinve;
        private System.Windows.Forms.Label label1;
    }
}