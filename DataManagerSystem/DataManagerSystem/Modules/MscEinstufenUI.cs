using DataManagerSystem.Configs;
using DataManagerSystem.VerwaltungStudentenInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManagerSystem.Modules
{
    public partial class MscEinstufenUI : Form
    {
        int Compute;
        StudentenVerwaltung studentenVerwaltung = new StudentenVerwaltung();
        List<FehlendeCPInfo> listeFehlenCP = new List<FehlendeCPInfo>();
        List<FachCpDelta> listeFaecher = new List<FachCpDelta>();
        Bewerbungsdata bewerbungsdata = new Bewerbungsdata();
        int stdgNr = 0;
        public MscEinstufenUI(Bewerbungsdata bewerbungsdata, int Nr)
        {
            InitializeComponent();
            this.bewerbungsdata = bewerbungsdata;
            stdgNr = Nr;
        }

        private void MscEinstufenUI_Load(object sender, EventArgs e)
        {   
            IdLabel.Text = bewerbungsdata.ID.ToString();
            switch(stdgNr)
            {
                case 1:
                    MscLabel.Text = bewerbungsdata.Masterstudiengang;
                    int MasterID = studentenVerwaltung.ShowMasterstudiengangID(bewerbungsdata.Masterstudiengang);
                    listeFaecher = studentenVerwaltung.ShowStudiengangNoten(bewerbungsdata.Masterstudiengang);
                    listeFehlenCP = studentenVerwaltung.ShowStudiengangFehlendeCP(bewerbungsdata.ID, MasterID);
                    InitField(bewerbungsdata, listeFaecher);
                    ShowFehlCP1(bewerbungsdata.ID, listeFaecher, listeFehlenCP,MasterID);
                    Compute = 1;
                    AdditionOfAllValueIntCP();
                break;
                case 2:
                    MscLabel.Text = bewerbungsdata.Masterstudiengang_2;
                    int MasterID2 = studentenVerwaltung.ShowMasterstudiengangID(bewerbungsdata.Masterstudiengang_2);
                    listeFaecher = studentenVerwaltung.ShowStudiengangNoten(bewerbungsdata.Masterstudiengang_2);
                    listeFehlenCP = studentenVerwaltung.ShowStudiengangFehlendeCP(bewerbungsdata.ID, MasterID2);
                    InitField(bewerbungsdata, listeFaecher);
                    ShowFehlCP1(bewerbungsdata.ID, listeFaecher, listeFehlenCP, MasterID2);
                    Compute = 1;
                    AdditionOfAllValueIntCP();

                break;
                case 3:
                    MscLabel.Text = bewerbungsdata.Masterstudiengang_3;
                    int MasterID3 = studentenVerwaltung.ShowMasterstudiengangID(bewerbungsdata.Masterstudiengang_3);
                    listeFaecher = studentenVerwaltung.ShowStudiengangNoten(bewerbungsdata.Masterstudiengang_3);
                    listeFehlenCP = studentenVerwaltung.ShowStudiengangFehlendeCP(bewerbungsdata.ID, MasterID3);
                    InitField(bewerbungsdata, listeFaecher);
                    ShowFehlCP1(bewerbungsdata.ID, listeFaecher, listeFehlenCP,MasterID3);
                    Compute = 1;
                    AdditionOfAllValueIntCP();
                break;
            }
            LabelVorname.Text = bewerbungsdata.Vorname;
            LabelName.Text = bewerbungsdata.Name;

            



        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            EinstufenUI einstufenUI = new EinstufenUI(bewerbungsdata);
            this.Close();
            einstufenUI.Show();
        }

        private void InitField(Bewerbungsdata data, List<FachCpDelta> master)
        {
            int initialiseTesxtBox = 0;
            /*
            IdLabel.Text = (data.ID).ToString();
            MscLabel.Text = data.Masterstudiengang;
            LabelName.Text = data.Name;
            LabelVorname.Text = data.Vorname;*/
 

            LabelFach1.Text = listeFaecher[0].Fach;
            LabelFach2.Text = listeFaecher[1].Fach;
            LabelFach3.Text = listeFaecher[2].Fach;
            LabelFach4.Text = listeFaecher[3].Fach;
            LabelFach5.Text = listeFaecher[4].Fach;
            LabelFach6.Text = listeFaecher[5].Fach;
            LabelFach7.Text = listeFaecher[6].Fach;
            LabelFach8.Text = listeFaecher[7].Fach;
            LabelFach9.Text = listeFaecher[8].Fach;
            LabelFach10.Text = listeFaecher[9].Fach;

            LabelIntCP1.Text = (listeFaecher[0].IntCP).ToString();
            LabelIntCP2.Text = (listeFaecher[1].IntCP).ToString();
            LabelIntCP3.Text = (listeFaecher[2].IntCP).ToString();
            LabelIntCP4.Text = (listeFaecher[3].IntCP).ToString();
            LabelIntCP5.Text = (listeFaecher[4].IntCP).ToString();
            LabelIntCP6.Text = (listeFaecher[5].IntCP).ToString();
            LabelIntCP7.Text = (listeFaecher[6].IntCP).ToString();
            LabelIntCP8.Text = (listeFaecher[7].IntCP).ToString();
            LabelIntCP9.Text = (listeFaecher[8].IntCP).ToString();
            LabelIntCP10.Text = (listeFaecher[9].IntCP).ToString();

            textBoxIstCP1.Text = initialiseTesxtBox.ToString();
            textBoxIstCP2.Text = initialiseTesxtBox.ToString();
            textBoxIstCP3.Text = initialiseTesxtBox.ToString();
            textBoxIstCP4.Text = initialiseTesxtBox.ToString();
            textBoxIstCP4.Text = initialiseTesxtBox.ToString();
            textBoxIstCP5.Text = initialiseTesxtBox.ToString();
            textBoxIstCP6.Text = initialiseTesxtBox.ToString();
            textBoxIstCP7.Text = initialiseTesxtBox.ToString();
            textBoxIstCP8.Text = initialiseTesxtBox.ToString();
            textBoxIstCP9.Text = initialiseTesxtBox.ToString();
            textBoxIstCP10.Text = initialiseTesxtBox.ToString();
        }

        private void ShowFehlCP1(int bewerbungsID, List<FachCpDelta> listeFach, List<FehlendeCPInfo> listeFehlCP,int IDMaster)
        {


            bool resut = studentenVerwaltung.Search_BewerbungID_in_tab_FehlCP1(bewerbungsID, IDMaster);
            if (resut == false)
            {
                listeFach = listeFaecher;


                LabelFehltCP1.Text = (listeFach[0].IntCP).ToString();
                LabelFehltCP2.Text = (listeFach[1].IntCP).ToString();
                LabelFehltCP3.Text = (listeFach[2].IntCP).ToString();
                LabelFehltCP4.Text = (listeFach[3].IntCP).ToString();
                LabelFehltCP5.Text = (listeFach[4].IntCP).ToString();
                LabelFehltCP6.Text = (listeFach[5].IntCP).ToString();
                LabelFehltCP7.Text = (listeFach[6].IntCP).ToString();
                LabelFehltCP8.Text = (listeFach[7].IntCP).ToString();
                LabelFehltCP9.Text = (listeFach[8].IntCP).ToString();
                LabelFehltCP10.Text = (listeFach[9].IntCP).ToString();

            }
            else
            {

                listeFehlCP = listeFehlenCP;


                LabelFehltCP1.Text = (listeFehlCP[0].FehlCP).ToString();
                LabelFehltCP2.Text = (listeFehlCP[1].FehlCP).ToString();
                LabelFehltCP3.Text = (listeFehlCP[2].FehlCP).ToString();
                LabelFehltCP4.Text = (listeFehlCP[3].FehlCP).ToString();
                LabelFehltCP5.Text = (listeFehlCP[4].FehlCP).ToString();
                LabelFehltCP6.Text = (listeFehlCP[5].FehlCP).ToString();
                LabelFehltCP7.Text = (listeFehlCP[6].FehlCP).ToString();
                LabelFehltCP8.Text = (listeFehlCP[7].FehlCP).ToString();
                LabelFehltCP9.Text = (listeFehlCP[8].FehlCP).ToString();
                LabelFehltCP10.Text = (listeFehlCP[9].FehlCP).ToString();

            }
        }

        private void FehlendeCPRechnen()
        {
            if (((CheckValueOftheDigit(textBoxIstCP1.Text.Trim()) != true)) && (CheckValueOftheDigit(textBoxIstCP2.Text.Trim()) != true) && (CheckValueOftheDigit(textBoxIstCP3.Text.Trim()) != true)
                && (CheckValueOftheDigit(textBoxIstCP4.Text.Trim()) != true) && (CheckValueOftheDigit(textBoxIstCP5.Text.Trim()) != true) && (CheckValueOftheDigit(textBoxIstCP6.Text.Trim()) != true)
                && (CheckValueOftheDigit(textBoxIstCP7.Text.Trim()) != true) && (CheckValueOftheDigit(textBoxIstCP8.Text.Trim()) != true) && (CheckValueOftheDigit(textBoxIstCP9.Text.Trim()) != true)
                && (CheckValueOftheDigit(textBoxIstCP10.Text.Trim()) != true))
            {

                ComputeTheDifferenceOfAllValue();
                AdditionOfAllValueIntCP();
            }
            else
            {
                MessageBox.Show("Please fill all the field or check your daten. The Daten muss not content letter!");
            }
        }

        // Compute the difference between two string that was converted to integer
        private int DifferenceFehlendeCpRechnen(string intcp, string eingabe)
        {

            int IntcpWert = Convert.ToInt32(intcp);
            int EingabeWert = Convert.ToInt32(eingabe);
            return IntcpWert - EingabeWert;
        }

        // Compute the difference between two string that was converted to integer
        private int AdditionOffValues(string eingabe, int value1)
        {
            
            int EingabeWert = Convert.ToInt32(eingabe);
            int result = EingabeWert;
            if (EingabeWert <= 0)
            {
                result = 0;
            }
            return value1 + result;
        }


        private void ComputeTheDifferenceOfAllValue()
        {
            LabelFehltCP1.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP1.Text.Trim(), textBoxIstCP1.Text.Trim())).ToString();
            LabelFehltCP2.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP2.Text.Trim(), textBoxIstCP2.Text.Trim())).ToString();
            LabelFehltCP3.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP3.Text.Trim(), textBoxIstCP3.Text.Trim())).ToString();
            LabelFehltCP4.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP4.Text.Trim(), textBoxIstCP4.Text.Trim())).ToString();
            LabelFehltCP5.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP5.Text.Trim(), textBoxIstCP5.Text.Trim())).ToString();
            LabelFehltCP6.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP6.Text.Trim(), textBoxIstCP6.Text.Trim())).ToString();
            LabelFehltCP7.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP7.Text.Trim(), textBoxIstCP7.Text.Trim())).ToString();
            LabelFehltCP8.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP8.Text.Trim(), textBoxIstCP8.Text.Trim())).ToString();
            LabelFehltCP9.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP9.Text.Trim(), textBoxIstCP9.Text.Trim())).ToString();
            LabelFehltCP10.Text = (DifferenceFehlendeCpRechnen(LabelFehltCP10.Text.Trim(), textBoxIstCP10.Text.Trim())).ToString();
        }

        private void AdditionOfAllValueIntCP()
        {
            int GesamtFehlCP = 0;


            GesamtFehlCP = (AdditionOffValues(LabelFehltCP1.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP2.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP3.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP4.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP5.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP6.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP7.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP8.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP9.Text.Trim(), GesamtFehlCP));
            GesamtFehlCP = (AdditionOffValues(LabelFehltCP10.Text.Trim(), GesamtFehlCP));


            labelGesamtFehlCP.Text = GesamtFehlCP.ToString();

        }


        //Check if the value hat letter
        private bool CheckValueOftheDigit(string wert)
        {
            bool result = false;

            for (int i = 0; i < wert.Length; i++)
            {
                if (char.IsLetter(wert, i))
                {
                    result = true;
                }
            }
            return result;
        }

        //Save FehlendeCP in Data base
        private void SaveFehlendeCP(string Master)
        {
            int[] listeFehlCP = new int[10];
            List<FachCpDelta> listeFaech = new List<FachCpDelta>();
            List<FehlendeCPInfo> listeFehlendCp = new List<FehlendeCPInfo>();
            listeFaech = studentenVerwaltung.ShowStudiengangNoten(Master);

            listeFehlCP[0] = Convert.ToInt32(LabelFehltCP1.Text.Trim());
            listeFehlCP[1] = Convert.ToInt32(LabelFehltCP2.Text.Trim());
            listeFehlCP[2] = Convert.ToInt32(LabelFehltCP3.Text.Trim());
            listeFehlCP[3] = Convert.ToInt32(LabelFehltCP4.Text.Trim());
            listeFehlCP[4] = Convert.ToInt32(LabelFehltCP5.Text.Trim());
            listeFehlCP[5] = Convert.ToInt32(LabelFehltCP6.Text.Trim());
            listeFehlCP[6] = Convert.ToInt32(LabelFehltCP7.Text.Trim());
            listeFehlCP[7] = Convert.ToInt32(LabelFehltCP8.Text.Trim());
            listeFehlCP[8] = Convert.ToInt32(LabelFehltCP9.Text.Trim());
            listeFehlCP[9] = Convert.ToInt32(LabelFehltCP10.Text.Trim());
            int Masterstudiengang = studentenVerwaltung.ShowMasterstudiengangID(Master);
            for (int j = 0; j < 10; j++)
            {
                FehlendeCPInfo fehlendeCPInfo = new FehlendeCPInfo();
                int Erfuelle;
                fehlendeCPInfo.IntBewerbungID = bewerbungsdata.ID;
                fehlendeCPInfo.IntCPdelta = listeFaech[j].FachID;
                fehlendeCPInfo.FehlCP = listeFehlCP[j];
                fehlendeCPInfo.IntStudiengang = Masterstudiengang;
                if (fehlendeCPInfo.FehlCP == 0)
                {
                    Erfuelle = 1;
                }
                else
                {
                    Erfuelle = 0;
                }
                listeFehlendCp.Add(fehlendeCPInfo);
                studentenVerwaltung.AddFehlendeCP(fehlendeCPInfo.IntBewerbungID, fehlendeCPInfo.IntCPdelta, fehlendeCPInfo.FehlCP, fehlendeCPInfo.IntStudiengang, Erfuelle);
            }

        }



        private void ChangeNoteAfterCompute(string not, int j)
        {
            int note;
            bool res = int.TryParse(not, out note);
            if (res == true)
            {
                listeFehlenCP[j].FehlCP = note;
            }
        }

        private void BtnEinstufen1_Click(object sender, EventArgs e)
        {
            if (Compute > 0)
            {
                FehlendeCPRechnen();
                SaveFehlendeCP(MscLabel.Text.Trim());
                EinstufenBewerbung(bewerbungsdata);
                Compute--;
                MessageBox.Show("Die Studiengang "+ MscLabel.Text.Trim() + " mit der BewerbungsID " + IdLabel.Text.Trim() + "wurde eingestuft");

            }
        }

        private void EinstufenBewerbung(Bewerbungsdata bewer)
        {
            string beschreibung1 = "Eingestuft: Abgelehnt (" + labelGesamtFehlCP.Text.Trim() + " Fehl-CP)";
            string beschreibung2 = " Wurde nicht eingestuft";
            string beschreibung3 = " Wurde nicht eingestuft ";
            if (MscLabel.Text.Trim().Equals(bewer.Masterstudiengang))
            {
                UserData userData = new UserData();
                if (File.Exists("userData.xml"))
                {
                     userData = XmlDataManager.XmlUserDataReader("userData.xml");
                    
                }
                

                studentenVerwaltung.Einstufen(bewer.ID,userData.Username,beschreibung1,beschreibung2,beschreibung3);
            }
           else if (MscLabel.Text.Trim().Equals(bewer.Masterstudiengang_2))
            {
                UserData userData = new UserData();
                if (File.Exists("userData.xml"))
                {
                    userData = XmlDataManager.XmlUserDataReader("userData.xml");

                }


                studentenVerwaltung.Einstufen(bewer.ID, userData.Username, beschreibung2, beschreibung1, beschreibung3);
            }
           else if (MscLabel.Text.Trim().Equals(bewer.Masterstudiengang_3))
            {
                UserData userData = new UserData();
                if (File.Exists("userData.xml"))
                {
                    userData = XmlDataManager.XmlUserDataReader("userData.xml");

                }


                studentenVerwaltung.Einstufen(bewer.ID, userData.Username, beschreibung3, beschreibung2, beschreibung1);
            }
        }
    }
}
