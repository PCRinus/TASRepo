using System;
using System.Collections.Generic;
using System.Text;

namespace TemaTasCasapu.Account
{
    public class InternalAccountSpy : Account
    {
        List<String> actions = new List<string>();
        public new void Depunere(float amount)
        {
            base.Depunere(amount);
            actions.Add("Deposit " + amount);
        }

        public new void Retragere(float amount)
        {
            base.Retragere(amount);
            actions.Add("Withdraw " + amount);
        }

        public List<String> GetActions()
        {
            return actions;
        }
    }
}
