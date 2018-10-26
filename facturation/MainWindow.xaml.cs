using MahApps.Metro.Controls;
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

namespace facturation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public List<Client> Clients = new List<Client>();
        int id = 1;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Clients.Add(new Client { id = id, nom = "pierre", prenom = "charles", adresse = "123 rue de la rue", numero = "0102030405" });
            id++;
            dg_clients.Items.Refresh();
            dg_clients.ItemsSource = Clients;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Clients.Add(new Client { id=id, nom = tb_Nom.Text, prenom = tb_Prenom.Text, adresse = tb_Adresse.Text, numero = tb_Numero.Text });
            id++;
            dg_clients.Items.Refresh();
            tb_Prenom.Text = tb_Nom.Text = tb_Adresse.Text = tb_Numero.Text = "";
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Clients.Remove((Client)dg_clients.SelectedItem);
            dg_clients.Items.Refresh();
        }

        private void tb_recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            Clients = Clients.Where(x => x.nom.Contains(tb_recherche.Text)).ToList();
            dg_clients.ItemsSource = Clients;
            dg_clients.Items.Refresh();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {

            bt_Valider.Visibility = Visibility.Collapsed;
            bt_Update.Visibility = Visibility.Visible;

            var clientTemp = (Client)dg_clients.SelectedItem;
            tb_Nom.Text = clientTemp.nom;
            tb_Prenom.Text = clientTemp.prenom;
            tb_Adresse.Text = clientTemp.adresse;
            tb_Numero.Text = clientTemp.numero;


        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
