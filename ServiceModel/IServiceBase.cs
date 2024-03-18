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
        // user
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);

        [OperationContract] int DeleteUser(User user);
        [OperationContract] UserList GetAllUsers();
        #endregion
        [OperationContract] User GetUserByID(int id);
        // bank
        [OperationContract] BankAccountList GetAllBankAccountList();
        [OperationContract] int InsertIntoBankAcouunt(BankAccount bankAccount);
        [OperationContract] int UpdateBankAcouunt(BankAccount bankAccount);

        [OperationContract] AccountActionList GetbankAcouuntthattransfer(int num);

        [OperationContract] BankAccount GetBankAcouuntByNum(int num);

        [OperationContract] Customers GetCustomerByUser(User user);
        [OperationContract] int DeleteBankAcouunt(BankAccount bankAccount);
       // [OperationContract] BankAccount GetBankAccountById(int id);
        // Customers

        [OperationContract] int InsertIntoCustomers(Customers customers);
        [OperationContract] int UpgdateCustomers(Customers customers);
        [OperationContract] int DeleteCustomers(Customers customers);
        [OperationContract] CustomersList GetAllCustomers();
       // [OperationContract] Customers GetCustomerById(int id);
        // Action
        [OperationContract] int InsertIntoAction(MyAction action);
        [OperationContract] int UpdateAction(MyAction action);
        [OperationContract] int DeleteAction(MyAction action);
       // [OperationContract] MyAction GetActionById(int id);
        [OperationContract] ActionList GetAllActions();
        // login
        [OperationContract] User UserLogin(User user);
        [OperationContract] BankAccount GetBankAccount(User user);
        [OperationContract] int Insertintoacountaction(AccountAction account);
        [OperationContract] int UpdateIntoAcountAction(AccountAction account);
        [OperationContract] int DeleteIntoAcountAction(AccountAction action);
        [OperationContract] AccountActionList SelectAllAccountAction();

        [OperationContract] BankAccountList GetAllBankAcouuntsByUser(User user);
        [OperationContract] AccountActionList GetAccountActionByBankAcouunt(int id);
        
    }
}
