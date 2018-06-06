using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using DataManagerSystem.Configs;
using DataManagerSystem.VerwaltungStudentenInfo;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DataManagerSystem.Modules
{
    public partial class BewerbungUI : Form
    {
        int summe;
        List<FehlendeCPInfo> fehlendeCPInfos = new List<FehlendeCPInfo>();
        Bewerbungsdata bd = new Bewerbungsdata();
        private ConfigData config = new ConfigData();
        bool checkExport = false;
        DataTable datatable;
        int bewerbungID;
        string filtertype = string.Empty;

        public BewerbungUI()
        {
            InitializeComponent();
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
        }

        private void BewerbungUI_Load(object sender, EventArgs e)
        {
            Show_Database();
        }

        private void Show_Database()
        {
            try
            {
                OleDbConnection UserConnection = new OleDbConnection();
                UserConnection.ConnectionString = config.DbConnectionString;

                UserConnection.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = UserConnection;

                string query = "SELECT b.ID, b.Vorname, b.Name, b.Geschlecht, k.txtNationalität AS Nationalitaet, c.txtName AS Studienland, d.txtName AS Studiengang, e.txtName AS Hochschule, " +
                     "b.Creditpunkt, b.NoteVorlaeufig, b.Note,f.txtName AS Masterstudiengang, h.txtName AS Masterstudiengang2, j.txtName AS Masterstudiengang3, s.txtSemester AS Semester, " +
                     "b.Kommentar, b.Zusatz, b.Ablehnungsgrund, b.AnProf, b.Verwaltung, b.Angenommen " +
                     "FROM tab_bewerbung AS b, tab_land AS c, tab_land AS k, tab_hochschule AS e, tab_studiengang AS d, tab_masterstudiengang AS f, tab_masterstudiengang AS h, " +
                     "tab_semester AS s, tab_masterstudiengang AS j " +
                     "Where c.ID = b.Nationalitaet AND K.ID = b.Studienland AND e.ID = b.Hochschule AND d.ID = b.Studiengang AND f.ID = b.Masterstudiengang " +
                     "AND s.ID = b.Semester AND h.ID = b.Masterstudiengang2 AND j.ID = b.Masterstudiengang3";


                cmd.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                datatable = new DataTable();
                da.Fill(datatable);
                dataGridView.DataSource = datatable;

                UserConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        public void GetBewerbungDataFromDataView(DataGridViewRow row)
        {
            bd.ID = bewerbungID;
            bd.Vorname = row.Cells["Vorname"].Value.ToString();
            bd.Name = row.Cells["Name"].Value.ToString();
            bd.Geschlecht = row.Cells["Geschlecht"].Value.ToString();
            bd.Nationalitaet = row.Cells["Nationalitaet"].Value.ToString();
            bd.Studienland = row.Cells["Studienland"].Value.ToString();

            bd.Studiengang = row.Cells["Studiengang"].Value.ToString();
            bd.Hochschule = row.Cells["Hochschule"].Value.ToString();
            bd.Creditpunkte = row.Cells["Creditpunkt"].Value.ToString();
            bd.NoteVorlaeufig = (bool)row.Cells["NoteVorlaeufig"].Value;
            bd.Note = row.Cells["Note"].Value.ToString();

            bd.Masterstudiengang = row.Cells["Masterstudiengang"].Value.ToString();
            bd.Masterstudiengang_2 = row.Cells["Masterstudiengang2"].Value.ToString();
            bd.Masterstudiengang_3 = row.Cells["Masterstudiengang3"].Value.ToString();
            bd.Semester = row.Cells["Semester"].Value.ToString();


            bd.Zusatz = row.Cells["Zusatz"].Value.ToString();
            bd.Comment = row.Cells["Kommentar"].Value.ToString();
            bd.Prof = (bool)row.Cells["AnProf"].Value;
            bd.Ablehnungsgrund = row.Cells["Ablehnungsgrund"].Value.ToString();
            bd.Verwaltung = (bool)row.Cells["Verwaltung"].Value;
            bd.Angenommen = (bool)row.Cells["Angenommen"].Value;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (IdLabel.Text.Trim() != string.Empty)
            {
                EditPerson editPerson = new EditPerson(bd);
                editPerson.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No item Selected in the Table!");
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (IdLabel.Text.Trim() != string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to remove Registration with nummer " + bewerbungID + " ", "Confirm Remove Registration", MessageBoxButtons.YesNo);
                if ((dialogResult == DialogResult.Yes) && RemoveBewerbung(bewerbungID))
                {
                    MessageBox.Show("Bewerbung  Removed Successful!");
                    IdLabel.Text = "";
                    Show_Database();
                }
            }
            else
            {
                MessageBox.Show("No item Selected in the Table!");
            }               
        }

        public bool RemoveBewerbung(int id)
        {
            bool resp = false;
            config = XmlDataManager.XmlConfigDataReader("configs.xml");

            string query = "delete from  tab_bewerbung  where ID = " + id + "";
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
                resp = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return resp;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                bewerbungID = (int)row.Cells["ID"].Value;
                IdLabel.Text = bewerbungID.ToString();
                GetBewerbungDataFromDataView(row);
            }
        }      

        public void OpenOutlook()
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;              
                oMsg.Display(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Close();
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            bool checkFEHLcp = false;
            StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
            if (IdLabel.Text.Trim() != string.Empty)
            {
                int MasterID = Search_ID_Masterstudiengang(bd.Masterstudiengang);
                checkFEHLcp = studentenVerwaltung.Search_BewerbungID_in_tab_FehlCP1(bd.ID, MasterID);
                if (checkFEHLcp == true)
                {
                    summe = 0;
                    fehlendeCPInfos = studentenVerwaltung.ShowStudiengangFehlendeCP(bd.ID, Search_ID_Masterstudiengang(bd.Masterstudiengang));
                    for (int i = 0; i < 10; i++)
                    {
                        if (fehlendeCPInfos[i].FehlCP > 0)
                        {
                            summe = summe + fehlendeCPInfos[i].FehlCP;
                        }

                    }
                    ExportDocx(bd.Masterstudiengang.Trim());
                    MessageBox.Show("Eine Datai fuer " + bd.Masterstudiengang + " mit der Bewerbungsnummer " + bd.ID + " wurde gut erstellt!");
                    checkFEHLcp = false;
                }
                else
                {
                     MessageBox.Show("Export unmöglich, Die Studiengang " + bd.Masterstudiengang + " muss zuerst eingestuft werden!");
                }

                if (bd.Masterstudiengang_2 != "Kein Masterstudiengang")
                {
                    
                    int MasterID2 = Search_ID_Masterstudiengang(bd.Masterstudiengang_2);
                    checkFEHLcp = studentenVerwaltung.Search_BewerbungID_in_tab_FehlCP1(bd.ID, MasterID2);
                    if (checkFEHLcp == true)
                    {
                        summe = 0;
                        fehlendeCPInfos = studentenVerwaltung.ShowStudiengangFehlendeCP(bd.ID, Search_ID_Masterstudiengang(bd.Masterstudiengang_2));
                        for (int i = 0; i < 10; i++)
                        {
                            if (fehlendeCPInfos[i].FehlCP > 0)
                            {
                                summe = summe + fehlendeCPInfos[i].FehlCP;
                            }

                        }
                        ExportDocx(bd.Masterstudiengang_2.Trim());
                        MessageBox.Show("Eine Datai fuer " + bd.Masterstudiengang_2 + " mit der Bewerbungsnummer " + bd.ID + " wurde gut erstellt!");
                        checkFEHLcp = false;
                    }
                    else
                    {
                        MessageBox.Show("Export unmöglich, Die Studiengang " + bd.Masterstudiengang_2 + " muss zuerst eingestuft werden!");
                    }
                }

                if (bd.Masterstudiengang_3 != "Kein Masterstudiengang")
                {
                    
                    int MasterID3 = Search_ID_Masterstudiengang(bd.Masterstudiengang_3);
                    checkFEHLcp = studentenVerwaltung.Search_BewerbungID_in_tab_FehlCP1(bd.ID, MasterID3);
                    if (checkFEHLcp == true)
                    {
                        summe = 0;
                        fehlendeCPInfos = studentenVerwaltung.ShowStudiengangFehlendeCP(bd.ID, Search_ID_Masterstudiengang(bd.Masterstudiengang_3));
                        for (int i = 0; i < 10; i++)
                        {
                            if (fehlendeCPInfos[i].FehlCP > 0)
                            {
                                summe = summe + fehlendeCPInfos[i].FehlCP;
                            }

                        }
                        ExportDocx(bd.Masterstudiengang_3.Trim());
                        MessageBox.Show("Eine Datai fuer " + bd.Masterstudiengang_3 + " mit  der Bewerbungsnummer " + bd.ID + " wurde gut erstellt!");
                        checkFEHLcp = false;
                    }
                    else
                    {
                        MessageBox.Show("Export unmöglich, Die Studiengang " + bd.Masterstudiengang_3 + " muss zuerst eingestuft werden!");
                    }
                }

                
            }
            else
            {
                MessageBox.Show("No item Selected in the Table!");
            }
           
        }

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

        public List<FachCpDelta> GetFachCpDate(string MastStudiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            int ID = Search_ID_Masterstudiengang(MastStudiengang);
            List<FachCpDelta> listeFach = new List<FachCpDelta>();

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
                FachCpDelta fachCpDelta = new FachCpDelta();
                string Fach = reader["txtFach"].ToString();
                fachCpDelta.Fach = Fach;
                string studiengangID = reader["intStudiengang"].ToString();
                int StudiengangID = Convert.ToInt32(studiengangID);
                fachCpDelta.StudiengangID = StudiengangID;
                string Fachid = reader["ID"].ToString();
                int FachID = Convert.ToInt32(Fachid);
                fachCpDelta.FachID = FachID;
                string intCP = reader["intCP"].ToString();
                int IntCP = Convert.ToInt32(intCP);
                fachCpDelta.IntCP = IntCP;
                listeFach.Add(fachCpDelta);
            }
            UserConnection1.Close();

            return listeFach;
        }





        private String ExportDocx(string masterStudiengang)
        {
            config = XmlDataManager.XmlConfigDataReader("configs.xml");
            WordDocCreator Docx = new WordDocCreator(@Path.GetDirectoryName(Application.ExecutablePath).Trim() + "\\template.docx");
            StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
            List<FachCpDelta> listeFach = new List<FachCpDelta>();
          
           

                
                listeFach = GetFachCpDate(bd.Masterstudiengang.Trim());
                Docx.FindAndReplace("<fach1>", listeFach[0].Fach.Trim());
                Docx.FindAndReplace("<fach2>", listeFach[1].Fach.Trim());
                Docx.FindAndReplace("<fach3>", listeFach[2].Fach.Trim());
                Docx.FindAndReplace("<fach4>", listeFach[3].Fach.Trim());
                Docx.FindAndReplace("<fach5>", listeFach[4].Fach.Trim());
                Docx.FindAndReplace("<fach6>", listeFach[5].Fach.Trim());
                Docx.FindAndReplace("<fach7>", listeFach[6].Fach.Trim());
                Docx.FindAndReplace("<fach8>", listeFach[7].Fach.Trim());
                Docx.FindAndReplace("<fach9>", listeFach[8].Fach.Trim());
                Docx.FindAndReplace("<fach10>", listeFach[9].Fach.Trim());

                Docx.FindAndReplace("<cp1>", listeFach[0].IntCP.ToString());
                Docx.FindAndReplace("<cp2>", listeFach[1].IntCP.ToString());
                Docx.FindAndReplace("<cp3>", listeFach[2].IntCP.ToString());
                Docx.FindAndReplace("<cp4>", listeFach[3].IntCP.ToString());
                Docx.FindAndReplace("<cp5>", listeFach[4].IntCP.ToString());
                Docx.FindAndReplace("<cp6>", listeFach[5].IntCP.ToString());
                Docx.FindAndReplace("<cp7>", listeFach[6].IntCP.ToString());
                Docx.FindAndReplace("<cp8>", listeFach[7].IntCP.ToString());
                Docx.FindAndReplace("<cp9>", listeFach[8].IntCP.ToString());
                Docx.FindAndReplace("<cp10>", listeFach[9].IntCP.ToString());

                Docx.FindAndReplace("<name>", bd.Name);
                Docx.FindAndReplace("<vorname>", bd.Vorname);
                Docx.FindAndReplace("<nationalitaet>", bd.Nationalitaet);
                Docx.FindAndReplace("<studiengang>", bd.Studiengang);
                Docx.FindAndReplace("<hochschule>", bd.Hochschule);
                Docx.FindAndReplace("<land>", bd.Studienland);
                Docx.FindAndReplace("<note>", bd.Note);
                Docx.FindAndReplace("<erworbenecp>", bd.Creditpunkte);
                Docx.FindAndReplace("<masterstudiengang>", masterStudiengang);

                Docx.FindAndReplace("<ablehnungsgrund>", bd.Ablehnungsgrund);
                Docx.FindAndReplace("<kommentar>", bd.Comment);
                Docx.FindAndReplace("<date>", DateTime.Now.ToShortDateString());


                Docx.FindAndReplace("<delta1>", fehlendeCPInfos[0].FehlCP.ToString());
                Docx.FindAndReplace("<delta2>", fehlendeCPInfos[1].FehlCP.ToString());
                Docx.FindAndReplace("<delta3>", fehlendeCPInfos[2].FehlCP.ToString());
                Docx.FindAndReplace("<delta4>", fehlendeCPInfos[3].FehlCP.ToString());
                Docx.FindAndReplace("<delta5>", fehlendeCPInfos[4].FehlCP.ToString());
                Docx.FindAndReplace("<delta6>", fehlendeCPInfos[5].FehlCP.ToString());
                Docx.FindAndReplace("<delta7>", fehlendeCPInfos[6].FehlCP.ToString());
                Docx.FindAndReplace("<delta8>", fehlendeCPInfos[7].FehlCP.ToString());
                Docx.FindAndReplace("<delta9>", fehlendeCPInfos[8].FehlCP.ToString());
                Docx.FindAndReplace("<delta10>", fehlendeCPInfos[9].FehlCP.ToString());

                Docx.FindAndReplace("<ist1>", (listeFach[0].IntCP - fehlendeCPInfos[0].FehlCP).ToString());
                Docx.FindAndReplace("<ist2>", (listeFach[1].IntCP - fehlendeCPInfos[1].FehlCP).ToString());
                Docx.FindAndReplace("<ist3>", (listeFach[2].IntCP - fehlendeCPInfos[2].FehlCP).ToString());
                Docx.FindAndReplace("<ist4>", (listeFach[3].IntCP - fehlendeCPInfos[3].FehlCP).ToString());
                Docx.FindAndReplace("<ist5>", (listeFach[4].IntCP - fehlendeCPInfos[4].FehlCP).ToString());
                Docx.FindAndReplace("<ist6>", (listeFach[5].IntCP - fehlendeCPInfos[5].FehlCP).ToString());
                Docx.FindAndReplace("<ist7>", (listeFach[6].IntCP - fehlendeCPInfos[6].FehlCP).ToString());
                Docx.FindAndReplace("<ist8>", (listeFach[7].IntCP - fehlendeCPInfos[7].FehlCP).ToString());
                Docx.FindAndReplace("<ist9>", (listeFach[8].IntCP - fehlendeCPInfos[8].FehlCP).ToString());
                Docx.FindAndReplace("<ist10>", (listeFach[9].IntCP - fehlendeCPInfos[9].FehlCP).ToString());

               
              

                Docx.FindAndReplace("<ges>", summe.ToString());

                string name = bd.Name.Replace(" ", "_");
                string vorname = bd.Vorname.Replace(" ", "_");
                masterStudiengang = masterStudiengang.Replace(" ", "_");
                string semester = bd.Semester.Replace(" ", "_");


                string filename = "\\" + semester.Trim() + vorname.Trim() + name.Trim() + masterStudiengang.Trim() + ".docx";
                string filepath = config.SaveDocxPath.Trim() + filename.Trim();

                Docx.CreateDocx(filepath);

                return filepath;
          
            
        }

        private void AddBewerbungBtn_Click(object sender, EventArgs e)
        {
            NewStudentUI newStudentUI = new NewStudentUI();
            this.Close();
            newStudentUI.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FilternameTB_TextChanged(object sender, EventArgs e)
        {
            if (!filtertype.Equals(string.Empty))
            {
                DataView dataView = new DataView(datatable);
                string filterstr = (filtertype + " LIKE '%{0}%' ");
                dataView.RowFilter = string.Format(filterstr, FilternameTB.Text);
                dataGridView.DataSource = dataView;
            }
        }

        private void FilterTypCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtertype = FilterTypCB.Text;
            if (!filtertype.Equals(string.Empty))
            {
                DataView dataView = new DataView(datatable);
                string filterstr = (filtertype + " LIKE '%{0}%' ");
                dataView.RowFilter = string.Format(filterstr, FilternameTB.Text);
                dataGridView.DataSource = dataView;
            }
        }

        private void EinstufenBtn_Click(object sender, EventArgs e)
        {
            if (IdLabel.Text.Trim() != string.Empty)
            {
                EinstufenUI einstufenUI = new EinstufenUI(bd);
                this.Close();
                einstufenUI.Show();
            }
            else
            {
                MessageBox.Show("No item Selected in the Table!");
            }
        }

        private void StatusBtn_Click(object sender, EventArgs e)
        {
            if (IdLabel.Text.Trim() != string.Empty)
            {
                StudentInfo studentInfo = new StudentInfo(bd);
                this.Close();
                studentInfo.Show();
            }
            else
            {
                MessageBox.Show("No item Selected in the Table!");
            }
        }

        private void SendenBtn_Click(object sender, EventArgs e)
        {
            OpenOutlook();
        }

     
    }
}
