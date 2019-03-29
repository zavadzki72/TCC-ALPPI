using ALPPI.DAO.Models;
using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ALPPI.Controllers{
    public class ContaController : Controller{
        public ActionResult LogarProfessor(){
            return View();
        }

        #region Professor Login
        [HttpPost]
        public ActionResult LogarProfessor([Bind(Include = "eml_Professor,senha_Professor")] Professor professor) {
            Professor p = ProfessorDAO.login(professor.eml_Professor, professor.senha_Professor);
            Administrador a = AdministradorDAO.login(professor.eml_Professor, professor.senha_Professor);
            if(p!=null) {
                FormsAuthentication.SetAuthCookie(p.eml_Professor+"|"+p.cpf_Professor+"|"+p.nme_Professor, true);
                return RedirectToAction("Index", "Home");
            } else if(a!=null){
                FormsAuthentication.SetAuthCookie(a.eml_Administrador+"|"+a.idAdminitrador+"|"+a.nme_Administrador, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "O Email/Senha estão incorretos!");
            return View(professor);
        }
        #endregion

        public ActionResult LogarAluno() {
            return View();
        }

        #region Aluno Login
        [HttpPost]
        public ActionResult LogarAluno(Aluno aluno) {
            Aluno a = AlunoDAO.login(aluno.nme_Aluno, aluno.matricula_Aluno);
            if(a != null) {
                FormsAuthentication.SetAuthCookie(a.matricula_Aluno+"|"+a.nme_Aluno+"|"+a.turma.idTurma+"|"+a.idAluno, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Aluno ainda não cadastrado, Comunique seu Professor!");
            return View(aluno);
        }
        #endregion

        #region Deslogar
        public ActionResult Deslogar() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}