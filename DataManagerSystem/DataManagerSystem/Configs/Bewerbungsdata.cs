﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerSystem.Configs
{
    public class Bewerbungsdata
    {
        public Bewerbungsdata()
        {

        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set { _vorname = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _nationalitaet;
        public string Nationalitaet
        {
            get { return _nationalitaet; }
            set { _nationalitaet = value; }
        }

        private string _studienland;
        public string Studienland
        {
            get { return _studienland; }
            set { _studienland = value; }
        }

        private string _studiengang;
        public string Studiengang
        {
            get { return _studiengang; }
            set { _studiengang = value; }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        private string _creditpunkte;
        public string Creditpunkte
        {
            get { return _creditpunkte; }
            set { _creditpunkte = value; }
        }

        private bool _noteVorlaeufig;
        public bool NoteVorlaeufig
        {
            get { return _noteVorlaeufig; }
            set { _noteVorlaeufig = value; }
        }

        private string _geschlecht;
        public string Geschlecht
        {
            get { return _geschlecht; }
            set { _geschlecht = value; }
        }

        private string _hochschule;
        public string Hochschule
        {
            get { return _hochschule; }
            set { _hochschule = value; }
        }

        private string _masterstudiengang; 
        public string Masterstudiengang
        {
            get { return _masterstudiengang; }
            set { _masterstudiengang = value; }
        }

        private string _masterstudiengang_2;
        public string Masterstudiengang_2
        {
            get { return _masterstudiengang_2; }
            set { _masterstudiengang_2 = value; }
        }

        private string _masterstudiengang_3;
        public string Masterstudiengang_3
        {
            get { return _masterstudiengang_3; }
            set { _masterstudiengang_3 = value; }
        }

        private string _semester;
        public string Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        private string _zusatz;
        public string Zusatz
        {
            get { return _zusatz; }
            set { _zusatz = value; }
        }

        private string _ablehnungsgrund;
        public string Ablehnungsgrund
        {
            get { return _ablehnungsgrund; }
            set { _ablehnungsgrund = value; }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private bool _prof;
        public bool Prof
        {
            get { return _prof; }
            set { _prof = value; }
        }

        private bool _verwaltung;
        public bool Verwaltung
        {
            get { return _verwaltung; }
            set { _verwaltung = value; }
        }

        private bool _angenommen;
        public bool Angenommen
        {
            get { return _angenommen; }
            set { _angenommen = value; }
        }
    }
}
