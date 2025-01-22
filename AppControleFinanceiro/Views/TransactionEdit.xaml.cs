namespace AppControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
		InitializeComponent();
	}

    private void OnImageTapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}