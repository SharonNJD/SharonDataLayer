﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class BaseEntity
    {
        
        protected int id;
        [DataMember]
        public int Id { get { return this.id; } set { id = value; } }
    }
}
