﻿using DataManagerSystem.Configs;
using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class AdminUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        OleDbConnection UserConnection = new OleDbConnection();
        UserData userData = new UserData();
       

        public AdminUI()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AdminUI_Load(object sender, EventArgs e)
        {
            userData = XmlDataManager.XmlUserDataReader("userdata.xml");
            UsernameLabel.Text = userData.Username;
            Atrributlabel.Text = userData.UserAttribut;

            if(userData.UserAttribut == "SuperAdmin")
            {
                databaseManager.ShowDatabase(UserDataGrid);
            }
            else
            {
                ControlPanel.Enabled = false;
                UserDataGrid.BackgroundColor = System.Drawing.Color.Gray;
                AddUserButton.BackColor = System.Drawing.Color.Gray;
                EditUserButton.BackColor = System.Drawing.Color.Gray;
                RemoveUserButton.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            EditAccountUI editAccountUI = new EditAccountUI();
            editAccountUI.Show();
            this.Close();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserUI addUserUI = new AddUserUI();
            this.Close();
            addUserUI.Show();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            EditUserUI editUserUI = new EditUserUI();
            this.Close();
            editUserUI.Show();
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            RemoveUserUI removeUserUI = new RemoveUserUI();
            this.Close();
            removeUserUI.Show();
        }

        private void UpdateViewBtn_Click(object sender, EventArgs e)
        {
            databaseManager.ShowDatabase(UserDataGrid);
        }
    }
}
