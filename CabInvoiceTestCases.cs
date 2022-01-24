using NUnit.Framework;
using CabInvoiceGenrator;

namespace CabInvoiceTestCases
{
    public class Tests
    {
        //invoiceGenrator refernce
        InvoiceGenrator voice = null;

        [Test]
        public void GivenDistanceAndTime_Should_ReturnsTotalFare()
        {
            voice = new InvoiceGenrator(InvoiceGenrator.RideType.Normal);
            double distance = 2.0;
            int time = 5;
            double fare=voice.CalculateFare(distance, time);
            double fareExpected = 25;

            Assert.AreEqual(fare, fareExpected);
        }

        [Test]
        public void GivenMultipleRides_ShouldReturnsATotalFare()
        {
            RefactorInvoiceGenrator invoice = new RefactorInvoiceGenrator(RefactorInvoiceGenrator.RideType.Normal);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 2) };
            InvoiceSummary summary = invoice.calculateFare(rides);
            InvoiceSummary ExpectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(summary, ExpectedSummary);


        }
    }
}