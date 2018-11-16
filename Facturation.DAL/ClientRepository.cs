using Facturation.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.DAL
{
    public class ClientRepository
    {
        MySqlConnection conn;
        public ClientRepository()
        {
            string connStr = "server=localhost;user=root;password=root;database=facturation;port=3306";
            conn = new MySqlConnection(connStr);
        }

        public void Ajouter(Client client)
        {
            try
            {
                conn.Open();
                string sql = $"INSERT INTO client ( Nom, Prenom, Numero_Telephone,Adresse) VALUES ('{client.nom}','{client.prenom}','{client.numero}','{client.adresse}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        public void Modifier(Client client)
        {
            try
            {
                conn.Open();
                string sql = $"UPDATE client SET Nom='{client.nom}', Prenom='{client.prenom}', Numero_Telephone='{client.numero}',Adresse='{client.adresse}' WHERE id='{client.id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }
        public void Supprimer (int id)
        {
            try
            {
                conn.Open();
                string sql = $"DELETE FROM client WHERE id='{id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM client";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr= cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Client client = new Client { id = Convert.ToInt16(rdr[0]), nom = rdr[1].ToString(), prenom = rdr[2].ToString(), numero = rdr[3].ToString(), adresse = rdr[4].ToString() };
                    clients.Add(client);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return clients;
        }
    }
}
