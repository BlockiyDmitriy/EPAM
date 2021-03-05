using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task5.BLL.DTO;
using Task5.BLL.Services.Contract;
using Task5.WebClient.Extensions;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Filters;
using Task5.WebClient.Models.Order;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Controllers
{

    [Authorize(Roles = "admin")]
    public class SaleController : Controller
    {
        private const int pageSize = 3;

        private IClientService clientService;
        private IProductService productService;
        private IOrderService orderService;

        public SaleController(IClientService clientService, IProductService productService, IOrderService orderService)
        {
            this.clientService = clientService;
            this.productService = productService;
            this.orderService = orderService;
        }

        // GET: Sale
        public ActionResult Index(int? page)
        {
            ViewBag.CurrentPage = page ?? 1;
            return View();
        }
        public ActionResult OrderSearch(int? page)
        {
            try
            {
                var clientModel = MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get());
                var productModel = MapperHelper.Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productService.Get());
                var orderModel = MapperHelper.Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<HomeOrderViewModel>>(orderService.Get());
                ViewBag.CurrentPage = page;
                return PartialView("List", orderModel.ToPagedList(page ?? 1, pageSize));
            }
            catch
            {
                return View("Error");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderSearch(OrderFilter filterModel)
        {
            var clientModel = MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get());
            var productModel = MapperHelper.Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productService.Get());
            var orderModel = MapperHelper.Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<HomeOrderViewModel>>(orderService.Get());

            var orders = from s in orderModel
                         select s;

            if (filterModel.ClientName != null)
            {
                orders = orders.Where(x => x.ClientName.ToLower().Contains(filterModel.ClientName.ToLower()));
            }
            if (filterModel.DateTime != null)
            {
                orders = orders.Where(x => (x.DateTime.Equals(filterModel.DateTime)));
            }
            if (filterModel.ProductName != null)
            {
                orders = orders.Where(x => x.ProductName.ToLower().Contains(filterModel.ProductName.ToLower()));
            }

            if (orders.ToList().Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView("List", orders.ToPagedList(1, orders.Count() == 0 ? 1 : orders.Count()));
        }

        // GET: Sale/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View("Details");
        }

        // GET: Sale/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Sale/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(CreateOrderViewModel model)
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
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View("Edit");
        }

        // POST: Sale/Edit/5
        [HttpPost]
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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View("Delete");
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
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
