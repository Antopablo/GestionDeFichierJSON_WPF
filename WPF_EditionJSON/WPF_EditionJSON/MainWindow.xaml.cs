using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WPF_EditionJSON
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Livre> Collection_livre = new ObservableCollection<Livre>();
        public MainWindow()
        {
            InitializeComponent();
            Data_Grid.ItemsSource = Collection_livre;
            Data_Grid.IsReadOnly = true;
        }

        private void ChargerJSON_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JSON Files | *.json";
            if (openFileDialog.ShowDialog() == true)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObservableCollection<Livre>));
                Stream stm = new StreamReader(openFileDialog.FileNames[0], true).BaseStream;
                ObservableCollection<Livre> tmp = (ObservableCollection<Livre>)ser.ReadObject(stm);
                stm.Close();
                Collection_livre.Clear();
                foreach (Livre item in tmp)
                {
                    Collection_livre.Add(item);
                }
            }
        }

        private void SauvJSON_Click(object sender, RoutedEventArgs e)
        {
                Stream stm = new StreamWriter("Save.json").BaseStream;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObservableCollection<Livre>));
                ser.WriteObject(stm, Collection_livre);
                stm.Close();
        }

        private void EditJSON_Click(object sender, RoutedEventArgs e)
        {
            Data_Grid.IsReadOnly = false;
            Data_Grid.BeginEdit();
        }

      
    }
}
