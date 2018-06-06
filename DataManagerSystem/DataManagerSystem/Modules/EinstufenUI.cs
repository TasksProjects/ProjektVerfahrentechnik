using DataManagerSystem.Configs;
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
    public partial class EinstufenUI : Form
    {
        Bewerbungsdata bd = new Bewerbungsdata();
        public EinstufenUI(Bewerbungsdata bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void EinstufenUI_Load(object sender, EventArgs e)
        {
            IdLabel.Text = bd.ID.ToString();
            NameLabel.Text = bd.Name;
            VornameLabel.Text = bd.Vorname;
            MscLabel1.Text = bd.Masterstudiengang;
            MscLabel2.Text = bd.Masterstudiengang_2;
            MscLabel3.Text = bd.Masterstudiengang_3;
            bool checkMasterstudiengang = CheckStudiengang(MscLabel1.Text.Trim());
            if (checkMasterstudiengang == true)
            {
                EinstufenBtn1.Enabled = false;

            }

            bool checkMasterstudiengang2 = CheckStudiengang(MscLabel2.Text.Trim());
            if (checkMasterstudiengang2 == true)
            {
                EinstufenBtn2.Enabled = false;

            }

            bool checkMasterstudiengang3 = CheckStudiengang(MscLabel3.Text.Trim());

            if (checkMasterstudiengang3 == true)
            {
                EinstufenBtn3.Enabled = false;

            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            BewerbungUI bewerbungUI = new BewerbungUI();
            this.Close();
            bewerbungUI.Show();
        }

        private void EinstufenBtn1_Click(object sender, EventArgs e)
        {
            MscEinstufenUI mscEinstufenUI = new MscEinstufenUI(bd, 1);
            this.Close();
            mscEinstufenUI.Show();
        }

        private void EinstufenBtn2_Click(object sender, EventArgs e)
        {
            MscEinstufenUI mscEinstufenUI = new MscEinstufenUI(bd, 2);
            this.Close();
            mscEinstufenUI.Show();
        }

        private void EinstufenBtn3_Click(object sender, EventArgs e)
        {
            MscEinstufenUI mscEinstufenUI = new MscEinstufenUI(bd, 3);
            this.Close();
            mscEinstufenUI.Show();
        }
        private bool CheckStudiengang(string studiengang)
        {
            bool result = false;
            if(studiengang.Equals("Kein Masterstudiengang"))
            {
                result = true;
            }
            return result;
        }

    }
}
