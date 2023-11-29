using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class AccountAction : BaseEntity
    {
        private MyAction action;
        private BankAccount bankAccount;
        private double amount;
        private DateTime timesamp;
        [DataMember]
        public MyAction Action { get { return action; } set { action = value; } }
        [DataMember]
        public BankAccount BankAccount { get { return bankAccount; } set { bankAccount = value; } }
        [DataMember]
        public double Amount { get { return amount; } set { amount = value; } }
        [DataMember]
        public DateTime TimaStamp { get { return timesamp; } set { timesamp = value; } }

    }
    [CollectionDataContract]
    public class AccountActionList : List<AccountAction>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public AccountActionList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public AccountActionList(IEnumerable<AccountAction> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public AccountActionList(IEnumerable<BaseEntity> list)
            : base(list.Cast<AccountAction>().ToList()) { }
    }
}
