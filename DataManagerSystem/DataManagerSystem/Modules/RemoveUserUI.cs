using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class RemoveUserUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        ConfigData config = new ConfigData();

        public RemoveUserUI()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (!UserIDTextBox.Text.Trim().Equals(string.Empty))
            {
                int id = Convert.ToInt32(UserIDTextBox.Text);
                databaseManager.RemoveUser(id);
                this.Close();

                AdminUI adminUI = new AdminUI();
                adminUI.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the field!");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI();
            this.Close();
            adminUI.Show();
        }
    }
}
