using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using static System.Collections.Specialized.BitVector32;

namespace ServiceModel
{
    public class ServiceBase : IServiceBase
    {
        public int DeleteAction(MyAction action)
        {
            ActionDB db = new ActionDB();
            return db.Delete(action);
        }

        public int DeleteBankAcouunt(BankAccount bankAccount)
        {
            BankAccountDB db = new BankAccountDB();
            return db.Delete(bankAccount);
        }

        public int DeleteCustomers(Customers customers)
        {
            CustomersDB db = new CustomersDB();
            return db.Delete(customers);
        }

        public int DeleteIntoAcountAction(AccountAction action)
        {
            AccountActionDB dB = new AccountActionDB();
            return dB.Delete(action);
        }

        public int DeleteUser(User user)
        {
            UserDB db = new UserDB();
            return db.Delete(user);
        }

        public ActionList GetAllActions()
        {
            ActionDB db = new ActionDB();
            ActionList myaction = db.SelectAll();
            return myaction; 
        }

        public BankAccountList GetAllBankAccountList()
        {
            BankAccountDB db = new BankAccountDB();
            BankAccountList myBANKACOUNT = db.SelectAll();
            return myBANKACOUNT;
        }

        public CustomersList GetAllCustomers()
        {
            CustomersDB db = new CustomersDB();
            CustomersList mycustomers = db.SelectAll();
            return mycustomers;
        }

        public UserList GetAllUsers()
        {
            UserDB db = new UserDB();
            UserList myusers = db.SelectAll();
            return myusers;
        }

        public int Insertintoacountaction(AccountAction account)
        {
            AccountActionDB db = new AccountActionDB();
            return db.Insert(account);
        }

       

        public Customers GetCustomerByUser(User user1)
        {
            CustomersDB db = new CustomersDB();
            Customers customers = db.SelectByGetById(user1);
            return customers;
        }
        public AccountActionList GetAccountActionByBankAcouunt(int idAcouunt, int ActionId)
        {
            AccountActionDB db = new AccountActionDB();
            AccountActionList List = db.SelectByBankAcouuntTo(idAcouunt, ActionId);
            return List;
        }

        public User GetUserByID(int id)
        {
            UserDB db = new UserDB();
            User user = db.SelectById(id);
            return user;
        }

        public int InsertIntoAction(MyAction action)
        {
            ActionDB db = new ActionDB();
            return db.Insert(action);
        }

        public int InsertIntoBankAcouunt(BankAccount bankAccount)
        {
            BankAccountDB db = new BankAccountDB();
            return db.Insert(bankAccount);
        }

        public int InsertIntoCustomers(Customers customers)
        {
            CustomersDB db = new CustomersDB();
            return db.Insert(customers);
        }

        public int InsertUser(User user)
        {
            UserDB db = new UserDB();
            return db.Insert(user);
        }
        

       

        public AccountActionList SelectAllAccountAction()
        {
            AccountActionDB db = new AccountActionDB();
            AccountActionList mythings = db.SelectAll();
            return mythings;
        }

        public int UpdateAction(MyAction action)
        {
            ActionDB db = new ActionDB();
            return db.Update(action);
        }

        public int UpdateBankAcouunt(BankAccount bankAccount)
        {
            BankAccountDB db = new BankAccountDB();
            return db.Update(bankAccount);
        }

        public int UpdateIntoAcountAction(AccountAction account)
        {
            AccountActionDB db = new AccountActionDB();
            return db.Update(account);
        }

        public int UpdateUser(User user)
        {
            UserDB db = new UserDB();
            return db.Update(user);
        }

        public int UpgdateCustomers(Customers customers)
        {
            CustomersDB db = new CustomersDB();
            return db.Update(customers);
        }

        public User UserLogin(User user)
        {
            UserDB userdb   = new UserDB();
            User myusers = userdb.Login(user);
            return myusers;
        }

        public BankAccount GetBankAccount(User user)
        {
            BankAccountDB db = new BankAccountDB();
            BankAccount BankAccuunt = db.SelectByGetByIduser(user);
            return BankAccuunt;
        }
        public BankAccount GetBankAcouuntByNum(int num)
        {
            BankAccountDB db = new BankAccountDB();
            BankAccount bankacouunt = db.GetBankAccountByBankNum(num);
            return bankacouunt;
        }
        public AccountActionList GetbankAcouuntthattransfer(int idAcouunt, int ActionId)
        {
            AccountActionDB db = new AccountActionDB();
            AccountActionList List = db.SelectByBankAcouuntFrom(idAcouunt, ActionId);
            return List;
        }

        public BankAccountList GetAllBankAcouuntsByUser(User user)
        {
            BankAccountDB db = new BankAccountDB();
            BankAccountList list = db.GetBankAcouuntsByUser(user);
            return list;
        }

        public User GetUserByRealId(int realId)
        {
            UserDB userdb = new UserDB();
            User myusers = userdb.SelectByRealId(realId);
            return myusers;
        }
        public BankAccountList GetBankAcouuntsByRealId(int realid)
        {
            BankAccountDB db = new BankAccountDB();
            BankAccountList list = db.getbankacouuntslistbyRealId(realid);
            return list;
        }
    }
}
