﻿using CurrencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
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
