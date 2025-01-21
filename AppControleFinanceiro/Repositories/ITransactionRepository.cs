using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Repositories
{
    internal interface ITransactionRepository
    {
        void Add(Transaction transaction);
        void Delete(Transaction transaction);
        void DeleteById(int id);
        List<Transaction> GetAll();
        Transaction GetById(int id);
        void Update(Transaction transaction);
    }
}