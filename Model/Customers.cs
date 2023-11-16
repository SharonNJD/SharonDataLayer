using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customers:User
    {
        private DateTime DateOfJoining;
        private bool IsNative;
        private User user;

        public User User { get { return user; } set { user = value; } }
        public DateTime dateOfJoining { get { return DateOfJoining;} set { DateOfJoining = value; } }
        public bool isNative { get { return IsNative; } set { IsNative = value; } }

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
}
