using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyAction : BaseEntity
    {
        private string ActionName;
        private int MinRank;
        private double CommissionTaken;

        public string actionName { get { return ActionName; } set { ActionName = value; } }
        public int minRank { get { return MinRank; } set { MinRank = value; } }

        public double commissionTaken { get { return CommissionTaken; } set { CommissionTaken = value; } }

        public class ActionList : List<MyAction>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public ActionList() { }
            //המרה אוסף גנרי לרשימת משתמשים
            public ActionList(IEnumerable<MyAction> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת משתמשים
            public ActionList(IEnumerable<BaseEntity> list)
                : base(list.Cast<MyAction>().ToList()) { }
        }
    }
}
