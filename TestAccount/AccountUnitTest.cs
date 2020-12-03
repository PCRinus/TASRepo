using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TemaTasLC.Account;
using TemaTasLC.ExceptionHandling;

namespace TestAccount
{
    [TestFixture]
    public class AccountUnitTest
    {
        Account sursa;
        Account destinatie;


        [SetUp]
        public void InitAccount()
        {

            sursa = new Account();
            sursa.Depunere(200.00F); //200 tip float
            destinatie = new Account();
            destinatie.Depunere(150.00F);
        }

        [Test]
        [Category("Pass")]
        public void TransferFonduri()
        {

            sursa.TransferFonduri(destinatie, 100.00F);


            NUnit.Framework.Assert.AreEqual(250.00F, destinatie.Balanta);
            NUnit.Framework.Assert.AreEqual(100.00F, sursa.Balanta);

        }

        [Test, Category("pass")]
        [TestCase(200, 0, 78)]
        [TestCase(200, 0, 189)]
        [TestCase(200, 0, 1)]
        public void TransferFonduriMin(int source, int destination, int sum)
        {

            Account sursa = new Account();
            sursa.Depunere(source);
            Account destinatie = new Account();
            destinatie.Depunere(destination);

            sursa.TransferFonduriMin(destinatie, sum);
            NUnit.Framework.Assert.AreEqual(sum, destinatie.Balanta);
        }

        [Test, ExpectedException(typeof(FonduriInsuficiente)), Category("Fail")]
        [TestCase(200, 150, 345)]
        [TestCase(100, 100, 255)]

        public void TransferFonduriMinFail(int source, int destination, int sum)
        {
            Account sursa = new Account();
            sursa.Depunere(source);
            Account destinatie = new Account();
            destinatie.Depunere(destination);

            destinatie = sursa.TransferFonduriMin(destinatie, sum);

        }

        [Test, ExpectedException(typeof(FonduriInsuficiente))]
        [Category("fail")]
        [Combinatorial]

        public void TransferFonduriMinFailAll([Values(200, 500)] int source, [Values(0, 20)] int destination, [Values(190, 345)] int sum)
        {
            Account sursa = new Account();
            sursa.Depunere(source);
            Account destinatie = new Account();
            destinatie.Depunere(destination);
            destinatie = sursa.TransferFonduriMin(destinatie, sum);

        }
    }
}