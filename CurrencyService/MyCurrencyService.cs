using CurrencyBL;
using CurrencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CurrencyModel.Currency;

namespace CurrencyService
{
    public class MyCurrencyService : ICurrencyService
    {
        public CurrencyList GetAllCurrencies()
        {
            CurrenciesManager manager = new CurrenciesManager();
            return manager.GetCurrencyList();
        }

        public double Convert(Currency source, Currency dest, double amount)
        {
            CurrenciesManager manager = new CurrenciesManager();
            return manager.Convert(source, dest, amount);
        }
    }

}
