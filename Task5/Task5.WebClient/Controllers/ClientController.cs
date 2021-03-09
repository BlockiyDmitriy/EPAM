using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.BLL.Services.Contract;

namespace Task5.WebClient.Controllers
{
    public class ClientController : Controller
    {
        private const int pageSize = 3;

        private IClientService clientService;

        [Authorize]
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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