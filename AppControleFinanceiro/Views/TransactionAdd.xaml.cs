
using AppControleFinanceiro.Enums;
using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _repository;

    public TransactionAdd(ITransactionRepository repository)
	{
        InitializeComponent();
        _repository = repository;
	}

    private void OnImageTapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void OnButtonSave(object sender, EventArgs e)
    {
        if (IsValidData() == false)
        {
            return;
        }

        Transaction transaction = new()
        {
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expense,
            Name = EntryName.Text,
            Date = DatePicker.Date,
            Value = double.Parse(EntryValue.Text)
        };

        _repository.Add(transaction);

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
}