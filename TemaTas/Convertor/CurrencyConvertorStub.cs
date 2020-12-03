using System;
using System.Collections.Generic;
using System.Text;

namespace TemaTasLC.Convertor
{
    public class CurrencyConvertorStub : ICurrencyConvertor
    {
        float rateEurRon;
        public CurrencyConvertorStub(float _rateEurRon)
        {
            rateEurRon = _rateEurRon;
        }

        public float EurToRon(float ValueInEur)
        {
            return ValueInEur * rateEurRon;
        }

        public float RonToEur(float ValueInRon)
        {
            return ValueInRon / rateEurRon;
        }
    }
}
