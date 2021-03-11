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
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Filters;

namespace Task5.WebClient.Controllers
{
    public class ClientController : Controller
    {
        private const int pageSize = 3;

        private readonly IClientService clientService;

        private ILogger _logger;
        public ClientController(IClientService clientService, ILogger logger)
        {
            this.clientService = clientService;
            this._logger = logger;
        }

        // GET: Client
        public ActionResult Index(int? page)
        {
            _logger.Info("Метод Index, ClientController");
            ViewBag.CurrentPage = page ?? 1;
            return View();
        }
        [Authorize]
        public ActionResult ClientSearch(int? page)
        {
            try
            {
                _logger.Info("Метод ClientSearch, ClientController, GET");
                var clientModel = MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get());
                ViewBag.CurrentPage = page;
                return PartialView("List", clientModel.ToPagedList(page ?? 1, pageSize));
            }
            catch
            {
                _logger.Error("Метод ClientSearch, ClientController, GET");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ClientSearch(ClientFilter filterModel)
        {
            _logger.Info("Метод ClientSearch, ClientController, POST");
            var clientModel = MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get());

            var clients = from s in clientModel
                          select s;

            if (filterModel.Name != null)
            {
                clients = clients.Where(x => x.Name.ToLower().Contains(filterModel.Name.ToLower()));
            }

            if (clients.ToList().Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView("List", clients.ToPagedList(1, clients.Count() == 0 ? 1 : clients.Count()));
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Create
        public ActionResult Create(int? page)
        {
            _logger.Info("Метод ClientSearch, ClientController, GET");
            var model = new CreateClientViewModel();
            ViewBag.CurrentPage = page;
            return View(model);
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(CreateClientViewModel model, int? page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.Info("Метод Create, ClientController, POST");
                    clientService.Create(MapperHelper.Mapper.Map<CreateClientViewModel, ClientDTO>(model));
                    return RedirectToAction("Index", new { page = page });
                }
                _logger.Error("Метод Create, ClientController, POST, ошибка с влидацией");
                return View();
            }
            catch
            {
                _logger.Error("Метод Create, ClientController, POST");
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Edit/5
        public ActionResult Edit(int id, int? page)
        {
            _logger.Info("Метод Edit, ClientController, GET");
            ViewBag.CurrentPage = page;
            return View(MapperHelper.Mapper.Map<ClientDTO, EditClientViewModel>(clientService.Get(id)));
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(EditClientViewModel model, int? page)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.Info("Метод Edit, ClientController, POST");
                    clientService.Update(MapperHelper.Mapper.Map<EditClientViewModel, ClientDTO>(model));
                    return RedirectToAction("Index", new { page = page });
                }
                _logger.Error("Метод Edit, ClientController, POST, ошибка с влидацией");
                return View();
            }
            catch
            {
                _logger.Error("Метод Edit, ClientController, POST");
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Delete/5
        public ActionResult Delete(int id, int? page)
        {
            _logger.Info("Метод Delete, ClientController, GET");
            ViewBag.CurrentPage = page;
            return View(MapperHelper.Mapper.Map<ClientDTO, ClientViewModel>(clientService.Get(id)));
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientViewModel model, int? page)
        {
            try
            {
                _logger.Info("Метод Delete, ClientController, POST");
                clientService.Remove(MapperHelper.Mapper.Map<ClientViewModel, ClientDTO>(model));
                return RedirectToAction("Index", new { page = page });
            }
            catch
            {
                _logger.Error("Метод Delete, ClientController, POST");
                return View("Delete");
            }
        }
    }
}