using ALPPI.DAO.Models;
using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPPI.Controllers {
    public class AlunoController: Controller {
        #region Lista de Lições
        public ActionResult LicaoPendente() {
            int idTurma = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[2]);
            return View(LicaoDAO.listLicaoTurma(idTurma));
        }
        #endregion

        public ActionResult EditarResposta(int idPergunta, int idResposta) {
            ViewBag.idPergunta=idPergunta;
            ViewBag.idResposta=idResposta;
            return View();
        }

        public ActionResult ResponderPergunta(int idPergunta) {
            ViewBag.idPergunta=idPergunta;
            return View();
        }

        [HttpPost]
        public ActionResult EditarResposta(int idPergunta, int idResposta, Resposta r) {
            ViewBag.idPergunta=idPergunta;
            ViewBag.idResposta=idResposta;
            int id = Convert.ToInt32(TempData["idLicao"]);
            int idAluno = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[3]);
            if(ModelState.IsValid) {
                r.aluno = AlunoDAO.buscarAluno("id", idAluno.ToString());
                r.pergunta=PerguntaDAO.buscarPerguntaID(idPergunta);
                if(RespostaDAO.addResposta(r)) {
                    ViewBag.sucesso=true;
                    return RedirectToAction("verlicaoaluno/"+id, "aluno");
                } else {
                    ModelState.AddModelError("", "pergunta ja cadastrada!");
                }
            }
            return View(r);
        }

        #region Inserir Respostas em uma Pergunta
        [HttpPost]
        public ActionResult ResponderPergunta(Resposta resposta, int idPergunta) {
            int idAluno = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[3]);
            int id = Convert.ToInt32(TempData["idLicao"]);
            if(ModelState.IsValid) {
                resposta.aluno=AlunoDAO.buscarAluno("id", idAluno.ToString());
                resposta.pergunta=PerguntaDAO.buscarPerguntaID(idPergunta);
                if(RespostaDAO.addResposta(resposta)) {
                    ViewBag.Sucesso=true;
                    return RedirectToAction("VerLicaoAluno/"+id, "Aluno");
                } else {
                    ModelState.AddModelError("", "Pergunta ja cadastrada!");
                }
            }
            return RedirectToAction("VerLicaoAluno/"+id, "Aluno");
        }
        #endregion

        #region View Ver Lições
        public ActionResult VerLicaoAluno(int id) {
            TempData["idLicao"]=id;
            ViewBag.listaDePerguntas=PerguntaDAO.listaPerguntas(id);
            int idAluno = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[3]);
            ViewBag.listaDeRespostas=RespostaDAO.listaRespostas(id, idAluno);
            return View(LicaoDAO.buscarLicaoID(id));
        }
        #endregion

    }
}