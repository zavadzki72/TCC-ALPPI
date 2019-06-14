using ALPPI.DAO.Models;
using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPPI.Controllers {
    public class AdministradorController : Controller{
        #region Lista de Professores
        [Authorize(Roles = "ADM")]
        public ActionResult ListaProfessor() {
            return View(ProfessorDAO.listarProfessores());
        }
        #endregion

        #region Editar Lição [VIEW]
        [HttpGet]
        [Authorize(Roles = "ADM")]
        public ActionResult EditarProfessor(int id) {
            ViewBag.idSexo=new SelectList(SexoDAO.listaSexo(), "idSexo", "nme_Sexo");
            ViewBag.idCidade=new SelectList(CidadeDAO.listaCidades(), "idCidade", "nme_Cidade");
            return View(ProfessorDAO.buscarProfessor("id", id.ToString()));
        }
        #endregion

        #region Editar Lição [POST]
        [HttpPost]
        [Authorize(Roles = "ADM")]
        public ActionResult EditarLicao(Professor p, string data) {
            ViewBag.idSexo=new SelectList(SexoDAO.listaSexo(), "idSexo", "nme_Sexo");
            ViewBag.idCidade=new SelectList(CidadeDAO.listaCidades(), "idCidade", "nme_Cidade");

            Professor pr = ProfessorDAO.buscarProfessor("id", p.idProfessor.ToString());

            try {
                pr.nme_Professor = p.nme_Professor;
                pr.matricula_Professor = p.matricula_Professor;
                pr.cpf_Professor = p.cpf_Professor;
                pr.dta_NascProfessor=Convert.ToDateTime(data);
                if(ProfessorDAO.editarProfessor(pr)) {
                    ViewBag.Sucesso=true;
                    return RedirectToAction("ListaProfessor", "Administrador");
                }
            } catch {
                ModelState.AddModelError("", "Não foi possivel editar esse professor!");
                return View(pr);
            }
            return View(pr);
        }
        #endregion

        #region Inativar Aluno
        public ActionResult InativarProfessor(int id) {
            if(ModelState.IsValid) {
                Professor p = ProfessorDAO.buscarProfessor("id", id.ToString());
                p.flg_Inativo=1;
                if(ProfessorDAO.editarProfessor(p)) {
                    return RedirectToAction("ListaProfessor", "Administrador");
                }
            }
            return RedirectToAction("ListaProfessor", "Administrador");
        }
        #endregion
    }
}