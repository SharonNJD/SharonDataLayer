using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.MyAction;

namespace ViewModel
{
    public class ActionDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyAction action = new MyAction();
            action.actionName = reader["ActionName"].ToString();
            action.minRank = int.Parse(reader["MinRank"].ToString());
            action.commissionTaken = double.Parse(reader["CommissionTaken"].ToString());
            return action;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            MyAction action = entity as MyAction;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ActionName", action.actionName);
            command.Parameters.AddWithValue("@MinRank", action.minRank);
            command.Parameters.AddWithValue("@CommissionTaken", action.commissionTaken);
        }


        protected override BaseEntity NewEntity()
        {
            return new MyAction() as BaseEntity;
        }
        public ActionList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblAction";
            ActionList list = new ActionList(ExecuteCommand());
            return list;
        }
    }
}
