using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CurrencyModel
{
    [DataContract]
    public class Currency
    {
        private string key;
        private string symbol;
        private double rate;
        private double change;
        private int unit;
        [DataMember]
        public string Key { get { return key; } set { key = value; } }
        [DataMember]
        public string Symbol { get { return symbol; } set { symbol = value; } }
        [DataMember]
        public double Rate { get { return rate; } set { rate = value; } }
        [DataMember]
        public double Change { get { return change; } set { change = value; } }
        [DataMember]
        public int Unit { get { return unit; } set { unit = value; } }
    }

    [CollectionDataContract]
    public class CurrencyList : List<Currency>
    {
        public CurrencyList() { }
        public CurrencyList(IEnumerable<Currency> list) : base(list) { }
    }
}
