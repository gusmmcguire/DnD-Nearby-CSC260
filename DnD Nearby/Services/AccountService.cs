using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> accounts;

        public AccountService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("D&D-Nearby");
            accounts = database.GetCollection<Account>("Accounts");
        }

        public List<Account> Get()
        {
            return accounts.Find(account => true).ToList();
        }

        public Account GetAccount(string id)
        {
            return accounts.Find(account => account.Id == id).FirstOrDefault();
        }

        public Account GetAccount(Account acc)
        {
            return accounts.Find(account => account.Username == acc.Username).FirstOrDefault();
        }

        public Account Create(Account account)
        {
            accounts.InsertOne(account);
            return account;
        }

        public void Update(string id, Account accountIn)
        {
            accounts.ReplaceOne(account => account.Id == id, accountIn);
        }

        public void Remove(Account accIn)
        {
            accounts.DeleteOne(account => account.Id == accIn.Id);
        }

        public void Remove(string id)
        {
            accounts.DeleteOne(account => account.Id == id);
        }
    }
}
