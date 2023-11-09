﻿using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.BankAccount;
using static Model.Customers;

namespace ViewModel
{
    public class BankAccountDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.canloan = bool.Parse(reader["CanLoan"].ToString());
            bankAccount.canTransferOverSeas = bool.Parse(reader["CanTransferOverSeas"].ToString());
            bankAccount.canTradeStocks = bool.Parse(reader["CanTradeStocks"].ToString());
            bankAccount.adultAcouunt = bool.Parse(reader["AdultAcouunt"].ToString());
            bankAccount.personalAcouunt = bool.Parse(reader["PersonalAcouunt"].ToString());
            bankAccount.customerId = int.Parse(reader["CustomerId"].ToString());
            bankAccount.bankAcuuntNum = int.Parse(reader["BankAcouuntNum"].ToString());
            bankAccount.secretCode = int.Parse(reader["SecretCode"].ToString());
            return bankAccount;
        }

        protected override BaseEntity NewEntity()
        {
            return new BankAccount() as BaseEntity;
        }
        public BankAccountList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblCustomers";
            BankAccountList list = new BankAccountList(ExecuteCommand());
            return list;
        }
        public BankAccount SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblBankAccount WHERE (CustomerId = {id})";
            BankAccountList list = new BankAccountList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
    }
}
