using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class BankAccount : BaseEntity
    {
        private int BankAcuuntNum;
        private int SecretCode;
        private double Balance;
        private bool Canloan;
        private bool CanTransferOverSeas;
        private bool CanTradeStocks;
        private bool AdultAcouunt;
        private bool PersonalAcouunt;
        private Customers Customers;

        [DataMember]
        public int bankAcuuntNum { get { return BankAcuuntNum; } set { BankAcuuntNum = value; } }
        [DataMember]
        public int secretCode { get { return SecretCode; } set { SecretCode = value; } }
        [DataMember]
        public double balance { get { return Balance; } set { Balance = value; } }
        [DataMember]
        public bool canloan { get { return Canloan; } set { Canloan = value; } }
        [DataMember]
        public bool canTransferOverSeas { get { return CanTransferOverSeas; } set { CanTransferOverSeas = value; } }
        [DataMember]
        public bool canTradeStocks { get { return CanTradeStocks; } set { CanTradeStocks = value; } }
        [DataMember]
        public bool adultAcouunt { get { return AdultAcouunt; } set { AdultAcouunt = value; } }
        [DataMember]
        public bool personalAcouunt { get { return PersonalAcouunt; } set { PersonalAcouunt = value; } }
        [DataMember]
        public Customers customer { get { return Customers; } set { Customers = value; } }

        
       

    }
    [CollectionDataContract]
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
