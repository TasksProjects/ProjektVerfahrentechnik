﻿using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class Add_Hochschule : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        private ConfigData config = new ConfigData();

        public Add_Hochschule(string hochschuleName)
        {
            InitializeComponent();
            NameTextBox.Text = hochschuleName;
            AutoCompleteText_Land();
            AutoCompleteText_Stadt();
            Load_Stadt_Database();
            Load_Hochschule_Land_Database();           
        }

        private void Load_Stadt_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT Hochschulestadt FROM tab_hochschule";

            OleDbConnection UserConnection1 = new OleDbConnection
            {
                ConnectionString = config.DbConnectionString
            };
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand
            {
                Connection = UserConnection1,
                CommandType = CommandType.Text,
                CommandText = query
            };
            OleDbDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string sName = reader["Hochschulestadt"].ToString();
                Stadt_CB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        private void AutoCompleteText_Stadt()
        {
            Stadt_CB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Stadt_CB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT Hochschulestadt FROM tab_hochschule";

            OleDbConnection UserConnection1 = new OleDbConnection
            {
                ConnectionString = config.DbConnectionString
            };
            try
            {
                UserConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand
                {
                    Connection = UserConnection1,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                OleDbDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    string LandName = reader["Hochschulestadt"].ToString();
                    coll.Add(LandName);
                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Stadt_CB.AutoCompleteCustomSource = coll;
        }

        private void Add_Hochschule_Load(object sender, EventArgs e)
        {
            if (File.Exists("configs.xml"))
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
            }
            else
            {
                MessageBox.Show("no config xml file!");
            }
        }

        private void Load_Hochschule_Land_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_land";

            OleDbConnection UserConnection1 = new OleDbConnection
            {
                ConnectionString = config.DbConnectionString
            };
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand
            {
                Connection = UserConnection1,
                CommandType = CommandType.Text,
                CommandText = query
            };
            OleDbDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string sName = reader["txtName"].ToString();
                LandComboBox.Items.Add(sName);
            }
        }

        //fill the ComboBox Hochschule with Database
        private void AutoCompleteText_Land()
        {
            LandComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            LandComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_land";

            OleDbConnection UserConnection1 = new OleDbConnection
            {
                ConnectionString = config.DbConnectionString
            };
            try
            {
                UserConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand
                {
                    Connection = UserConnection1,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                OleDbDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    string LandName = reader["txtName"].ToString();
                    coll.Add(LandName);                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LandComboBox.AutoCompleteCustomSource = coll;
        }
     
        public int Search_Land_ID(string LandName)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_land where txtName = '" + LandName + "' ";

            OleDbConnection LandConnection1 = new OleDbConnection();
            LandConnection1.ConnectionString = config.DbConnectionString;
            LandConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand
            {
                Connection = LandConnection1,
                CommandType = CommandType.Text,
                CommandText = query
            };
            OleDbDataReader reader = cmd1.ExecuteReader();

            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                int id = Convert.ToInt32(resultat);
                LandConnection1.Close();
                return id;
            }
            else
            {
                LandConnection1.Close();
                return 0;             
            }
        }

        public void AddHochschule(int Land_ID)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "insert into  tab_hochschule ([txtName],[intLand],[Hochschulestadt])" +
                          " values ('" + NameTextBox.Text.Trim() + "','" +  Land_ID + "','" + Stadt_CB.Text.Trim() + "')";
            OleDbConnection UserConnection = new OleDbConnection();
            UserConnection.ConnectionString = config.DbConnectionString;

            OleDbCommand cmd = new OleDbCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = UserConnection
            };
            UserConnection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved Successful");
                UserConnection.Close();      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!NameTextBox.Text.Trim().Equals(string.Empty) && !LandComboBox.Text.Trim().Equals(string.Empty) && !Stadt_CB.Text.Trim().Equals(string.Empty))
            {
                int ID_Land = Search_Land_ID(LandComboBox.Text.Trim());
                if (ID_Land != 0 && ID_Land != -1)
                {
                    AddHochschule(ID_Land);
                }
                else if (ID_Land == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Land doesn't exist! Please click Ok to add a new Land!", "confirmation", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        Add_Land add_Land = new Add_Land(LandComboBox.Text);
                        this.Close();
                        add_Land.Show();            
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Please Fill all the field!");
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
