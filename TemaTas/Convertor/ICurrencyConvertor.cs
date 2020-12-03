using System;
using System.Collections.Generic;
using System.Text;

namespace TemaTasLC.Convertor
{
    public interface ICurrencyConvertor
    {
        float EurToRon(float ValueInEur);
        float RonToEur(float ValueInRon);
    }
}
