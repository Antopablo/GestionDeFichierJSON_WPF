using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EditionJSON
{
    [DataContract]
    class Livre : INotifyPropertyChanged
    {
        private string _resume;
        private DateTime _anneeSortie;
        private string _auteur;
        private string _titre;

        public Livre(string titre,  string auteur)
        {
            Titre = titre;
            Auteur = auteur;
            Resume = "Lorem ipsum dolor sit amet";
        }
        public Livre()
        {
            Resume = "Lorem ipsum dolor sit amet";
        }

        [DataMember(Order = 3)]
        public string Resume
        {
            get { return _resume; }
            set {
                if (this._resume != value)
                {
                    this._resume = value;
                    this.NotifyPropertyChanged("Resume");
                }
            }
        }

        [DataMember(Order = 0)]
        public string Titre
        {
            get { return _titre; }
            set {
                if (this._titre != value)
                {
                    this._titre = value;
                    this.NotifyPropertyChanged("Titre");
                }
            }
        }

        [DataMember(Order = 2)]
        public DateTime AnneeSortie
        {
            get { return _anneeSortie; }
            set {
                if (this._anneeSortie != value)
                {
                    this._anneeSortie = value;
                    this.NotifyPropertyChanged("AnneeSortie");
                }
            }
        }

        [DataMember(Order = 1)]
        public string Auteur
        {
            get { return _auteur; }
            set {
                if (this._auteur != value)
                {
                    this._auteur = value;
                    this.NotifyPropertyChanged("Auteur");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
