using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;
    private readonly ITransactionRepository _repository;


    public TransactionList(ITransactionRepository repository)
	{
        _repository = repository;

        InitializeComponent();

        CollectionViewTransactions.ItemsSource = _repository.GetAll();
    }

    private void OnButtonClickedToTransactionAdd(object sender, EventArgs e)
    {
        var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(transactionAdd);
    }

    private void OnButtonClickedToTransactionEdit(object sender, EventArgs e)
    {
        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
        Navigation.PushModalAsync(transactionEdit);
    }
}