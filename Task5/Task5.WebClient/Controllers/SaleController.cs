using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.DAL.Repositories;
using Task5.DAL.Repositories.Contract;
using Task5.DAL.UoW;
using Task5.Domain;
using Task5.WebClient.Extensions;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Order;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Controllers
{
    public class SaleController : Controller
    {
        
        // GET: Sale
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Index(string sortOrder)
        {
            try
            {
                UnitOfWork uOW = new UnitOfWork();
                var clientModel = MapperHelper.Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(uOW.ClientRepository.Get());
                var productModel = MapperHelper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(uOW.ProductRepository.Get());
                var orderModel = MapperHelper.Mapper.Map<IEnumerable<Order>, IEnumerable<HomeOrderViewModel>>(uOW.OrderRepository.Get());

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                ViewBag.ProductSortParm = String.IsNullOrEmpty(sortOrder) ? "product_desc" : "";
                var orders = from s in orderModel
                             select s;
                switch (sortOrder)
                {
                    case "name_desc":
                        orders = orders.OrderByDescending(s => s.Client.Name);
                        break;
                    case "Date":
                        orders = orders.OrderBy(s => s.DateTime);
                        break;
                    case "date_desc":
                        orders = orders.OrderByDescending(s => s.DateTime);
                        break;
                    case "product_desc":
                        orders = orders.OrderBy(s => s.Product.Name);
                        break;
                    default:
                        orders = orders.OrderBy(s => s.Client.Name);
                        break;
                }

                return View(orders);
            }
            catch (Exception)
            {
                return PartialView("Error");
            }

        }

        // GET: Sale/Details/5
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            return View("Details");
        }

        // GET: Sale/Create
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Sale/Create
        [Authorize]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Sale/Edit/5
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View("Edit");
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Sale/Delete/5
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View("Delete");
        }

        // POST: Sale/Delete/5
        [Authorize]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Delete");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
