using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;

    public TransactionEdit()
	{
		InitializeComponent();
	}

    public void SetTransactionToEdit(Transaction transaction)
    {
        _transaction = transaction;

        if(transaction.Type == Enums.TransactionType.Income)
        {
            RadioIncome.IsChecked = true;
        }
        else
        {
            RadioExpanse.IsChecked = true;
        }

        EntryName.Text = transaction.Name;
        DatePicker.Date = transaction.Date.Date;
        EntryValue.Text = transaction.Value.ToString();
    }

    private void OnImageTapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}