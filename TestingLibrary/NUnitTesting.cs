using NUnit.Framework;
using NUnit.Framework.Legacy;
using PizzaOrderPortal.Controllers;
using PizzaOrderPortal.Models;
using System.Web.Mvc;

namespace TestingLibrary
{
    [TestFixture]
    public class NUnitTesting
    { 

        [Test]
        public void Test_Pizza_Selection_Page()
        {
            PizzaController controller = new PizzaController();
            var result = controller.SelectedItem(1) as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.Model);
            ClassicAssert.IsInstanceOf(typeof(PizzaModel), result.Model);
        }

        [Test]
        public void Test_Order_Checkout_Page()
        {
            PizzaController controller = new PizzaController();
            controller.TempData["Total_amt"] = 20.0f;
            controller.TempData["Address"] = "Test Address";
            var result = controller.PaymentMode() as ViewResult;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotNull(result.ViewBag.TotalAmt);
            ClassicAssert.IsNotNull(result.ViewBag.Address);
        }
        [Test]
        public void Test_OrderConfirmation_Page()
        {
            string expected = "OrderSuccess";
            PizzaController controller = new PizzaController();
            var result = controller.OrderSuccess() as ViewResult; 
            ClassicAssert.AreEqual(expected, result.ViewName);
        }

    }
}
