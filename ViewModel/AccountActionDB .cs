﻿using Model;
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
            command.Parameters.AddWithValue("@ActionId", action.Action);
            command.Parameters.AddWithValue("@AcountId", action.BankAccount);
            command.Parameters.AddWithValue("@amount", action.Amount);
            command.Parameters.AddWithValue("@TimeStamp", action.TimaStamp);
            command.Parameters.AddWithValue("@id", action.Id);
        }
        public int Insert(AccountAction accountAction)
        {
            command.CommandText = "INSERT INTO tblActionInAccount (ActionId,AcountId,amount,TimeStamp)" +
                " VALUES (@ActionId,@AcountId,@amount,@TimeStamp)";
            LoadParameters(accountAction);
            return ExecuteCRUD();
        }

        public int Update(AccountAction accountAction)
        {
            command.CommandText = "UPDATE tblActionInAccount SET ActionId = @ActionId, AcountId = @AcountId, amount = @amount,TimeStamp = @TimeStamp WHERE id = @id";
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
    }
}
