using MahApps.Metro.Controls;
using Facturation.Shared;
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
using Facturation.BLL;

namespace facturation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public Client clientTemp= new Client();
        public List<Client> Clients = new List<Client>();
        public ClientService clientService;

        public MainWindow()
        {
            InitializeComponent();
            clientService = new ClientService();
            Clients = clientService.GetAll();
            this.DataContext = this;
            dg_clients.Items.Refresh();
            dg_clients.ItemsSource = Clients;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Adresse.Text == "" || tb_Nom.Text == "" || tb_Numero.Text == "" || tb_Prenom.Text == "")
            {
                return;
            }
            Client newClient = new Client { nom = tb_Nom.Text, prenom = tb_Prenom.Text, adresse = tb_Adresse.Text, numero = tb_Numero.Text };
            clientService.Ajouter(newClient);
            Clients = clientService.GetAll();
            dg_clients.ItemsSource = Clients;
            dg_clients.Items.Refresh();
            tb_Prenom.Text = tb_Nom.Text = tb_Adresse.Text = tb_Numero.Text = "";
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
           
            clientService.Supprimer(((Client)dg_clients.SelectedItem).id);
            Clients.Remove((Client)dg_clients.SelectedItem);
            dg_clients.Items.Refresh();
        }

        private void tb_recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_recherche.Text == "")
            {
                dg_clients.ItemsSource = Clients;
                dg_clients.Items.Refresh();
            } else
            {
                List<Client> ClientsTemps = Clients.Where(x => x.nom.ToLower().StartsWith(tb_recherche.Text.ToLower())).ToList();
                dg_clients.ItemsSource = ClientsTemps;
                dg_clients.Items.Refresh();
            }
            
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {

            bt_Valider.Visibility = Visibility.Collapsed;
            bt_Update.Visibility = Visibility.Visible;

            clientTemp = (Client)dg_clients.SelectedItem;
            tb_Nom.Text = clientTemp.nom;
            tb_Prenom.Text = clientTemp.prenom;
            tb_Adresse.Text = clientTemp.adresse;
            tb_Numero.Text = clientTemp.numero;

        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {

            if (tb_Adresse.Text == "" || tb_Nom.Text == "" || tb_Numero.Text == "" || tb_Prenom.Text == "")
            {
                return;
            }

            bt_Valider.Visibility = Visibility.Visible;
            bt_Update.Visibility = Visibility.Collapsed;

            clientTemp.nom = tb_Nom.Text;
            clientTemp.prenom = tb_Prenom.Text;
            clientTemp.adresse = tb_Adresse.Text;
            clientTemp.numero = tb_Numero.Text;

            clientService.Modifier(clientTemp);

            clientTemp = new Client();
            clientTemp.nom = "";

           

            dg_clients.Items.Refresh();

            tb_Prenom.Text = tb_Nom.Text = tb_Adresse.Text = tb_Numero.Text = "";

        }
    }
}
