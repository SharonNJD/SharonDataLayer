using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ActionDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyAction action = new MyAction();
            action.Id =int.Parse(reader["id"].ToString());
            action.actionName = reader["ActionName"].ToString();
            action.minRank = int.Parse(reader["MinRank"].ToString());
            action.commissionTaken = double.Parse(reader["CommissionTaken"].ToString());
            action.adding = bool.Parse(reader["Adding"].ToString());
            action.coinForeign = bool.Parse(reader["CoinForeign"].ToString());
            action.coinSymbol = reader["CoinSymbol"].ToString();
            return action;
        }

        protected override BaseEntity NewEntity()
        {
            return new MyAction() as BaseEntity;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            MyAction action = entity as MyAction;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ActionName", action.actionName);
            command.Parameters.AddWithValue("@MinRank", action.minRank);
            command.Parameters.AddWithValue("@CommissionTaken", action.commissionTaken);
            command.Parameters.AddWithValue("@Adding", action.adding);
            command.Parameters.AddWithValue("@CoinForeign", action.coinForeign);
            command.Parameters.AddWithValue("@CoinSymbol", action.coinSymbol);
            command.Parameters.AddWithValue("@id", action.Id);
        }
        public int Insert(MyAction action)
        {
            command.CommandText = "INSERT INTO tblAction (ActionName,MinRank,CommissionTaken,Adding,CoinForeign,CoinSymbol)" +
                " VALUES (@ActionName,@MinRank,@CommissionTaken,@CoinSymbol,@Adding,@CoinForeign)";
            LoadParameters(action);
            return ExecuteCRUD();
        }

        public int Update(MyAction action)
        {
            command.CommandText = "UPDATE tblAction SET ActionName = @ActionName, MinRank = @MinRank, CommissionTaken = @CommissionTaken,Adding = @Adding,CoinForeign = @CoinForeign,CoinSymbol = @CoinSymbol WHERE id = @id";
            LoadParameters(action);
            return ExecuteCRUD();
        }

        public int Delete(MyAction action)
        {
            command.CommandText = "DELETE FROM tblAction WHERE id =@id";
            LoadParameters(action);
            return ExecuteCRUD();
        }
        

        public ActionList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblAction";
            ActionList list = new ActionList(ExecuteCommand());
            return list;
        }
        public MyAction SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblAction WHERE id="+id;
            ActionList list = new ActionList(ExecuteCommand());
            if (list.Count > 0)
                return list[0];
            return null;
        }
    }
}
