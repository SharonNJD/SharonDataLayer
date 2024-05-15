using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class MyAction : BaseEntity
    {
        private string ActionName;
        private int MinRank;
        private double CommissionTaken;
        private bool Adding;
        private bool CoinForeign;
        private string CoinSymbol;
        [DataMember]
        public string actionName { get { return ActionName; } set { ActionName = value; } }
        [DataMember]
        public int minRank { get { return MinRank; } set { MinRank = value; } }
        [DataMember]
        public double commissionTaken { get { return CommissionTaken; } set { CommissionTaken = value; } }
        [DataMember]
        public string coinSymbol { get { return CoinSymbol; } set { CoinSymbol = value; } }
        [DataMember]
        public bool adding { get { return Adding; } set { Adding = value; } }
        [DataMember]
        public bool coinForeign { get { return CoinForeign; } set { CoinForeign = value; } }

    }
    [CollectionDataContract]
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
