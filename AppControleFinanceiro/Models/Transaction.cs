﻿using AppControleFinanceiro.Enums;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Models
{
    public class Transaction
    {
        [BsonId]
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTimeOffset Date { get; set; }
    }   
}
