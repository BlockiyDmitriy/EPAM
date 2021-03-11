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

    public class SaleController : Controller
    {
        private const int pageSize = 3;

        private readonly IClientService clientService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

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
        [Authorize]
        public ActionResult OrderSearch(int? page)
        {
            try
            {
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
        [Authorize]
        public ActionResult OrderSearch(OrderFilter filterModel)
        {
            var orderModel = MapperHelper.Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<HomeOrderViewModel>>(orderService.Get());

            var orders = from s in orderModel
                         select s;

            if (filterModel.DateTime != null)
            {
                orders = orders.Where(x => (x.DateTime.Equals(filterModel.DateTime)));
            }
            if (filterModel.ClientName != null)
            {
                orders = orders.Where(x => x.Client.Name.ToLower().Contains(filterModel.ClientName.ToLower()));
            }
            if (filterModel.ProductName != null)
            {
                orders = orders.Where(x => x.Product.Name.ToLower().Contains(filterModel.ProductName.ToLower()));
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
            return PartialView(MapperHelper.Mapper.Map<OrderDTO, DetailsOrderViewModel>(orderService.Get(id)));
        }

        // GET: Sale/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create(int? page)
        {
            var model = new CreateOrderViewModel()
            {
                Clients = new SelectList(MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get()), "Name", "Name"),
                Products = new SelectList(MapperHelper.Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productService.Get()), "Name", "Name")
            };
            ViewBag.CurrentPage = page;
            return View(model);
        }

        // POST: Sale/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(CreateOrderViewModel model, int? page)
        {
            if (!ModelState.IsValid)
            {
                model.Clients = new SelectList(MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get()), "Name", "Name");
                model.Products = new SelectList(MapperHelper.Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productService.Get()), "Name", "Name");

                return View(model);
            }
            try
            {
                orderService.Create(MapperHelper.Mapper.Map<CreateOrderViewModel, OrderDTO>(model));
                return RedirectToAction("Index", new { page = page });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Sale/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, int? page)
        {
            ViewBag.CurrentPage = page;
            return View(MapperHelper.Mapper.Map<OrderDTO, EditOrderViewModel>(orderService.Get(id)));
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(EditOrderViewModel model, int? page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderService.Update(MapperHelper.Mapper.Map<EditOrderViewModel, OrderDTO>(model));
                    return RedirectToAction("Index", new { page = page });
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, int? page)
        {
            ViewBag.CurrentPage = page;
            return View(MapperHelper.Mapper.Map<OrderDTO, HomeOrderViewModel>(orderService.Get(id)));
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(HomeOrderViewModel model, int? page)
        {
            try
            {
                orderService.Remove(MapperHelper.Mapper.Map<HomeOrderViewModel, OrderDTO>(model));
                return RedirectToAction("Index", new { page = page });
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
