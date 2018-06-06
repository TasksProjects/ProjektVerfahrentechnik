using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class StudiengangUI : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        private ConfigData config = new ConfigData();
        
        public StudiengangUI()
        {
            InitializeComponent();
            Load_Hochschule_Database();
            AutoCompleteText_Hochschule();
        }

        public StudiengangUI(string StudiengangName)
        {
            InitializeComponent();
            StudyTextBox.Text = StudiengangName;
            Load_Hochschule_Database();
            AutoCompleteText_Hochschule();
        }

        private void StudiengangUI_Load(object sender, EventArgs e)
        {
            if (File.Exists("configs.xml"))
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");      
            }
            else
            {
                MessageBox.Show("no config xml file!");
            }

            Show_Database();
        }

        private void Load_Hochschule_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_hochschule";

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
                HochschuleComboBox.Items.Add(sName);
            }
        }

        // fill the ComboBox Hochschule with Database
        private void AutoCompleteText_Hochschule()
        {
            HochschuleComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HochschuleComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_hochschule";

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
                    string HochschuleName = reader["txtName"].ToString();
                    coll.Add(HochschuleName);
                    //HochschuleComboBox.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            HochschuleComboBox.AutoCompleteCustomSource = coll;
        }
       
        // function to search a hochschule's id
        public int Search_Hochschule_ID(string hochschuleName)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_hochschule where txtName = '" + hochschuleName + "' ";

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

            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                int id = Convert.ToInt32(resultat);
                UserConnection1.Close();
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }    
        }

        //function to search a title's id
        public int Search_Title_ID(string titel)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_titel where txtTitel = '" + titel + "' ";

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

            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                int id = Convert.ToInt32(resultat);
                UserConnection1.Close();
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        private int Search_Stadt_ID(string stadt)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_stadt where txtName = '" + stadt + "' ";

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

            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                int id = Convert.ToInt32(resultat);
                UserConnection1.Close();
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        private int Search_Land_ID(string land)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_land where txtName = '" + land + "' ";

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

            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                int id = Convert.ToInt32(resultat);
                UserConnection1.Close();
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // Function to add a new studiengang
        public void Add_Studiengang(int HochschuleID, int titel)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int check_CPErsatz;
            if(checkBox1.Checked == true)
            {
                check_CPErsatz = 1;
            }
            else
            {
            
                check_CPErsatz = 0;
            }

            string query = "insert into  tab_studiengang ([txtName],[intHochschule],[intRegelstudienzeit],[intCredits],[intTitel],[blnCPErsatz])" +
                          " values ('" + StudyTextBox.Text.Trim() + "','" + HochschuleID + "', '" + numericUpDown2.Value + "'," +
                          "'" + numericUpDown1.Value + "','" + titel + "','" + check_CPErsatz + "')";
            OleDbConnection UserConnection = new OleDbConnection();
            UserConnection.ConnectionString = config.DbConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = UserConnection;
            UserConnection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved Successful");
                UserConnection.Close();
                Show_Database();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void Show_Database()
        {
            try
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");

                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;
                cmd.CommandText = "SELECT tab_studiengang.ID AS ID , tab_studiengang.txtName AS Studiengang , tab_hochschule.txtName AS Hochschule," +
                    " tab_studiengang.intRegelstudienzeit AS Regelstudienzeit, tab_hochschule.Hochschulestadt As Hochschulestadt, t.txtName As Land," +
                                  " tab_studiengang.intCredits AS Credit,tab_titel.txtTitel AS Titel, tab_studiengang.blnCPErsatz AS CPErsatz  " +
                                  "FROM tab_studiengang, tab_land AS t, tab_hochschule, tab_titel " +
                                  "WHERE tab_studiengang.intHochschule = tab_hochschule.ID AND t.ID = tab_hochschule.intLand AND tab_studiengang.intTitel = tab_titel.ID ORDER BY tab_studiengang.ID ";


                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                StudiengangGridView.DataSource = dt;
                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!(StudyTextBox.Text.Trim().Equals(string.Empty)) && !(HochschuleComboBox.Equals(string.Empty)) && !(TitelComboBox.Text.Trim().Equals(string.Empty)))
            {
                int ID_Hochschule = Search_Hochschule_ID(HochschuleComboBox.Text.Trim());
                int ID_titel = Search_Title_ID(TitelComboBox.Text.Trim());

                if (ID_Hochschule != 0 && ID_Hochschule != -1 && ID_titel != 0 && ID_titel != -1)
                {
                    Add_Studiengang(ID_Hochschule, ID_titel);
                }
                else if (ID_Hochschule == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Diese Hochschule existiert nicht druck Ok um sie anzulegen", "confirmation", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        Add_Hochschule add_Hochschule = new Add_Hochschule(HochschuleComboBox.Text);
                        add_Hochschule.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all the field!");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Show_Database();
        }
    }
}
