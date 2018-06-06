namespace DataManagerSystem.Modules
{
    partial class StudentInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentInfo));
            this.Vorname = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Nationalitaet = new System.Windows.Forms.Label();
            this.Idlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Semester = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nametb = new System.Windows.Forms.TextBox();
            this.vortb = new System.Windows.Forms.TextBox();
            this.natiotb = new System.Windows.Forms.TextBox();
            this.semtb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Vorname
            // 
            this.Vorname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vorname.AutoSize = true;
            this.Vorname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Vorname.Location = new System.Drawing.Point(12, 83);
            this.Vorname.Name = "Vorname";
            this.Vorname.Size = new System.Drawing.Size(63, 16);
            this.Vorname.TabIndex = 43;
            this.Vorname.Text = "Vorname";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.NameLabel.Location = new System.Drawing.Point(12, 41);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 16);
            this.NameLabel.TabIndex = 44;
            this.NameLabel.Text = "Name";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(264, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "BewerbungsID:";
            // 
            // Nationalitaet
            // 
            this.Nationalitaet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Nationalitaet.AutoSize = true;
            this.Nationalitaet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Nationalitaet.Location = new System.Drawing.Point(12, 132);
            this.Nationalitaet.Name = "Nationalitaet";
            this.Nationalitaet.Size = new System.Drawing.Size(68, 16);
            this.Nationalitaet.TabIndex = 49;
            this.Nationalitaet.Text = "Natonality";
            // 
            // Idlabel
            // 
            this.Idlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Idlabel.AutoSize = true;
            this.Idlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Idlabel.Location = new System.Drawing.Point(440, 11);
            this.Idlabel.Name = "Idlabel";
            this.Idlabel.Size = new System.Drawing.Size(29, 24);
            this.Idlabel.TabIndex = 51;
            this.Idlabel.Text = "ID";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.button1.Location = new System.Drawing.Point(819, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 39);
            this.button1.TabIndex = 57;
            this.button1.Text = "Shließen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Semester
            // 
            this.Semester.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Semester.AutoSize = true;
            this.Semester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Semester.Location = new System.Drawing.Point(12, 188);
            this.Semester.Name = "Semester";
            this.Semester.Size = new System.Drawing.Size(66, 16);
            this.Semester.TabIndex = 58;
            this.Semester.Text = "Semester";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(264, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(691, 428);
            this.dataGridView1.TabIndex = 61;
            // 
            // nametb
            // 
            this.nametb.Location = new System.Drawing.Point(86, 37);
            this.nametb.Name = "nametb";
            this.nametb.Size = new System.Drawing.Size(172, 20);
            this.nametb.TabIndex = 62;
            // 
            // vortb
            // 
            this.vortb.Location = new System.Drawing.Point(86, 83);
            this.vortb.Name = "vortb";
            this.vortb.Size = new System.Drawing.Size(172, 20);
            this.vortb.TabIndex = 63;
            // 
            // natiotb
            // 
            this.natiotb.Location = new System.Drawing.Point(86, 131);
            this.natiotb.Name = "natiotb";
            this.natiotb.Size = new System.Drawing.Size(172, 20);
            this.natiotb.TabIndex = 64;
            // 
            // semtb
            // 
            this.semtb.Location = new System.Drawing.Point(84, 188);
            this.semtb.Name = "semtb";
            this.semtb.Size = new System.Drawing.Size(174, 20);
            this.semtb.TabIndex = 65;
            // 
            // StudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 538);
            this.Controls.Add(this.semtb);
            this.Controls.Add(this.natiotb);
            this.Controls.Add(this.vortb);
            this.Controls.Add(this.nametb);
            this.Controls.Add(this.Vorname);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Semester);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Idlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Nationalitaet);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StudentInfo";
            this.Text = "Bewerbungszustand";
            this.Load += new System.EventHandler(this.StudentInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Vorname;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Nationalitaet;
        private System.Windows.Forms.Label Idlabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Semester;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox nametb;
        private System.Windows.Forms.TextBox vortb;
        private System.Windows.Forms.TextBox natiotb;
        private System.Windows.Forms.TextBox semtb;
    }
}