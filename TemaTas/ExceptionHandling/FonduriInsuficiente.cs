using System;
using System.Collections.Generic;
using System.Text;

namespace TemaTasLC.ExceptionHandling
{
    public class FonduriInsuficiente : Exception
    {
        private float Amount;

        public FonduriInsuficiente(float amount)
        {
            this.Amount = amount;
        }


        public override String ToString()
        {
            return "Nu poti sa retragi " + this.Amount;
        }

    }
}
