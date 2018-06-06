namespace DataManagerSystem.Modules
{
    partial class BewerbungUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BewerbungUI));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilternameTB = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.AddBewerbungBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.EinstufenBtn = new System.Windows.Forms.Button();
            this.SendenBtn = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FilterTypCB = new System.Windows.Forms.ComboBox();
            this.StatusBtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.EditBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(586, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 29);
            this.label2.TabIndex = 40;
            this.label2.Text = "Id :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.FilternameTB);
            this.panel1.Controls.Add(this.IdLabel);
            this.panel1.Controls.Add(this.AddBewerbungBtn);
            this.panel1.Controls.Add(this.ExitBtn);
            this.panel1.Controls.Add(this.EinstufenBtn);
            this.panel1.Controls.Add(this.SendenBtn);
            this.panel1.Controls.Add(this.PrintBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.FilterTypCB);
            this.panel1.Controls.Add(this.StatusBtn);
            this.panel1.Controls.Add(this.Deletebtn);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.EditBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 781);
            this.panel1.TabIndex = 41;
            // 
            // FilternameTB
            // 
            this.FilternameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilternameTB.Location = new System.Drawing.Point(261, 20);
            this.FilternameTB.Name = "FilternameTB";
            this.FilternameTB.Size = new System.Drawing.Size(193, 29);
            this.FilternameTB.TabIndex = 69;
            this.FilternameTB.TextChanged += new System.EventHandler(this.FilternameTB_TextChanged);
            // 
            // IdLabel
            // 
            this.IdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.Location = new System.Drawing.Point(645, 20);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(0, 29);
            this.IdLabel.TabIndex = 67;
            // 
            // AddBewerbungBtn
            // 
            this.AddBewerbungBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddBewerbungBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AddBewerbungBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBewerbungBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBewerbungBtn.ForeColor = System.Drawing.Color.White;
            this.AddBewerbungBtn.Location = new System.Drawing.Point(570, 722);
            this.AddBewerbungBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.AddBewerbungBtn.Name = "AddBewerbungBtn";
            this.AddBewerbungBtn.Size = new System.Drawing.Size(140, 50);
            this.AddBewerbungBtn.TabIndex = 64;
            this.AddBewerbungBtn.Text = "Neue Bewerbung";
            this.AddBewerbungBtn.UseVisualStyleBackColor = false;
            this.AddBewerbungBtn.Click += new System.EventHandler(this.AddBewerbungBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExitBtn.BackColor = System.Drawing.Color.White;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ExitBtn.Location = new System.Drawing.Point(930, 722);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(140, 50);
            this.ExitBtn.TabIndex = 62;
            this.ExitBtn.Text = "Schließen";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // EinstufenBtn
            // 
            this.EinstufenBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EinstufenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.EinstufenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EinstufenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EinstufenBtn.ForeColor = System.Drawing.Color.White;
            this.EinstufenBtn.Location = new System.Drawing.Point(12, 722);
            this.EinstufenBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.EinstufenBtn.Name = "EinstufenBtn";
            this.EinstufenBtn.Size = new System.Drawing.Size(140, 50);
            this.EinstufenBtn.TabIndex = 61;
            this.EinstufenBtn.Text = "Einstufen";
            this.EinstufenBtn.UseVisualStyleBackColor = false;
            this.EinstufenBtn.Click += new System.EventHandler(this.EinstufenBtn_Click);
            // 
            // SendenBtn
            // 
            this.SendenBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SendenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.SendenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendenBtn.ForeColor = System.Drawing.Color.White;
            this.SendenBtn.Location = new System.Drawing.Point(372, 722);
            this.SendenBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.SendenBtn.Name = "SendenBtn";
            this.SendenBtn.Size = new System.Drawing.Size(140, 50);
            this.SendenBtn.TabIndex = 60;
            this.SendenBtn.Text = "Senden";
            this.SendenBtn.UseVisualStyleBackColor = false;
            this.SendenBtn.Click += new System.EventHandler(this.SendenBtn_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PrintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PrintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintBtn.ForeColor = System.Drawing.Color.White;
            this.PrintBtn.Location = new System.Drawing.Point(192, 722);
            this.PrintBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(140, 50);
            this.PrintBtn.TabIndex = 59;
            this.PrintBtn.Text = "Docx Exportieren";
            this.PrintBtn.UseVisualStyleBackColor = false;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Filter:";
            // 
            // FilterTypCB
            // 
            this.FilterTypCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterTypCB.FormattingEnabled = true;
            this.FilterTypCB.Items.AddRange(new object[] {
            "Name",
            "Vorname",
            "Semester",
            "Geschlecht",
            "Hochschule",
            "Studiengang",
            "Nationalitaet",
            "Masterstudiengang",
            "Masterstudiengang2",
            "Masterstudiengang3"});
            this.FilterTypCB.Location = new System.Drawing.Point(62, 21);
            this.FilterTypCB.Name = "FilterTypCB";
            this.FilterTypCB.Size = new System.Drawing.Size(193, 28);
            this.FilterTypCB.TabIndex = 56;
            this.FilterTypCB.Text = "Choose Filter";
            this.FilterTypCB.SelectedIndexChanged += new System.EventHandler(this.FilterTypCB_SelectedIndexChanged);
            // 
            // StatusBtn
            // 
            this.StatusBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StatusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.StatusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBtn.ForeColor = System.Drawing.Color.White;
            this.StatusBtn.Location = new System.Drawing.Point(750, 722);
            this.StatusBtn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.StatusBtn.Name = "StatusBtn";
            this.StatusBtn.Size = new System.Drawing.Size(140, 50);
            this.StatusBtn.TabIndex = 55;
            this.StatusBtn.Text = "Zustand anschauen";
            this.StatusBtn.UseVisualStyleBackColor = false;
            this.StatusBtn.Click += new System.EventHandler(this.StatusBtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Deletebtn.BackColor = System.Drawing.Color.White;
            this.Deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Deletebtn.Location = new System.Drawing.Point(929, 20);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.Deletebtn.Size = new System.Drawing.Size(140, 29);
            this.Deletebtn.TabIndex = 54;
            this.Deletebtn.Text = "Entfernen";
            this.Deletebtn.UseVisualStyleBackColor = false;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 66);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(1057, 647);
            this.dataGridView.TabIndex = 18;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.White;
            this.EditBtn.Location = new System.Drawing.Point(750, 19);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.EditBtn.Size = new System.Drawing.Size(140, 29);
            this.EditBtn.TabIndex = 52;
            this.EditBtn.Text = "Editieren";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // BewerbungUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1081, 781);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BewerbungUI";
            this.Text = "Bewerbungsübersicht";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BewerbungUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button StatusBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FilterTypCB;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button EinstufenBtn;
        private System.Windows.Forms.Button SendenBtn;
        private System.Windows.Forms.Button AddBewerbungBtn;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.TextBox FilternameTB;
    }
}