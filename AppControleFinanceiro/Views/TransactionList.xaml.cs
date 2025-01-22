using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;
    private readonly ITransactionRepository _repository;


    public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit, ITransactionRepository repository)
	{
        _transactionAdd = transactionAdd;
        _transactionEdit = transactionEdit;
        _repository = repository;

        InitializeComponent();

        CollectionViewTransactions.ItemsSource = _repository.GetAll();
    }

    private void OnButtonClickedToTransactionAdd(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_transactionAdd);
    }

    private void OnButtonClickedToTransactionEdit(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_transactionEdit);
    }
}