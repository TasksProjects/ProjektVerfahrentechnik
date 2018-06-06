using DataManagerSystem.Configs;
using DataManagerSystem.VerwaltungStudentenInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class StudentInfo : Form
    {
        Bewerbungsdata bd = new Bewerbungsdata();
        StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
        public StudentInfo(Bewerbungsdata bewerbungsdata)
        {
            bd = bewerbungsdata;
            InitializeComponent();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            nametb.Text = bd.Name;
            Idlabel.Text = bd.ID.ToString();
            vortb.Text = bd.Vorname;
            natiotb.Text = bd.Nationalitaet;
            semtb.Text = bd.Semester;
            studentenVerwaltung.Show_Database(dataGridView1,bd.ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
        }
    }
}
