using AppControleFinanceiro.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;

        public TransactionRepository(LiteDatabase database) 
        {
            _database = database;
        }

        public List<Transaction> GetAll()
        {
            return _database.GetCollection<Transaction>("transactions").Query().OrderBy(x => x.Date).ToList();
        }

        public Transaction GetById(int id)
        {
            return _database.GetCollection<Transaction>("transactions").FindById(id);
        }

        public void Add(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>("transactions");
            col.Insert(transaction);
            col.EnsureIndex(x => x.Date);
        }

        public void Update(Transaction transaction)
        {
            _database.GetCollection<Transaction>("transactions").Update(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _database.GetCollection<Transaction>("transactions").Delete(transaction.Id);
        }
    }
}
