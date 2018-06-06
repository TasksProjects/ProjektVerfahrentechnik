﻿using DataManagerSystem.Configs;
using System;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditUserUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        ConfigData config = new ConfigData();

        public EditUserUI()
        {
            InitializeComponent();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            AdminUI adminUI = new AdminUI();
            this.Close();
            adminUI.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
           if(!UserIdTextBox.Text.Trim().Equals(string.Empty) && !UsernameTextBox.Text.Trim().Equals(string.Empty) && !PasswordTextBox.Text.Trim().Equals(string.Empty) && !AttributComboBox.Text.Trim().Equals(string.Empty))
           {                      
                int id = Convert.ToInt32(UserIdTextBox.Text);
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;
                string attribut = AttributComboBox.Text;
                databaseManager.EditUser(id, username, password, attribut);

                UserIdTextBox.Clear();
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();                      
           }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }
    }
}
