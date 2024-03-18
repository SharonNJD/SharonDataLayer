using Model;
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
            bankAccount.bankAcuuntNum = int.Parse(reader["BankAcouuntNum"].ToString());
            bankAccount.secretCode = int.Parse(reader["SecretCode"].ToString());

            CustomersDB customersDB = new CustomersDB();
            bankAccount.customer = customersDB.SelectById(int.Parse(reader["CustomerId"].ToString()));
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
        protected override void LoadParameters(BaseEntity entity)
        {
            BankAccount bankAccount = entity as BankAccount;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@SecretCode", bankAccount.secretCode);
            command.Parameters.AddWithValue("@CanLoan", bankAccount.canloan);
            command.Parameters.AddWithValue("@CanTransferOverSeas", bankAccount.canTransferOverSeas);
            command.Parameters.AddWithValue("@CanTradeStocks", bankAccount.canTradeStocks);
            command.Parameters.AddWithValue("@AdultAcouunt", bankAccount.adultAcouunt);
            command.Parameters.AddWithValue("@PersonalAcouunt", bankAccount.personalAcouunt);
            command.Parameters.AddWithValue("@CustomerId", bankAccount.customer.User.Id);
            command.Parameters.AddWithValue("@BankAcouuntNum", bankAccount.bankAcuuntNum);
            
        }
        public int Insert(BankAccount bank)
        {
            command.CommandText = "INSERT INTO tblBankAccount (SecretCode,CanLoan,CanTransferOverSeas,CanTradeStocks,AdultAcouunt,PersonalAcouunt,CustomerId) VALUES (@SecretCode,@CanLoan,@CanTransferOverSeas,@CanTradeStocks,@AdultAcouunt,@PersonalAcouunt,@CustomerId)";
            LoadParameters(bank);
            return ExecuteCRUD();
        }

        public int Update(BankAccount bank)
        {
            command.CommandText = "UPDATE tblBankAccount SET PersonalAcouunt = @PersonalAcouunt,CanLoan = @CanLoan,CanTransferOverSeas = @CanTransferOverSeas,CanTradeStocks = @CanTradeStocks,AdultAcouunt = @AdultAcouunt,Customer = @Customer,SecretCode = @SecretCode WHERE BankAcouuntNum = @BankAcouuntNum";
            LoadParameters(bank);
            return ExecuteCRUD();
        }        
        
        public int Delete(BankAccount bank)
        {
            command.CommandText = "DELETE FROM tblBankAccount WHERE BankAcouuntNum =@BankAcouuntNum";
            LoadParameters(bank);
            return ExecuteCRUD();
        }
        public BankAccount SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblBankAccount WHERE (CustomerId = {id})";
            BankAccountList list = new BankAccountList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
        public BankAccount SelectByGetByIduser(User user)
        {
            command.CommandText = $"SELECT * FROM tblBankAccount WHERE (CustomerId = {user.Id})";
            BankAccountList list = new BankAccountList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
        public BankAccountList GetBankAcouuntsByUser(User user)
        {
            command.CommandText = $"SELECT * FROM tblBankAccount WHERE (CustomerId = {user.Id})";
            BankAccountList list = new BankAccountList(base.ExecuteCommand());
            if (list.Count >= 1)
                return list;
            return null;
        }
        public BankAccount GetBankAccountByBankNum(int num)
        {
            command.CommandText = $"SELECT * FROM tblBankAccount WHERE (BankAcouuntNum = {num})";
            BankAccountList list = new BankAccountList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

    }
}
