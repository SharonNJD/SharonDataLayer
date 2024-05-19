using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class ServiceBase : IServiceBase
    {
        #region User
        public UserList GetAllUsers()
        {
            UserDB db = new UserDB();
            UserList myusers = db.SelectAll();
            return myusers;
        }
        public User UserLogin(User user)
        {
            UserDB userdb = new UserDB();
            User myusers = userdb.Login(user);
            return myusers;
        }
        public int InsertUser(User user)
        {
            UserDB db = new UserDB();
            return db.Insert(user);
        }
        public int UpdateUser(User user)
        {
            UserDB db = new UserDB();
            return db.Update(user);
        }
        public int DeleteUser(User user)
        {
            UserDB db = new UserDB();
            return db.Delete(user);
        }
        #endregion
        #region Bank Account
        public BankAccountList GetAllBankAccounts()
        {
            BankAccountDB dB=new BankAccountDB();
            return dB.SelectAll();
        }
        public BankAccount GetBankAccountsByNumber(int number)
        {
            BankAccountDB db = new BankAccountDB();
            AccountActionDB accountActionDB = new AccountActionDB();
            BankAccount bankAccount = db.SelectById(number);
            if(bankAccount == null) return null;
                bankAccount.balance = accountActionDB.GetBalanace(bankAccount.bankAcuuntNum, true) - accountActionDB.GetBalanace(bankAccount.bankAcuuntNum, false);
            return bankAccount;
        }
        public BankAccountList GetBankAccountsByUser(User user)
        {
            BankAccountDB db = new BankAccountDB();
            AccountActionDB accountActionDB = new AccountActionDB();
            BankAccountList list = db.GetBankAccountsByUser(user);
            if (list == null) return null;
            foreach (BankAccount bankAccount in list)
            {
                bankAccount.balance = accountActionDB.GetBalanace(bankAccount.bankAcuuntNum, true) - accountActionDB.GetBalanace(bankAccount.bankAcuuntNum, false);
            }
            return list;
        }
        public BankAccountList GetBankAccountByCostumer(Customers customer)
        {
            BankAccountDB db = new BankAccountDB();
            BankAccountList BankAccuunt = db.GetBankAccountsByCustomers(customer);
            return BankAccuunt;
        }
        public int InsertBankAccount(BankAccount bankAccount)
        {
            BankAccountDB db = new BankAccountDB();
            return db.Insert(bankAccount);
        }
        public int UpdateBankAccount(BankAccount bankAccount)
        {
            BankAccountDB db = new BankAccountDB();
            return db.Update(bankAccount);
        }
        public int DeleteBankAccount(BankAccount bankAccount)
        {
            BankAccountDB db = new BankAccountDB();
            return db.Delete(bankAccount);
        }
        #endregion
        #region Customer
        public Customers GetCustomerByUser(User user1)
        {
            CustomersDB db = new CustomersDB();
            Customers customers = db.SelectByGetById(user1);
            return customers;
        }
        public CustomersList GetAllCustomers()
        {
            CustomersDB db = new CustomersDB();
            CustomersList mycustomers = db.SelectAll();
            return mycustomers;
        }
        public int InsertCustomers(Customers customers)
        {
            CustomersDB db = new CustomersDB();
            return db.Insert(customers);
        }
        public int DeleteCustomers(Customers customers)
        {
            CustomersDB db = new CustomersDB();
            return db.Delete(customers);
        }
        public int UpdateCustomers(Customers customers)
        {
            CustomersDB db = new CustomersDB();
            return db.Update(customers);
        }
         
        #endregion
        #region Actions  
        public int InsertAction(MyAction action)
        {
            ActionDB db = new ActionDB();
            return db.Insert(action);
        }
        public int UpdateAction(MyAction action)
        {
            ActionDB db = new ActionDB();
            return db.Update(action);
        }
        public int DeleteAction(MyAction action)
        {
            ActionDB db = new ActionDB();
            return db.Delete(action);
        }
        public ActionList GetAllActions()
        {
            ActionDB db = new ActionDB();
            ActionList myaction = db.SelectAll();
            return myaction;
        }
        #endregion
        #region Account Actions
        public int InsertAccountAction(AccountAction account)
        {
            AccountActionDB db = new AccountActionDB();
            return db.Insert(account);
        }
        public int UpdateAccountAction(AccountAction account)
        {
            AccountActionDB db = new AccountActionDB();
            return db.Update(account);
        }
        public int DeleteAccountAction(AccountAction action)
        {
            AccountActionDB dB = new AccountActionDB();
            return dB.Delete(action);
        }
        public AccountActionList SelectAllAccountAction()
        {
            AccountActionDB db = new AccountActionDB();
            AccountActionList mythings = db.SelectAll();
            return mythings;
        }
        public AccountActionList GetAccountActionByBankAccount(BankAccount bankAccount)
        {
            AccountActionDB db = new AccountActionDB();
            AccountActionList List = db.GetAccountActionByBankAccount(bankAccount);
            return List;
        }
        public AccountActionList GetBankAccountTransfer(BankAccount bankAccount, bool to)
        {
            AccountActionDB db = new AccountActionDB();
            if (to)
                return db.SelectByBankAccountTo(bankAccount);
            else
                return db.SelectByBankAccountFrom(bankAccount);
        }
        #endregion
    }
}
