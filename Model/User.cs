using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class User:BaseEntity
    {
        protected string firstName;
        protected string lastName;
        protected string email;
        protected string password;
        
      
        protected DateTime birthday;
        protected bool gender;
        protected string phoneNum;
        protected bool isWorker;
        protected string RealId;
        protected int workerRank;


        [DataMember]
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        [DataMember]
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        [DataMember]
        public string Password { get { return this.password; } set { this.password = value; } }
        [DataMember]
        public string realid { get { return this.RealId; } set { this.RealId = value; } }
        [DataMember]
        public string Email { get { return this.email; } set { this.email = value; } }
        [DataMember]
        public DateTime Birthday { get { return this.birthday; } set { this.birthday = value; } }
        [DataMember]
        public bool Gender { get { return this.gender; } set { this.gender = value; } }
        [DataMember]
        public bool IsWorker { get { return this.isWorker; } set { this.isWorker = value; } }
        [DataMember]
        public string Phonenum { get { return this.phoneNum; } set { this.phoneNum = value; } }
        [DataMember]
        public int WorkerRank { get {return workerRank; } set { value = workerRank; } }
    }
    [CollectionDataContract]
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
