namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;

	public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit)
	{
        this._transactionAdd = transactionAdd;
        this._transactionEdit = transactionEdit;

        InitializeComponent();
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