using PizzaManager;
using PizzaOrderPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PizzaOrderPortal.Controllers
{
    public class PizzaController : Controller
    {
        public PizzaDAL dal;
        public PizzaController()
        {
            dal = new PizzaDAL();   
        }
        public ActionResult Index(string item)
        {
            List<PizzaMaster> plist = dal.PizzaDetails();
            List<PizzaModel> modellist = new List<PizzaModel>();
            foreach (PizzaMaster pizza in plist)
            {
                PizzaModel model = new PizzaModel() { Id = pizza.Id, Type = pizza.Type, Price = pizza.Price };
                modellist.Add(model);
            }
            if (modellist == null)
            {
                return View(new List<PizzaModel>());
            }

            var searchResults = modellist
                .Where(i => i.Type != null && (item == null || i.Type.ToLower().Contains(item.ToLower())))
                .Select(i => new PizzaModel { Id = i.Id, Type = i.Type, Price = i.Price })
                .ToList();

            ViewBag.SearchTerm = item;

            return View(searchResults);
        }
        public ActionResult SelectedItem(int id)
        {
            int food_id = id;
            List<PizzaMaster> plist = dal.PizzaDetails();
            PizzaMaster item = plist.Find(p=>p.Id== food_id);
            PizzaModel model = new PizzaModel() { Id = item.Id, Type = item.Type, Price = item.Price };
            TempData["Price"] = model.Price;
            TempData["Type"] = model.Type;
            TempData.Keep();
            return View(model);
        }

        [HttpPost]
        public ActionResult SelectedItem(int itemqty, string address)
        {
            if (TempData["Type"] != null && TempData["Price"] != null)
            {
                string fooditem = TempData["Type"].ToString();
                float price = Convert.ToSingle(TempData["Price"]);
                float Total_Amt = price * itemqty;
                TempData["Total_amt"] = Total_Amt;
                TempData["Address"] = address;
                TempData.Keep();
                return RedirectToAction("PaymentMode");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult PaymentMode()
        {
            ViewBag.TotalAmt = Convert.ToSingle(TempData["Total_amt"]);
            ViewBag.Address = TempData["Address"].ToString();
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = 15;
            string randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            TempData["orderid"] = randomString;
            return View();
        }
        public ActionResult OrderSuccess()
        {
            TempData["OrderId"] = TempData["orderid"];
            return View("OrderSuccess");
        }

    }
}