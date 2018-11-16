using Facturation.DAL;
using Facturation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.BLL
{
    public class ClientService
    {
        ClientRepository clientRepository;
        public ClientService()
        {
            clientRepository = new ClientRepository();
        }

        public void Ajouter(Client client)
        {
            clientRepository.Ajouter(client);
        }
        public void Supprimer (int id)
        {
            clientRepository.Supprimer(id);
        }

        public void Modifier (Client client)
        {
            clientRepository.Modifier(client);
        }
        public List<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

    }
}