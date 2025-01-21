using AppControleFinanceiro.Enums;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Models
{
    internal class Transaction
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTimeOffset Date { get; set; }

        public Transaction()
        {
        }

        public Transaction(int id, string name, decimal value, TransactionType type, DateTimeOffset date)
        {
            Id = id;
            Name = name;
            Value = value;
            Type = type;
            Date = date;
        }
    }   
}
