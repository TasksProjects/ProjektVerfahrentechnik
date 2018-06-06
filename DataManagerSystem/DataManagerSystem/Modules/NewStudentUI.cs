using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;


namespace DataManagerSystem.Modules
{
    public partial class NewStudentUI : Form
    {
        private ConfigData config = new ConfigData();
        DatabaseManager databaseManager = new DatabaseManager();
        private Bewerbungsdata bd = new Bewerbungsdata(); //bewerbungsdata
        string[] geschlecht; 

        public NewStudentUI()
        {   
            InitializeComponent();

            geschlecht = new string[2];
            geschlecht[0] = "Männlich";
            geschlecht[1] = "Weiblich";
            bd.Geschlecht = geschlecht[0];

            AutoCompleteText_Nationalitaet();
            Load_Nationalitaet_Database();
            AutoCompleteText_Land();
            Load_Land_Database();
            AutoCompleteText_Hochschule();
            Load_Hochschule_Database();
            AutoCompleteText_Studiengang();
            Load_Studiengang_Database();
            AutoCompleteText_Master_Studiengang();
            Load_Master_Studiengang_Database();
            AutoCompleteText_Vorname();
            AutoCompleteText_Name();
            Load_Semester_Database();
            AutoCompleteText_Semester();
        }

        private void NewStudentUI_Load(object sender, EventArgs e)
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
 
        

        //Load Nationalität in NationalitätComboBox
        private void Load_Nationalitaet_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtNationalität FROM tab_land";

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
                string sName = reader["txtNationalität"].ToString();
                NationalityTB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Nationalität with Database
        private void AutoCompleteText_Nationalitaet()
        {
            NationalityTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NationalityTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtNationalität FROM tab_land";

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
                    string Nationalitaet = reader["txtNationalität"].ToString();
                    coll.Add(Nationalitaet);
          
                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NationalityTB.AutoCompleteCustomSource = coll;
        }

        //Load Land in LandComboBox
        private void Load_Land_Database()
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
                StudienLandCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Land with Database
        private void AutoCompleteText_Land()
        {
            StudienLandCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudienLandCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StudienLandCB.AutoCompleteCustomSource = coll;
        }

        //Load Hochschule in HochschuleComboBox
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
                HochshuleCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Hochschule with Database
        private void AutoCompleteText_Hochschule()
        {
            HochshuleCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HochshuleCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            HochshuleCB.AutoCompleteCustomSource = coll;
        }

        //Load Hochschule in StudiengangComboBox
        private void Load_Studiengang_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_studiengang";

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
                StudiengangCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Studiengang with Database
        private void AutoCompleteText_Studiengang()
        {
            StudiengangCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudiengangCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_studiengang";

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
                    string StudiengangName = reader["txtName"].ToString();
                    coll.Add(StudiengangName);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StudiengangCB.AutoCompleteCustomSource = coll;
        }

        //Load Masterstudiengang in MasterStudiengangComboBox
        private void Load_Master_Studiengang_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_masterstudiengang";

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
                MasterstudiengangCB.Items.Add(sName);
                MasterstudiengangCB2.Items.Add(sName);
                MasterstudiengangCB3.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Master_Studiengang with Database
        private void AutoCompleteText_Master_Studiengang()
        {
            MasterstudiengangCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MasterstudiengangCB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangCB2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MasterstudiengangCB3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MasterstudiengangCB3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtName FROM tab_masterstudiengang";

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
                    string MasterStudiengangName = reader["txtName"].ToString();
                    coll.Add(MasterStudiengangName);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MasterstudiengangCB.AutoCompleteCustomSource = coll;
            MasterstudiengangCB2.AutoCompleteCustomSource = coll;
            MasterstudiengangCB3.AutoCompleteCustomSource = coll;
        }

        // fill the textbox Vorname with Database
        private void AutoCompleteText_Vorname()
        {
            FirstnameTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            FirstnameTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT Vorname FROM tab_bewerbung";

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
                    string Vorname = reader["Vorname"].ToString();
                    coll.Add(Vorname);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FirstnameTB.AutoCompleteCustomSource = coll;
        }

        // fill the textbox Name with Database
        private void AutoCompleteText_Name()
        {
            NameTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NameTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT Name FROM tab_bewerbung";

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
                    string Name = reader["Name"].ToString();
                    coll.Add(Name);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NameTB.AutoCompleteCustomSource = coll;
        }

        //Load Semester in SemesterComboBox
        private void Load_Semester_Database()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtSemester FROM tab_semester";

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
                string sName = reader["txtSemester"].ToString();
                SemesterCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Semester with Database
        private void AutoCompleteText_Semester()
        {
            SemesterCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SemesterCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtSemester FROM tab_semester";

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
                    string Semester = reader["txtSemester"].ToString();
                    coll.Add(Semester);

                }
                UserConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SemesterCB.AutoCompleteCustomSource = coll;
        }
      
       
        // return the nationality ID
        public int Search_NationalitaetID(string nationalitaet)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_land where txtNationalität = '" + nationalitaet + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();

            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // return the studiengang ID
        public int Search_StudiengangID(string studiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_studiengang where txtName = '" + studiengang + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        //Search after Studiengang id
        private int Seach_ID_Studiengang(string str)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_studiengang where txtName = '" + str + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        //Search after Hochschule id
        private int Seach_ID_Hochschule(string str)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_hochschule where txtName = '" + str + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // function to search a Masterstudiengang_ID in database
        private int Search_ID_Masterstudiengang(string Masterstudiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_masterstudiengang where txtName = '" + Masterstudiengang + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)

            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }

            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        // function to search a Semester_ID in database
        private int Search_ID_Smester(string Semester)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT Id FROM tab_semester where txtSemester = '" + Semester + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        //Function to save Student's information
        public void Add_New_Bewerbung()
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            bd.Vorname = FirstnameTB.Text.Trim();
            bd.Name = NameTB.Text.Trim();
            bd.Nationalitaet = NationalityTB.Text.Trim();
            bd.Studienland = StudienLandCB.Text.Trim();
            bd.Note = AbschlussnoteTB.Text.Trim(); ;
            bd.NoteVorlaeufig = (NoteVorläufingCheckBox.Checked == true) ? true : false;
            bd.Studiengang = StudiengangCB.Text.Trim();
            bd.Masterstudiengang = MasterstudiengangCB.Text.Trim();
            bd.Masterstudiengang_2 = MasterstudiengangCB2.Text.Trim();
            bd.Masterstudiengang_3 = MasterstudiengangCB3.Text.Trim();
            bd.Hochschule = HochshuleCB.Text.Trim();
            bd.Creditpunkte = CpTB.Text.Trim();
            bd.Ablehnungsgrund = AblehnungsgrundTB.Text.Trim();
            bd.Comment = KommentarTB.Text.Trim();
            bd.Zusatz = ZusatzTB.Text.Trim();
            bd.Angenommen = (AngenommenCheckBox.Checked == true) ? true : false;
            bd.Prof = false;
            bd.Verwaltung = false;

            int nationalitaetID = Search_NationalitaetID(NationalityTB.Text.Trim());
            int masterstudiengangID = Search_ID_Masterstudiengang(MasterstudiengangCB.Text.Trim());
            int masterstudiengang2ID = Search_ID_Masterstudiengang(MasterstudiengangCB2.Text.Trim());
            int masterstudiengang3ID = Search_ID_Masterstudiengang(MasterstudiengangCB3.Text.Trim());
            int semesterID = Search_ID_Smester(SemesterCB.Text.Trim());
            int hochschuleID = Seach_ID_Hochschule(bd.Hochschule);
            int studiengangID = Seach_ID_Studiengang(bd.Studiengang);
            int studienlandID = Seach_ID_Studienland(bd.Studienland);

            double note = 0;
            int CP = 0;

            int vorlaeufig = (bd.NoteVorlaeufig) ? 1 : 0;
            int angenommen = (bd.Angenommen) ? 1 : 0;

            if (double.TryParse(bd.Note, out note) && int.TryParse(CpTB.Text.Trim(), out CP))
            {
                string query = "insert into  tab_bewerbung([Vorname],[Name],[Geschlecht],[Nationalitaet],[Studienland],[Studiengang],[Hochschule],[Creditpunkt],[NoteVorlaeufig],[Note],[Masterstudiengang],[Masterstudiengang2],[Masterstudiengang3],[Semester],[Kommentar],[Zusatz],[Ablehnungsgrund],[AnProf],[Verwaltung],[Angenommen])" +
                    " values ('" + bd.Vorname + "','" + bd.Name + "','" + bd.Geschlecht + "','" + nationalitaetID + "', '"+studienlandID+"'," +
                    "'" + studiengangID + "','" + hochschuleID + "','" + CP + "', '" + vorlaeufig + "', '" + note + "', '" + masterstudiengangID + "','" + masterstudiengang2ID + "','" + masterstudiengang3ID + "','" + semesterID + "','" + bd.Comment + "','" + bd.Zusatz + "','" + bd.Ablehnungsgrund + "','" + 0 + "','" + 0 + "','" + angenommen + "' )";
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
                    UserConnection.Close();
                    MessageBox.Show("Data Saved Sucessfully!");
                    SubmitField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Check Note- and CredikPunkt Fields, Format Match error!");
            }
        }

        private int Seach_ID_Studienland(string land)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_land where txtName = '" + land + "'";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string resultat = reader["ID"].ToString();
                UserConnection1.Close();
                int id = Convert.ToInt32(resultat);
                return id;
            }
            else
            {
                UserConnection1.Close();
                return 0;
            }
        }

        //submit fields
        private void SubmitField()
        {
            FirstnameTB.Text = string.Empty;
            NameTB.Text = string.Empty;
            MannlichRB.Checked = true;
            NationalityTB.Text = string.Empty;
            StudienLandCB.Text = string.Empty;
            HochshuleCB.Text = string.Empty;
            StudiengangCB.Text = string.Empty;
            AbschlussnoteTB.Text = string.Empty;
            CpTB.Text = string.Empty;
            MasterstudiengangCB.Text = string.Empty;
            MasterstudiengangCB2.Text = string.Empty;
            MasterstudiengangCB3.Text = string.Empty;
            KommentarTB.Text = string.Empty; 
            ZusatzTB.Text = string.Empty;
            Ablehnungsgrund.Text = string.Empty;
            SemesterCB.Text = string.Empty;
            AngenommenCheckBox.Checked = false;
            NoteVorläufingCheckBox.Checked = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FirstnameTB.Text != string.Empty && NameTB.Text != string.Empty && NationalityTB.Text != string.Empty && StudienLandCB.Text != string.Empty
               && HochshuleCB.Text != string.Empty && StudiengangCB.Text != string.Empty && AbschlussnoteTB.Text != string.Empty
               && CpTB.Text != string.Empty && MasterstudiengangCB.Text != string.Empty && SemesterCB.Text != string.Empty && (MannlichRB.Checked || WeiblichRB.Checked))
            {
                Add_New_Bewerbung();
            }
            else
            {
                MessageBox.Show("Please fill all the fields!");
            }
        }

        private void CanceledBtn_Click(object sender, EventArgs e)
        {
            BewerbungUI bewerbungUI = new BewerbungUI();
            this.Close();
            bewerbungUI.Show();
        }

        private void AddNationalitaetBtn_Click(object sender, EventArgs e)
        {
            Add_Land add_Land = new Add_Land(NationalityTB.Text);
            add_Land.Show();
        }

        private void AddHochschuleBtn_Click(object sender, EventArgs e)
        {
            Add_Hochschule add_Hochschule = new Add_Hochschule(HochshuleCB.Text);
            add_Hochschule.Show();
        }

        private void AddStudiengangBtn_Click(object sender, EventArgs e)
        {
            StudiengangUI studiengangUI = new StudiengangUI(StudiengangCB.Text);
            studiengangUI.Show();
        }

        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Add_Semester add_Semester = new Add_Semester();
            add_Semester.Show();
        }

        private void MannlichRB_CheckedChanged(object sender, EventArgs e)
        {
            bd.Geschlecht = geschlecht[0];
        }

        private void WeiblichRB_CheckedChanged(object sender, EventArgs e)
        {
            bd.Geschlecht = geschlecht[1];
        }

        private void NewStudentUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
        }
    }
}