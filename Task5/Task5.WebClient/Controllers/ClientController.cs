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

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [Authorize]
        // GET: Client
        public ActionResult Index(int? page)
        {
            ViewBag.CurrentPage = page ?? 1;
            return View();
        }

        public ActionResult ClientSearch(int? page)
        {
            try
            {
                var clientModel = MapperHelper.Mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientViewModel>>(clientService.Get());
                ViewBag.CurrentPage = page;
                return PartialView("List", clientModel.ToPagedList(page ?? 1, pageSize));
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientSearch(ClientFilter filterModel)
        {
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
                    clientService.Create(MapperHelper.Mapper.Map<CreateClientViewModel, ClientDTO>(model));
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
        // GET: Client/Edit/5
        public ActionResult Edit(int id, int? page)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(EditClientViewModel model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Delete/5
        public ActionResult Delete(int id, int? page)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientViewModel model, int? page)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}