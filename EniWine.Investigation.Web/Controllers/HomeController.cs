using EnioWine.Core.ServiceProxy;
using EniWine.Investigation.Services.Contracts;
using EniWine.Investigation.Services.Contracts.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EniWine.Investigation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Armas();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region [ Métodos Privados ]

        private void Armas()
        {
            var estado = new WCFServiceInvoker().InvokeService<IInvestigationService, IList<ArmaDTO>>(proxy => proxy.ObterArmas());

            var lista = new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };

            lista.AddRange(new SelectList(estado, "Id", "Nome").ToList());

            ViewBag.ListaArma = lista;
        }

        #endregion [ Métodos Privados ]
    }
}