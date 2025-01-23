using AppControleFinanceiro.Enums;
using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;
    private readonly ITransactionRepository _repository;


    public TransactionEdit(ITransactionRepository repository)
	{
        InitializeComponent();
        _repository = repository;
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

    private void OnButtonSave(object sender, EventArgs e)
    {
        if (IsValidData() == false)
        {
            return;
        }

        Transaction transaction = new()
        {
            Id = _transaction.Id,
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expense,
            Name = EntryName.Text,
            Date = DatePicker.Date,
            Value = double.Parse(EntryValue.Text)
        };

        _repository.Update(transaction);

        WeakReferenceMessenger.Default.Send<string>(string.Empty);

        Navigation.PopModalAsync();
    }

    private bool IsValidData()
    {
        bool valid = true;

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            valid = false;
            DisplayAlert("Erro", "Descrição é obrigatória", "OK");
        }
        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            valid = false;
            DisplayAlert("Erro", "Descrição é obrigatória", "OK");
        }

        if (!string.IsNullOrEmpty(EntryValue.Text) && !double.TryParse(EntryValue.Text, out double result))
        {
            valid = false;
            DisplayAlert("Erro", "Valor inválido", "OK");
        }

        if (!valid)
        {
            LabelError.IsVisible = true;
            LabelError.Text = string.Empty;
        }
        return valid;
    }

    private void OnImageTappedToClose(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}