using DataManagerSystem.Configs;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class EditPerson : Form
    {
        Bewerbungsdata bd = new Bewerbungsdata();
        private ConfigData config = new ConfigData();
        DatabaseManager databaseManager = new DatabaseManager();
        string[] geschlecht;

        public EditPerson(Bewerbungsdata bewerbung)
        {
            InitializeComponent();
            bd = bewerbung;
            geschlecht = new string[2];
            geschlecht[0] = "Männlich";
            geschlecht[1] = "Weiblich";
             
            InitField(bewerbung);

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
                MessageBox.Show("config file not found!");
            }
        }

        private void InitField(Bewerbungsdata data)
        {
            VornameTextbox.Text = data.Vorname.Trim();
            NameTextbox.Text = data.Name.Trim();

            MannlichRB.Checked = (data.Geschlecht == geschlecht[0]) ? true : false;
            WeiblichRB.Checked = (data.Geschlecht == geschlecht[1]) ? true : false;

            NationalitaetCB.Text = data.Nationalitaet.Trim();
            StudiengangCB.Text = data.Studiengang.Trim();
            StudienlandCB.Text = data.Studienland.Trim();
            HochschuleCB.Text = data.Hochschule.Trim();
            CpTB.Text = data.Creditpunkte.Trim();
            NoteVorläufigcheckBox.Checked = (data.NoteVorlaeufig) ? true : false;
            NoteTB.Text = data.Note.Trim();
            MasterstudiengangCB.Text = data.Masterstudiengang.Trim();
            MasterstudiengangCB2.Text = data.Masterstudiengang_2.Trim();
            MasterstudiengangCB3.Text = data.Masterstudiengang_3.Trim();
            SemesterCB.Text = data.Semester.Trim();
            KommentarTB.Text = data.Comment.Trim();
            ZusatzTB.Text = data.Zusatz.Trim();
            AblehnungsgrungTB.Text = data.Ablehnungsgrund.Trim();
            AngenommencheckBox.Checked = (data.Angenommen) ? true : false;
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
                NationalitaetCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Nationalität with Database
        private void AutoCompleteText_Nationalitaet()
        {
            NationalitaetCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            NationalitaetCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            NationalitaetCB.AutoCompleteCustomSource = coll;
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
                StudienlandCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Land with Database
        private void AutoCompleteText_Land()
        {
            StudienlandCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StudienlandCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            StudienlandCB.AutoCompleteCustomSource = coll;
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
                HochschuleCB.Items.Add(sName);
            }
            UserConnection1.Close();
        }

        // fill the ComboBox Hochschule with Database
        private void AutoCompleteText_Hochschule()
        {
            HochschuleCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            HochschuleCB.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            HochschuleCB.AutoCompleteCustomSource = coll;
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

        //Load Hochschule in MasterStudiengangComboBox
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

        private void SemesterBtn_Click(object sender, EventArgs e)
        {
            Add_Semester add_Semester = new Add_Semester();
            add_Semester.Show();
        }
       


        public void Save_Bewerbung(int id)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            bd.Vorname = VornameTextbox.Text.Trim();
            bd.Name = NameTextbox.Text.Trim();
            bd.Nationalitaet = NationalitaetCB.Text.Trim();
            bd.Note = NoteTB.Text.Trim();
            bd.NoteVorlaeufig = (NoteVorläufigcheckBox.Checked == true) ? true : false;
            bd.Studiengang = StudiengangCB.Text.Trim();
            bd.Studienland = StudienlandCB.Text.Trim();
            bd.Masterstudiengang = MasterstudiengangCB.Text.Trim();
            bd.Masterstudiengang_2 = MasterstudiengangCB2.Text.Trim();
            bd.Masterstudiengang_3 = MasterstudiengangCB3.Text.Trim();
            bd.Hochschule = HochschuleCB.Text.Trim();
            bd.Creditpunkte = CpTB.Text.Trim();
            bd.Ablehnungsgrund = AblehnungsgrungTB.Text.Trim();
            bd.Comment = KommentarTB.Text.Trim();
            bd.Zusatz = ZusatzTB.Text.Trim();
            bd.Angenommen = (AngenommencheckBox.Checked == true) ? true : false;
          
            int nationalitaetID = Search_NationalitaetID(NationalitaetCB.Text.Trim());
            int masterstudiengangID = Search_ID_Masterstudiengang(MasterstudiengangCB.Text.Trim());
            int masterstudiengang2ID = Search_ID_Masterstudiengang(MasterstudiengangCB2.Text.Trim());
            int masterstudiengang3ID = Search_ID_Masterstudiengang(MasterstudiengangCB3.Text.Trim());
            int semesterID = Search_ID_Smester(SemesterCB.Text.Trim());
            int hochschuleID = Seach_ID_Hochschule(bd.Hochschule);
            int studiengangID = Seach_ID_Studiengang(bd.Studiengang);
            int studienlandID = Seach_ID_Studienland(bd.Studienland);

            double note = 0;
            int CP = 0;

            int anprof = (bd.Prof) ? 1 : 0;
            int verwaltung = (bd.Verwaltung) ? 1 : 0;
            int vorlaeufig = (bd.NoteVorlaeufig) ? 1 : 0;
            int angenommen = (bd.Angenommen) ? 1 : 0;

            if (double.TryParse(bd.Note, out note) && int.TryParse(CpTB.Text.Trim(), out CP))
            {
                string query = "UPDATE [tab_bewerbung] SET [Vorname]='" + bd.Vorname + "', [Name]='" + bd.Name + "', [Geschlecht]='" + bd.Geschlecht + "'," +
                    " [Nationalitaet]='" + nationalitaetID + "', [Studienland]='" + studienlandID + "', [Studiengang]='" + studiengangID + "'," +
                    " [Hochschule]='" + hochschuleID + "', [Creditpunkt]='" + CP + "', [NoteVorlaeufig]='" + vorlaeufig + "', [Note] ='" + note + "'," +
                    " [Masterstudiengang]='" + masterstudiengangID + "', [Masterstudiengang2]='" + masterstudiengang2ID + "'," +
                    " [Masterstudiengang3]='" + masterstudiengang3ID + "', [Semester]='" + semesterID + "', [Kommentar]='" + bd.Comment + "'," +
                    " [Zusatz] ='" + bd.Zusatz + "', [Ablehnungsgrund] ='" + bd.Ablehnungsgrund + "', [AnProf]='" + anprof + "', [Verwaltung]='" + verwaltung + "'," +
                    " [Angenommen] ='" + angenommen + "' WHERE ID=" + id + "";


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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Check Note- and CredikPunkt Fields, wrong input Format!");
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

        private int Search_NationalitaetID(string nationalitaet)
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

        private void MannlichRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bd.Geschlecht = geschlecht[0];
        }

        private void WeiblichRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bd.Geschlecht = geschlecht[1];
        }      

        private void NationalitaetHinzufügenBtn_Click(object sender, EventArgs e)
        {
            Add_Land add_Land = new Add_Land(NationalitaetCB.Text);
            add_Land.Show();
        }

        private void StudiengangHinzufügenBtn_Click(object sender, EventArgs e)
        {       
            StudiengangUI studiengangUI = new StudiengangUI(StudiengangCB.Text);
            studiengangUI.Show();          
        }

        private void HochschuleHinzufügenBtn_Click(object sender, EventArgs e)
        {
            Add_Hochschule add_Hochschule = new Add_Hochschule(HochschuleCB.Text.Trim());
            add_Hochschule.Show();
        }

        private void SemesterHinzufügenBtn_Click(object sender, EventArgs e)
        {
            Add_Semester add_Semester = new Add_Semester();
            add_Semester.Show();
        }

        private void SpeicherBtn_Click(object sender, EventArgs e)
        {
            if (VornameTextbox.Text != string.Empty && NameTextbox.Text != string.Empty && NationalitaetCB.Text != string.Empty && StudienlandCB.Text != string.Empty
               && HochschuleCB.Text != string.Empty && StudiengangCB.Text != string.Empty && CpTB.Text != string.Empty && MasterstudiengangCB.Text != string.Empty && SemesterCB.Text != string.Empty && (MannlichRB.Checked || WeiblichRB.Checked))
            {
                Save_Bewerbung(bd.ID);
            }
            else
            {
                MessageBox.Show("Please fill all the fields!");
            }
        }

        private void AbbrechenBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
        }

        private void EditPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            BewerbungUI bewerbungUI = new BewerbungUI();
            bewerbungUI.Show();
        }
    }
}
