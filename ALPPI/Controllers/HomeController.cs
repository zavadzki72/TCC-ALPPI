﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPPI.Controllers {
    public class HomeController: Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Materias() {
            return View();
        }

        public ActionResult Professores() {
            return View();
        }

        public ActionResult Sobre() {
            return View();
        }
    }
}