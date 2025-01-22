namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
        InitializeComponent();
	}

    private void OnButtonClickedToTransactionAdd(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransactionAdd());
    }

    private void OnButtonClickedToTransactionEdit(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransactionEdit());
    }
}