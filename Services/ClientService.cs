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
    }
}