using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class ClientService
    {
        public static void InsertClient(string clientName, string email, 
            string phone)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new Client 
                { 
                    ClientName = clientName, 
                    Email = email, 
                    Phone = phone 
                });
                db.SaveChanges();
            }
        }

        public static int? GetClientId(string clientName)
        {
            int? clientId = 0; 
            using (var db = new AccountingContext())
            {
                var clientList = db.Client
                    .Where(c => c.ClientName == clientName)
                    .ToList(); 
                if (clientList.Count != 0)
                {
                    clientId = clientList[0].ClientId; 
                }
                else
                {
                    clientId = null; 
                }
            }
            return clientId; 
        }

        public static List<Client> GetClients()
        {
            List<Client> clients = new List<Client>(); 
            using (var db = new AccountingContext())
            {
                clients = db.Client.OrderBy(c => c.ClientId).ToList(); 
            }
            return clients; 
        }

        public static void UpdateClient(int clientId, string clientName, 
            string email, string phone)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var client = db.Client
                        .Where(ii => ii.ClientId == clientId)
                        .ToList()
                        .First(); 
                    client.ClientName = clientName; 
                    client.Email = email; 
                    client.Phone = phone; 
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void DeleteClient(int clientId)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var client = db.Client
                        .Where(c => c.ClientId == clientId)
                        .ToList()
                        .First(); 
                    db.Remove(client);
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}