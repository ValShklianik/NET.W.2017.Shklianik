using NUnit.Framework;
using Task3.Solution;
using Moq;

namespace Task3.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void IObservableMoqTest()
        {
            Mock<IObservable> mockStock = new Mock<IObservable>();
            mockStock.Setup(mr => mr.Register(It.IsAny<IObserver>())).Callback(() => { Assert.Pass(); });
            IObserver bank = new Bank("Bank 1", mockStock.Object);
           // IObserver broker = new Broker("Brokr 1", mockStock.Object);
           // mockStock.Object.Notify();

        }


    }
}
