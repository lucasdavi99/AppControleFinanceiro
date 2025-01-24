using AppControleFinanceiro.Enums;
using AppControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Libraries.Converters
{
    public class ValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Transaction transaction)
            {
                return transaction.Type == TransactionType.Income ? transaction.Value.ToString("C", culture) : $"- {transaction.Value.ToString("C", culture)}";
            }

            return "";
            throw new NotImplementedException();
        }
        

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
