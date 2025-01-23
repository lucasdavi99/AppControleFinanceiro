using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _repository;

    public TransactionList(ITransactionRepository repository)
    {
        _repository = repository;

        InitializeComponent();

        ReloadData();
        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) => { ReloadData(); });
    }

    private void ReloadData()
    {

        var items = _repository.GetAll();
        CollectionViewTransactions.ItemsSource = items;

        double income = items.Where(a => a.Type == Enums.TransactionType.Income).Sum(a => a.Value);
        double expense = items.Where(a => a.Type == Enums.TransactionType.Expense).Sum(a => a.Value);
        double balance = income - expense;

        LabelIncome.Text = income.ToString("C");
        LabelExpense.Text = expense.ToString("C");
        LabelBalance.Text = balance.ToString("C");
    }

    private void OnButtonClickedToTransactionAdd(object sender, EventArgs e)
    {
        var mauiContext = Handler?.MauiContext;
        if (mauiContext != null)
        {
            var transactionAdd = mauiContext.Services.GetService<TransactionAdd>();
            if (transactionAdd != null)
            {
                Navigation.PushModalAsync(transactionAdd);
            }
        }
    }

    private void TapToListEdit(object sender, TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer?)grid.GestureRecognizers[0];
        if (gesture?.CommandParameter is Transaction transaction)
        {
            var mauiContext = Handler?.MauiContext;
            if (mauiContext != null)
            {
                var transactionEdit = mauiContext.Services.GetService<TransactionEdit>();
                transactionEdit?.SetTransactionToEdit(transaction);
                if (transactionEdit != null)
                {
                    Navigation.PushModalAsync(transactionEdit);
                }
            }
        }
    }
}
