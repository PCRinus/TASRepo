using NUnit.Framework;
using TemaTasLC;
using TemaTasLC.Account;
using TemaTasLC.Convertor;
using TemaTasLC.Messages;
using Moq;

namespace TestAccount
{
    [TestFixture]
    public class EuroToLei
    {

        [Test, Category("pass")]
        [TestCase(100, 0, 50, 4.4F)]
        [TestCase(200, 0, 189, 5.0F)]
        [TestCase(200, 0, 1, 3.0F)]
        public void TestMethod_transferFromEuro(int source, int destination, int sum, float convRate)
        {
            var sursa = new Account(source);
            var destiantie = new Account(destination);
            var convertor = new CurrencyConvertorStub(convRate);
            sursa.TransferEuroInLei(destiantie, sum, convertor);

            Assert.AreEqual(destination + convRate * sum, destiantie.Balanta);

        }

        [Test, Category("fail")]
        [TestCase(35, 0, 50, 4.4F)]
        [TestCase(100, 0, 189, 5.0F)]
        [TestCase(200, 0, 699, 3.0F)]
        public void TestMethod_transferFromEuro_Fail(int source, int destination, int sum, float convRate)
        {
            var sursa = new Account(source);
            var destiantie = new Account(destination);
            var convertor = new CurrencyConvertorStub(convRate);
            sursa.TransferEuroInLei(destiantie, sum, convertor);

            Assert.AreEqual(destination + convRate * sum, destiantie.Balanta);

        }

        [Test, Category("pass")]
        [TestCase(100, 0, 50, 4F)]
        public void TestMethod_transferFromLei(int source, int destination, int sum, float convRate)
        {
            var sursa = new Account(source);
            var destiantie = new Account(destination);
            var convertor = new CurrencyConvertorStub(convRate);
            sursa.TransferLeiInEuro(destiantie, sum, convertor);

            Assert.AreEqual(destination + sum / convRate, destiantie.Balanta);
        }

        [Test, Category("fail")]
        [TestCase(100, 0, 50, 4F)]
        public void TestMethod_transferFromLeiFail(int source, int destination, int sum, float convRate)
        {
            var sursa = new Account(source);
            var destiantie = new Account(destination);
            var convertor = new CurrencyConvertorStub(convRate);
            sursa.TransferLeiInEuro(destiantie, sum, convertor);

            Assert.AreEqual(destination + sum / convRate, destiantie.Balanta);
        }

        [Test, Category("Pass")]
        [TestCase(200,150)]

        public void TestTransferLeiFromEuroAccountWithAmmountMock(int destinationBalance, int sourceBalance)
        {
            var sursa = new Account(sourceBalance);
            var destinatie = new Account(destinationBalance);

            var rateEurRon = 4.87F;
            var eurAmount = 15F;
            var convertMock = new Mock<ICurrencyConvertor>();

            convertMock.Setup(curr => curr.EurToRon(eurAmount)).Returns(eurAmount * rateEurRon);

            sursa.TransferLeiFromEuroAccountWithAmmount(destinatie, eurAmount, convertMock.Object);

            Assert.AreEqual(destinationBalance + (rateEurRon * eurAmount), destinatie.Balanta);
            Assert.AreEqual(sourceBalance - (rateEurRon * eurAmount), sursa.Balanta);

            convertMock.Verify(curr => curr.EurToRon(eurAmount), Times.Once);

        }

        [Test, Category("Pass")]
        [TestCase(100, 0, 50, 4.4F)]

        public void TestMethod_transferFromEuro_mock(int a, int b, int c, float r)
        {
            var sursa = new Account(a);
            var destiantie = new Account(b);

            var convertor = new CurrencyConvertorStub(r);
            Logger.log = new MessageHandler();

            sursa.TransferEuroInLei(destiantie, c, convertor);
            Logger.log.Log("method Log was called with message : " + "Depunere");
            Logger.log.Log("method Log was called with message : " + "Retragere");
            Logger.log.Log("method Log was called with message : " + "TransferEuroInLei");
            Logger.log.ExpectedNumberOfCalls(3);

            Assert.AreEqual(true, Logger.log.Verify());
            Assert.AreEqual(b + r * c, destiantie.Balanta);

        }
    }
}
