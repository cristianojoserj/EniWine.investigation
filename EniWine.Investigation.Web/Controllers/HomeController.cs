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
            new WCFServiceInvoker().InvokeService<IInvestigationService>(proxy => proxy.SetarNovoCaso());

            Armas();
            Locais();
            Suspeitos();

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

        public JsonResult RespostaCorreta(string idArma, string idLocal, string idSuspeito)
        {
            string vlr = idArma + "," + idLocal + "," + idSuspeito;
            int resp = new WCFServiceInvoker().InvokeService<IInvestigationService, int>(proxy => proxy.TestarResposta(vlr));

            JsonResult result = new JsonResult();
            result.Data = resp;
            return result;
        }

        #region [ Métodos Privados ]

        private void Armas()
        {
            var model = new WCFServiceInvoker().InvokeService<IInvestigationService, IList<ArmaDTO>>(proxy => proxy.ObterArmas());

            var lista = new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };

            lista.AddRange(new SelectList(model, "Id", "Nome").ToList());

            ViewBag.ListaArma = lista;
        }

        private void Locais()
        {
            var model = new WCFServiceInvoker().InvokeService<IInvestigationService, IList<LocalDTO>>(proxy => proxy.ObterLocais());

            var lista = new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };

            lista.AddRange(new SelectList(model, "Id", "Nome").ToList());

            ViewBag.ListaLocal = lista;
        }

        private void Suspeitos()
        {
            var model = new WCFServiceInvoker().InvokeService<IInvestigationService, IList<SuspeitoDTO>>(proxy => proxy.ObterSuspeitos());

            var lista = new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };

            lista.AddRange(new SelectList(model, "Id", "Nome").ToList());

            ViewBag.ListaSuspeito = lista;
        }
        #endregion [ Métodos Privados ]
    }
}