using System;
using System.Collections.Generic;
using System.Text;
using TemaTasLC.Convertor;
using TemaTasLC.ExceptionHandling;

namespace TemaTasLC.Account
{
    public class Account
    {
        private float balanta;
        private float minBalanta = 10;

        public Account()
        {
            balanta = 0;
        }

        public Account(int valoare)
        {
            balanta = valoare;
        }

        public void Depunere(float suma)
        {
            balanta += suma;
        }

        public void Retragere(float suma)
        {
            balanta -= suma;
        }

        public float GetBalance()
        {
            return this.Balanta;
        }

        public void TransferFonduri(Account destinatie, float suma)
        {
            destinatie.Depunere(suma);
            Retragere(suma);
        }

        public Account TransferFonduriMin(Account destinatie, float suma)
        {
            if (Balanta - suma > MinBalanta)
            {
                destinatie.Depunere(suma);
                Retragere(suma);
            }
            else throw new FonduriInsuficiente(suma);
            return destinatie;
        }

        public void TransferEuroInLei(Account destinatie, float sumaeuro, ICurrencyConvertor convertor)
        {
            if (balanta - sumaeuro > minBalanta)
            {
                destinatie.Depunere(convertor.EurToRon(sumaeuro));
                Retragere(convertor.EurToRon(sumaeuro));
            }
            else throw new FonduriInsuficiente(sumaeuro);
        }
        public void TransferLeiInEuro(Account destinatie, float sumalei, ICurrencyConvertor convertor)
        {
            if (balanta - sumalei > minBalanta)
            {
                destinatie.Depunere(convertor.RonToEur(sumalei));
                Retragere(convertor.RonToEur(sumalei));
            }
            else throw new FonduriInsuficiente(sumalei);
        }

        public void TransferLeiFromEuroAccountWithAmmount(Account destinatie, float sumaEuro, ICurrencyConvertor convertor)
        {
            float sumaLei = convertor.EurToRon(sumaEuro);
            destinatie.Depunere(sumaLei);
            Retragere(sumaLei);
        }

        public float Balanta
        {
            get { return balanta; }
        }

        public float MinBalanta
        {
            get { return minBalanta; }
        }
    }

}
