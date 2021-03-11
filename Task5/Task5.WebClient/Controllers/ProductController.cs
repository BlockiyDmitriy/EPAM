using Ninject.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.BLL.DTO;
using Task5.BLL.Services.Contract;
using Task5.WebClient.Extensions;
using Task5.WebClient.Models.Filters;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Controllers
{
    public class ProductController : Controller
    {
        private const int pageSize = 3;

        private readonly IProductService productService;

        private ILogger _logger;
        public ProductController(IProductService productService, ILogger logger)
        {
            this.productService = productService;
            this._logger = logger;
        }

        [Authorize]
        // GET: Client
        public ActionResult Index(int? page)
        {
            _logger.Info("Метод Index, ProductController");
            ViewBag.CurrentPage = page ?? 1;
            return View();
        }
        [Authorize]
        public ActionResult ProductSearch(int? page)
        {
            try
            {
                _logger.Info("Метод ProductSearch, ProductController");
                var productModel = MapperHelper.Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productService.Get());
                ViewBag.CurrentPage = page;
                return PartialView("List", productModel.ToPagedList(page ?? 1, pageSize));
            }
            catch
            {
                _logger.Error("Метод ProductSearch, ProductController, GET");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ProductSearch(ProductFilter filterModel)
        {
            _logger.Info("Метод ProductSearch, ProductController, POST");
            var productModel = MapperHelper.Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productService.Get());

            var products = from s in productModel
                          select s;

            if (filterModel.Name != null)
            {
                products = products.Where(x => x.Name.ToLower().Contains(filterModel.Name.ToLower()));
            }

            if (products.ToList().Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView("List", products.ToPagedList(1, products.Count() == 0 ? 1 : products.Count()));
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Create
        public ActionResult Create(int? page)
        {
            _logger.Info("Метод Create, ProductController, GET");
            var model = new CreateProductViewModel();
            ViewBag.CurrentPage = page;
            return View(model);
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model, int? page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.Info("Метод Create, ProductController, POST");
                    productService.Create(MapperHelper.Mapper.Map<CreateProductViewModel, ProductDTO>(model));
                    return RedirectToAction("Index", new { page = page });
                }
                _logger.Warn("Метод Create, ProductController, POST, ошибка с влидацией");
                return View();
            }
            catch
            {
                _logger.Error("Метод Create, ProductController, POST");
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Edit/5
        public ActionResult Edit(int id, int? page)
        {
            _logger.Info("Метод Edit, ProductController, GET");
            ViewBag.CurrentPage = page;
            return View(MapperHelper.Mapper.Map<ProductDTO, EditProductViewModel>(productService.Get(id)));
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model, int? page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.Info("Метод Edit, ProductController, POST");
                    productService.Update(MapperHelper.Mapper.Map<EditProductViewModel, ProductDTO>(model));
                    return RedirectToAction("Index", new { page = page });
                }
                _logger.Warn("Метод Edit, ProductController, POST, ошибка с влидацией");
                return View();
            }
            catch
            {
                _logger.Error("Метод Edit, ProductController, POST");
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Delete/5
        public ActionResult Delete(int id, int? page)
        {
            _logger.Info("Метод Delete, ProductController, GET");
            ViewBag.CurrentPage = page;
            return View(MapperHelper.Mapper.Map<ProductDTO, ProductViewModel>(productService.Get(id)));
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductViewModel model, int? page)
        {
            try
            {
                _logger.Info("Метод Delete, ProductController, POST");
                productService.Remove(MapperHelper.Mapper.Map<ProductViewModel, ProductDTO>(model));
                return RedirectToAction("Index", new { page = page });
            }
            catch
            {
                _logger.Error("Метод Delete, ProductController, POST");
                return View("Delete");
            }
        }
    }
}
