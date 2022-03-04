using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<ApplicationUser> accounts;

        public AccountService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("Identity");
            accounts = database.GetCollection<ApplicationUser>("Accounts");
        }

        public List<ApplicationUser> Get()
        {
            return accounts.Find(account => true).ToList();
        }

        public ApplicationUser GetAccountByName(string username)
        {
            return accounts.Find(account => account.UserName == username).FirstOrDefault();
        }

        public ApplicationUser GetAccount(string id)
        {
            foreach(var account in accounts.Find(acc => true).ToList())
            {
                if(account.Id.ToString().ToUpper() == id.ToUpper())
                {
                    return account;
                }
            }
            return null;
        }

        public ApplicationUser GetAccount(ApplicationUser acc)
        {
            return accounts.Find(account => account.UserName == acc.UserName).FirstOrDefault();
        }

        public ApplicationUser Create(ApplicationUser account)
        {
            accounts.InsertOne(account);
            return account;
        }

        public void Update(string id, ApplicationUser accountIn)
        {
            accounts.ReplaceOne(account => account.Id.ToString().ToUpper() == id, accountIn);
        }

        public void Remove(ApplicationUser accIn)
        {
            accounts.DeleteOne(account => account.Id == accIn.Id);
        }

        public void Remove(string id)
        {
            accounts.DeleteOne(account => account.Id.ToString().ToUpper() == id);
        }
    }
}
