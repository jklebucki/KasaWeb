﻿using Kasa.Core.Domain;

namespace Kasa.Infrastructure.Commands.BankAccount
{
    public class CreateBankAccount
    {
        public int SourceId { get; set; }
        public AccountOwner AccountOwner { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    }
}