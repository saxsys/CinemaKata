using System;
using KinoKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KinoKataTestP
{
    /// <summary>
    /// Summary description for CashierTest
    /// </summary>
    [TestClass]
    public class CashierTest
    {
        public CashierTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfAgeNegative()
        {
            var c = new Cashier(new Movie { Title = "Titanic", OverLength = true });
            c.AddTicket(-1);
        }

        [TestMethod]
        public void ShouldOneChildPayFivePointFiftyIfNoOverlength()
        {
            var c = new Cashier(new Movie {Title = "Harry Potter"});
            c.AddTicket(14);

            Assert.AreEqual(c.GetTotalPrice(),5.5m);
        }

        [TestMethod]
        public void ShouldOneChildPaySixPointFiftyIfOverlength()
        {
            var c = new Cashier(new Movie { Title = "Titanic", OverLength = true});
            c.AddTicket(14);

            Assert.AreEqual(c.GetTotalPrice(), 6.5m);
        }

        [TestMethod]
        public void ShouldOneAdultPayEightPointZeroIfNoOverlength()
        {
            var c = new Cashier(new Movie { Title = "Harry Potter" });
            c.AddTicket(15);

            Assert.AreEqual(c.GetTotalPrice(), 8.0m);
        }

        [TestMethod]
        public void ShouldOneAdultPayNinePointZeroIfOverlength()
        {
            var c = new Cashier(new Movie { Title = "Titanic", OverLength = true });
            c.AddTicket(15);

            Assert.AreEqual(c.GetTotalPrice(), 9.0m);
        }

        [TestMethod]
        public void ShouldTenAdultsPaySixPointZeroPerTicketIfNoOverlength()
        {
            var c = new Cashier(new Movie { Title = "Harry Potter" });
            for (int i = 0; i < 10; i++)
            {
                c.AddTicket(20);
            }

            Assert.AreEqual(c.GetTotalPrice(), 60.0m);
        }

        [TestMethod]
        public void ShouldTenAdultsPaySevenPointZeroPerTicketIfOverlength()
        {
            var c = new Cashier(new Movie { Title = "Titanic", OverLength = true });
            for (int i = 0; i < 10; i++)
            {
                c.AddTicket(20);
            }

            Assert.AreEqual(c.GetTotalPrice(), 70.0m);
        }

        [TestMethod]
        public void ShouldFiveAdultsAndFiveChildrenPayFiftySevenPointFiveIfNoOverlength()
        {
            var c = new Cashier(new Movie { Title = "Harry Potter" });
            for (int i = 0; i < 10; i++)
            {
                c.AddTicket(i%2 == 0 ? 15 : 14);
            }

            Assert.AreEqual(c.GetTotalPrice(), 57.5m);
        }

        [TestMethod]
        public void ShouldFiveAdultsAndFiveChildrenPaySixtySevenPointFiveIfOverlength()
        {
            var c = new Cashier(new Movie { Title = "Titanic", OverLength = true });
            for (int i = 0; i < 10; i++)
            {
                c.AddTicket(i % 2 == 0 ? 15 : 14);
            }

            Assert.AreEqual(c.GetTotalPrice(), 67.5m);
        }
    }
}
