using CurrencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static CurrencyModel.Currency;

namespace CurrencyService
{
    [ServiceContract]
    public interface ICurrencyService
    {
        [OperationContract]
        CurrencyList GetAllCurrencies();

        [OperationContract]
        double Convert(Currency source, Currency dest, double amount);

    }
}
