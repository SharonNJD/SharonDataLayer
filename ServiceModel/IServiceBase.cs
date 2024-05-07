using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceBase
    {
        #region User
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] UserList GetAllUsers();  
        [OperationContract] User UserLogin(User user);
        #endregion
        #region Bank Account
        [OperationContract] BankAccountList GetAllBankAccounts();
        [OperationContract] BankAccount GetBankAccountsByNumber(int number);
        [OperationContract] BankAccountList GetBankAccountsByUser(User user);
        [OperationContract] BankAccountList GetBankAccountByCostumer(Customers customer);
        [OperationContract] int InsertBankAccount(BankAccount bankAccount);
        [OperationContract] int UpdateBankAccount(BankAccount bankAccount);
        [OperationContract] int DeleteBankAccount(BankAccount bankAccount);
        #endregion
        #region Customers
        [OperationContract] Customers GetCustomerByUser(User user);
        [OperationContract] CustomersList GetAllCustomers();
        [OperationContract] int InsertCustomers(Customers customers);
        [OperationContract] int UpdateCustomers(Customers customers);
        [OperationContract] int DeleteCustomers(Customers customers);
        #endregion
        #region Action
        [OperationContract] int InsertAction(MyAction action);
        [OperationContract] int UpdateAction(MyAction action);
        [OperationContract] int DeleteAction(MyAction action);
        [OperationContract] ActionList GetAllActions();
        #endregion
        #region Account Action
        [OperationContract] int InsertAccountAction(AccountAction account);
        [OperationContract] int UpdateAccountAction(AccountAction account);
        [OperationContract] int DeleteAccountAction(AccountAction action);
        [OperationContract] AccountActionList SelectAllAccountAction();
        [OperationContract] AccountActionList GetAccountActionByBankAccount(BankAccount bankAccount);
        [OperationContract] AccountActionList GetBankAccountTransfer(BankAccount bankAccount, bool to);
        #endregion
    }
}
