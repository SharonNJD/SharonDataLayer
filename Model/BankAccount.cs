using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BankAccount : BaseEntity
    {
        private int BankAcuuntNum;
        private int SecretCode;
        private bool Canloan;
        private bool CanTransferOverSeas;
        private bool CanTradeStocks;
        private bool AdultAcouunt;
        private bool PersonalAcouunt;
        private int CustomerId;


        public int bankAcuuntNum { get { return BankAcuuntNum; } set { BankAcuuntNum = value; } }
        public int secretCode { get { return SecretCode; } set { SecretCode = value; } }
        public bool canloan { get { return Canloan; } set { Canloan = value; } }
        public bool canTransferOverSeas { get { return CanTransferOverSeas; } set { CanTransferOverSeas = value; } }
        public bool canTradeStocks { get { return CanTradeStocks; } set { CanTradeStocks = value; } }
        public bool adultAcouunt { get { return AdultAcouunt; } set { AdultAcouunt = value; } }
        public bool personalAcouunt { get { return PersonalAcouunt; } set { PersonalAcouunt = value; } }

        public int customerId { get { return CustomerId; } set { CustomerId = value; } }
        public class BankAccountList : List<BankAccount>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public BankAccountList() { }
            //המרה אוסף גנרי לרשימת משתמשים
            public BankAccountList(IEnumerable<BankAccount> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת משתמשים
            public BankAccountList(IEnumerable<BaseEntity> list)
                : base(list.Cast<BankAccount>().ToList()) { }
        }

    }
}
