using DataManagerSystem.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.VerwaltungStudentenInfo
{
    public class StudentenVerwaltung
    {
        public ConfigData config = new ConfigData();
        List<FachCpDelta> listeFach = new List<FachCpDelta>();
        List<FehlendeCPInfo> listeFehlCP = new List<FehlendeCPInfo>();
        //StudiengaangAndNote[] listeFach = new StudiengaangAndNote[10];
        //FehlendeCPInfo[] listeFehlCP = new FehlendeCPInfo[10];
        // return the nationality 
        public string Search_Nationalitaet(int nationalitaetID)
        {

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtNationalität FROM tab_land where ID = " + nationalitaetID + "";

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
                string resultat = reader["txtNationalität"].ToString();
                UserConnection1.Close();
                return resultat;


            }

            else
            {
                UserConnection1.Close();
                return null;
            }
        }

        // function to search a Semester in database
        public string Search_ID_Smester(int SemesterID)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT txtSemester FROM tab_semester where Id = " + SemesterID + "";

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
                string resultat = reader["txtSemester"].ToString();
                UserConnection1.Close();
                return resultat;


            }

            else
            {
                UserConnection1.Close();
                return null;
            }
        }



        // Anzeige der Informationen des Studenten
        public void ShowStudentenInfo(DataGridView grid, int BewerbungsID)
        {
            try
            {
                /*t.txtTitel AS Titel, tab_titel AS t, WHERE t.ID = b.intTitel */
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query1 = "SELECT t.intBewerbung AS BewerbungsID, t.Masterstudiengang_1 AS Masterstudiengang_1, t.Masterstudiengang_2 AS Masterstudiengang_2, t.Masterstudiengang_3 AS Masterstudiengang_3, t.datDatum AS Datum, t.txtBenutzer AS txtBenutzer" +
                                "FROM tab_status AS t WHERE t.intBewerbung = " + BewerbungsID + "";

                string query = "SELECT intBewerbung AS BewerbungID, Masterstudiengang_1 AS Masterstudiengang1, Masterstudiengang_2 AS Masterstudiengang2, Masterstudiengang_3 AS Masterstudiengang3, datDatum AS Datum, txtBenutzer AS Benutzer " +
                                "FROM tab_status AS t WHERE t.intBewerbung = " + BewerbungsID + "";



                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;
                cmd.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;

                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        // Noten Suchen
        public List<FachCpDelta> ShowStudiengangNoten(string MastStudiengang)
        {


            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int ID = ShowMasterstudiengangID(MastStudiengang);

            string query = "SELECT t.ID, t.intStudiengang, t.intCP, t.txtFach FROM tab_cpdelta AS t WHERE t.intStudiengang = " + ID + "";

            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                FachCpDelta studiengaangAndNote = new FachCpDelta();
                string Fach = reader["txtFach"].ToString();
                studiengaangAndNote.Fach = Fach;
                string studiengangID = reader["intStudiengang"].ToString();
                int StudiengangID = Convert.ToInt32(studiengangID);
                studiengaangAndNote.StudiengangID = StudiengangID;
                string Fachid = reader["ID"].ToString();
                int FachID = Convert.ToInt32(Fachid);
                studiengaangAndNote.FachID = FachID;
                string intCP = reader["intCP"].ToString();
                int IntCP = Convert.ToInt32(intCP);
                studiengaangAndNote.IntCP = IntCP;
                listeFach.Add(studiengaangAndNote);
            }
            UserConnection1.Close();

            return listeFach;
        }

        //  MasterstudiengangID anzeigen
        public int ShowMasterstudiengangID(string Studiengang)
        {

            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            string query = "SELECT ID FROM tab_masterstudiengang where txtName = '" + Studiengang + "'";

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
                return 0;
            }
        }

        // Check if  the BewerbungIDin tab_fehltcp exist
        public bool Search_BewerbungID_in_tab_FehlCP(int bewerbungsID, int Masterstudiengang, int cpdelta)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int count = 0;

            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT intBewerbung FROM tab_fehlcp where intBewerbung = " + bewerbungsID + " AND intStudiengang = " + Masterstudiengang + " AND intCPdelta = " + cpdelta + "";
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }

            LoginConnection.Close();

            // Test if the given username exists in the database
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check if  the BewerbungIDin tab_fehltcp exist
        public bool Search_BewerbungID_in_tab_FehlCP1(int bewerbungsID, int Masterstudiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int count = 0;

            OleDbConnection LoginConnection = new OleDbConnection();
            LoginConnection.ConnectionString = config.DbConnectionString;
            LoginConnection.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = LoginConnection;
            cmd.CommandText = "SELECT intBewerbung FROM tab_fehlcp where intBewerbung = " + bewerbungsID + " AND intStudiengang = " + Masterstudiengang + "";
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count++;
            }

            LoginConnection.Close();

            // Test if the given username exists in the database
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // Fehlende CP in tab_fehlcp suchen
        public List<FehlendeCPInfo> ShowStudiengangFehlendeCP(int bewerbungsID, int MasterID)
        {


            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "SELECT t.intCPdelta, t.intWert, t.intBewerbung, t.intStudiengang, t.blnErfüllt  FROM tab_fehlcp AS t WHERE t.intBewerbung = " + bewerbungsID + " AND t.intStudiengang = " + MasterID + "";


            OleDbConnection UserConnection1 = new OleDbConnection();
            UserConnection1.ConnectionString = config.DbConnectionString;
            UserConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = UserConnection1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = query;
            OleDbDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                FehlendeCPInfo fehlendeCPInfo = new FehlendeCPInfo();
                string intCPdelta = reader["intCPdelta"].ToString();
                int IntCPdelta = Convert.ToInt32(intCPdelta);
                fehlendeCPInfo.IntCPdelta = IntCPdelta;

                string fehlCP = reader["intWert"].ToString();
                int FehlCP = Convert.ToInt32(fehlCP);
                fehlendeCPInfo.FehlCP = FehlCP;

                string intBewerbung = reader["intBewerbung"].ToString();
                int IntBewerbung = Convert.ToInt32(intBewerbung);
                fehlendeCPInfo.IntBewerbungID = IntBewerbung;

                string cpErfuellt = reader["blnErfüllt"].ToString();
                bool CPErfuellt = Convert.ToBoolean(cpErfuellt);
                fehlendeCPInfo.Erfuelle = CPErfuellt;

                string intStudiengang = reader["intStudiengang"].ToString();
                int IntStudiengang = Convert.ToInt32(intStudiengang);
                fehlendeCPInfo.IntStudiengang = IntStudiengang;


                listeFehlCP.Add(fehlendeCPInfo);
            }
            UserConnection1.Close();

            return listeFehlCP;
        }




        // Function to add FehlendeCp in the database
        public void AddFehlendeCP(int bewerbungid, int IntCPdelta, int FehlCP, int Studiengang, int valueOfErfuellt)
        {

            // check if the username already exist and return his value
            Boolean response = Search_BewerbungID_in_tab_FehlCP(bewerbungid, Studiengang, IntCPdelta);
            if (response == false)
            {

                config = XmlDataManager.XmlConfigDataReader("configs.xml");


                string query = "insert into  tab_fehlcp ([intCPdelta],[intWert],[intBewerbung],[intStudiengang],[blnErfüllt]) values ('" + IntCPdelta + "','" + FehlCP + "','" + bewerbungid + "','" + Studiengang + "','" + valueOfErfuellt + "')";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

            }
            else
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query = "Update  tab_fehlcp set [intWert] = '" + FehlCP + "', [blnErfüllt] = '" + valueOfErfuellt + "'  where intCPdelta = " + IntCPdelta + " and intBewerbung = " + bewerbungid + " and intStudiengang = " + Studiengang + " ";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }



        // Function to einstufen
        public void Einstufen(int bewerbungid, string benutzer, string masterstudiengang, string masterstudiengang2, string masterstudiengang3)
        {
            
            


            config = XmlDataManager.XmlConfigDataReader("configs.xml");


            string query = "insert into  tab_status ([intBewerbung],[datDatum],[txtBenutzer],[Masterstudiengang_1],[Masterstudiengang_2],[Masterstudiengang_3]) values ('" + bewerbungid + "','" + DateTime.Now + "','" + benutzer + "','" + masterstudiengang + "','" + masterstudiengang2 + "', '" + masterstudiengang3 + "')";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }



        public void Show_Database(DataGridView grid, int ID)
        {
            try
            {
                config = XmlDataManager.XmlConfigDataReader("configs.xml");
                string query = "SELECT t.intBewerbung AS BewerbungsID, t.datDatum AS Datum, t.txtBenutzer AS Benutzer, t.Masterstudiengang_1, t.Masterstudiengang_2, t.Masterstudiengang_3 FROM tab_status AS t WHERE t.intBewerbung = " + ID + " ";

                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;
                cmd.CommandText = query;


                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;

                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }
}