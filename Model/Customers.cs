using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Customers:User
    {
        private DateTime DateOfJoining;
        private bool IsNative;
        [DataMember]
        public DateTime dateOfJoining { get { return DateOfJoining;} set { DateOfJoining = value; } }
        [DataMember]
        public bool isNative { get { return IsNative; } set { IsNative = value; } }

       
    }
    [CollectionDataContract]
    public class CustomersList : List<Customers>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public CustomersList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public CustomersList(IEnumerable<Customers> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public CustomersList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Customers>().ToList()) { }
    }
}
