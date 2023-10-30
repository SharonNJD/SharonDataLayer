using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:BaseEntity
    {
        protected string firstName;
        protected string lastName;
        protected string email;
        protected string password;
        
      
        protected DateTime birthday;
        protected bool gender;
        protected string phoneNum;
        protected bool isManager;
        protected string RealId; 
        
        

        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LirstName { get { return this.lastName; } set { this.lastName = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public string realid { get { return this.RealId; } set { this.RealId = value; } }

        public string Email { get { return this.email; } set { this.email = value; } }

        public DateTime Birthday { get { return this.birthday; } set { this.birthday = value; } }
        public bool Gender { get { return this.gender; } set { this.gender = value; } }
        public bool ismanager { get { return this.isManager; } set { this.isManager = value; } }

        public string Phonenum { get { return this.phoneNum; } set { this.phoneNum = value; } }

        
    }
    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }

}
