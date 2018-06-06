using DataManagerSystem.Configs;
using DataManagerSystem.Modules;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem
{
    public partial class MainWindow : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        ConfigData config = new ConfigData();
        SettingsUI settingUI = new SettingsUI();
       
        public MainWindow( string benutzerName, string status)
        {
            InitializeComponent();
            labelStatus.Text = status;

            //display the time
            timer1.Start();
        }

        // Disconect the user
        private void LogoutButton_Click(object sender, EventArgs e)
        {                   
            Application.Exit();    
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            settingUI.Show();
        }

        //Exit Program
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
     
        private void AddButton_Click(object sender, EventArgs e)
        {
            NewStudentUI newStudentUI = new NewStudentUI();
            newStudentUI.Show();
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI();
            adminUI.Show();
        }

        private void ShowDbButton_Click(object sender, EventArgs e)
        {
            BewerbungUI bewerbungUI = new BewerbungUI();            
            bewerbungUI.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.labelTime.Text = dateTime.ToString();
        }

        private void StudiengangButton_Click(object sender, EventArgs e)
        {
            StudiengangUI studiengangUI = new StudiengangUI(string.Empty);
            studiengangUI.Show();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void EditButton_Click(object sender, EventArgs e)
        {
            UebersichtBetreuer uebersichtBetreuer = new UebersichtBetreuer();
            uebersichtBetreuer.Show();
        }

        private void Helpbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
