using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class AccountActionDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            AccountAction actionac = new AccountAction();
            actionac.Id = int.Parse(reader["id"].ToString());
            ActionDB actionDB = new ActionDB();
            actionac.Action = actionDB.SelectById(int.Parse(reader["ActionId"].ToString()));
            BankAccountDB bankAccountDB = new BankAccountDB();
            actionac.BankAccount = bankAccountDB.SelectById(int.Parse(reader["AcountId"].ToString()));
            actionac.Amount = int.Parse(reader["amount"].ToString());
            actionac.TimaStamp = DateTime.Parse(reader["TimeStamp"].ToString());
            actionac.ToBankAcouunt = bankAccountDB.SelectById(int.Parse(reader["TobankAcouunt"].ToString()));
            return actionac;
        }

        protected override BaseEntity NewEntity()
        {
            return new AccountAction() as BaseEntity;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            AccountAction action = entity as AccountAction;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ActionId", action.Action.Id);
            command.Parameters.AddWithValue("@AcountId", action.BankAccount.bankAcuuntNum);
            command.Parameters.AddWithValue("@amount", action.Amount);
            command.Parameters.AddWithValue("@TimeStamp", action.TimaStamp);
            command.Parameters.AddWithValue("@TobankAcouunt", action.ToBankAcouunt.bankAcuuntNum);
            command.Parameters.AddWithValue("@id", action.Id);
        }
        public int Insert(AccountAction accountAction)
        {
            command.CommandText = "INSERT INTO tblActionInAccount (ActionId,AcountId,amount,TimeStamp,TobankAcouunt)" +
                " VALUES (@ActionId,@AcountId,@amount,@TimeStamp,@TobankAcouunt)";
            LoadParameters(accountAction);
            return ExecuteCRUD();
        }

        public int Update(AccountAction accountAction)
        {
            command.CommandText = "UPDATE tblActionInAccount SET ActionId = @ActionId, AcountId = @AcountId, amount = @amount,TimeStamp = @TimeStamp,TobankAcouunt = @TobankAcouunt WHERE id = @id";
            LoadParameters(accountAction);
            return ExecuteCRUD();
        }

        public int Delete(AccountAction accountAction)
        {
            command.CommandText = "DELETE FROM tblActionInAccount WHERE id =@id";
            LoadParameters(accountAction);
            return ExecuteCRUD();
        }
        

        public AccountActionList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblActionInAccount";
            AccountActionList list = new AccountActionList(ExecuteCommand());
            return list;
        }
        public AccountAction SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblActionInAccount WHERE id=" + id;
            AccountActionList list = new AccountActionList(ExecuteCommand());
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public AccountActionList SelectByBankAcouuntTo(int idAcouunt, int ActionId)
        {
            command.CommandText = $"SELECT * FROM tblActionInAccount WHERE (TobankAcouunt={idAcouunt} AND ActionId={ActionId})";
            AccountActionList list = new AccountActionList(ExecuteCommand());
            return list;

        }
        public AccountActionList SelectByBankAcouuntFrom(int idAcouunt,int ActionId)
        {
            command.CommandText = $"SELECT * FROM tblActionInAccount WHERE (AcountId={idAcouunt} AND ActionId={ActionId})";
            AccountActionList list = new AccountActionList(ExecuteCommand());
            return list;

        }

    }
}
