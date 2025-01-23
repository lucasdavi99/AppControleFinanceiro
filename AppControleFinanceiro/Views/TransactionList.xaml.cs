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
        CollectionViewTransactions.ItemsSource = _repository.GetAll();
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

    private void OnButtonClickedToTransactionEdit(object sender, EventArgs e)
    {
        var mauiContext = Handler?.MauiContext;
        if (mauiContext != null)
        {
            var transactionEdit = mauiContext.Services.GetService<TransactionEdit>();
            if (transactionEdit != null)
            {
                Navigation.PushModalAsync(transactionEdit);
            }
        }
    }
}
