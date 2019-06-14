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

        #region Lista de Lições
        public ActionResult ListaLicoes() {
            ViewBag.idALuno = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[3]);
            return View(LicaoDAO.listLicaoNotId());
        }
        #endregion

        public ActionResult EditarResposta(int idPergunta, int idResposta) {
            ViewBag.DescPergunta=PerguntaDAO.buscarPerguntaID(idPergunta).des_Pergunta;
            ViewBag.idPergunta=idPergunta;
            ViewBag.idResposta=idResposta;
            return View();
        }

        public ActionResult ResponderPergunta(int idPergunta) {
            ViewBag.DescPergunta=PerguntaDAO.buscarPerguntaID(idPergunta).des_Pergunta;
            ViewBag.idPergunta=idPergunta;
            return View();
        }

        [HttpPost]
        public ActionResult EditarResposta(int idPergunta, int idResposta, Resposta r) {
            ViewBag.idPergunta=idPergunta;
            ViewBag.idResposta=idResposta;
            ViewBag.DescPergunta=PerguntaDAO.buscarPerguntaID(idPergunta).des_Pergunta;

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
            ViewBag.DescPergunta=PerguntaDAO.buscarPerguntaID(idPergunta).des_Pergunta;
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

        #region Link Enviar resposta
        public ActionResult EnviarLicao(int idLicao) {
            int idAluno = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[3]);

            Licao l = LicaoDAO.buscarLicaoID(idLicao);
            List<Pergunta> ps = l.perguntas.ToList();
            List<Resposta> rs = new List<Resposta>();
            List<Resposta> rsFinal = new List<Resposta>();
            foreach(Pergunta p in ps){
                List<Resposta> aux = p.respostas.ToList();
                foreach(Resposta r in aux){
                    rs.Add(r);
                }
            }
            foreach(Resposta r in rs){
                if(r.aluno.idAluno == idAluno) {
                    rsFinal.Add(r);
                }
            }

            try {
                foreach(Resposta r in rsFinal) {
                    r.isEnviado=true;
                    RespostaDAO.editarBoolEnviado(r);
                }
                TempData["Sucesso"]=true;
                return RedirectToAction("LicaoPendente", "Aluno");
            } catch {
                TempData["Sucesso"]=false;
                return RedirectToAction("LicaoPendente", "Aluno");
            }
        }
        #endregion

    }
}