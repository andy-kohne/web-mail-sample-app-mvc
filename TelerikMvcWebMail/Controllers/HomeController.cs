﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TelerikMvcWebMail.Models;

namespace TelerikMvcWebMail.Controllers
{
    public class HomeController : Controller
    {
        private MailsService mailsService;

        public HomeController()
        {
            mailsService = new MailsService(new WebMailEntities1());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewMail()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(mailsService.Read().ToDataSourceResult(request));
        }

        [ValidateInput(false)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, MailViewModel mail)
        {
            if (mail != null && ModelState.IsValid)
            {
                mailsService.Update(mail);
            }

            return Json(new[] { mail }.ToDataSourceResult(request, ModelState));
        }

        [ValidateInput(false)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, MailViewModel mail)
        {
            if (mail != null && ModelState.IsValid)
            {
                mailsService.Create(mail);
            }

            return Json(new[] { mail }.ToDataSourceResult(request, ModelState));
        }

    }
}
