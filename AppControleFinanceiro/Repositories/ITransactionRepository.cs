using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Repositories
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        void Delete(Transaction transaction);
        void Update(Transaction transaction);
        List<Transaction> GetAll();
        Transaction GetById(int id);
    }
}