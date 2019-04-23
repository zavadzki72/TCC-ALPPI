using ALPPI.DAO.Models;
using ALPPI.Models;
using System;
using System.Web.Mvc;

namespace ALPPI.Controllers {
    public class ProfessorController : Controller{

        #region Lista de Respostas
        public ActionResult CorrigirLicao(int id) {
            TempData["idLicao22"]=id;
            return View(RespostaDAO.listaRespostasPorIdLicao(id));
        }
        #endregion

        #region Ver Notas
        public ActionResult verNotasLicao(int id) {
            TempData["idLicao22"]=id;
            Licao l = LicaoDAO.buscarLicaoID(id);
            ViewBag.momeLicao = l.nme_Licao;
            ViewBag.idLicao=l.idLicao;
            return View(AlunoDAO.listarAlunos(l.turma.idTurma));
        }
        #endregion

        #region Lista de Lições
        public ActionResult ListaLicao() {
            long CPF = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[1]);
            return View(LicaoDAO.listLicao(CPF));
        }
        #endregion

        #region Lista de Turmas
        public ActionResult ListaTurma() {
            return View(TurmaDAO.listaTurmas(true));
        }
        #endregion

        #region Lista de Alunos
        public ActionResult ListaAluno(int id) {
            return View(AlunoDAO.listarAlunos(id));
        }
        #endregion

        #region View Ver Lições
        public ActionResult VerLicao(int id) {
            long CPF = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[1]);
            TempData["idLicao"]=id;
            ViewBag.listaDePerguntas=PerguntaDAO.listaPerguntas(id);
            return View(LicaoDAO.buscarLicaoID(id));
        }
        #endregion

        #region Link Reativar Lição
        public ActionResult DesConcluirLicao(int id) {
            if(ModelState.IsValid) {
                Licao l = LicaoDAO.buscarLicaoID(id);
                l.flg_Ativo = 0;
                if(LicaoDAO.editarLicao(l)) {
                    return RedirectToAction("ListaLicao", "Professor");
                }
            }
            return RedirectToAction("ListaLicao", "Professor");
        }
        #endregion

        #region Link Concluir Lição
        public ActionResult ConcluirLicao(int id) {
            if(ModelState.IsValid) {
                Licao l = LicaoDAO.buscarLicaoID(id);
                l.flg_Ativo=1;
                if(LicaoDAO.editarLicao(l)) {
                    return RedirectToAction("ListaLicao", "Professor");
                }
            }
            return RedirectToAction("ListaLicao", "Professor");
        }
        #endregion

        #region Inserir Perguntas em uma Lição
        [HttpPost]
        public ActionResult InserirPerguntaLicao(Pergunta pergunta) {
            int id = Convert.ToInt32(TempData["idLicao"]);
            if(ModelState.IsValid) {
                pergunta.licao=LicaoDAO.buscarLicaoID(id);
                if(PerguntaDAO.addPergunta(pergunta)) {
                    //Pergunta p = PerguntaDAO.buscarPergunta(pergunta);
                    //PerguntaDAO.addPergunta(p);
                    ViewBag.Sucesso=true;
                    return RedirectToAction("VerLicao/"+id, "Professor");
                } else {
                    ModelState.AddModelError("", "Pergunta ja cadastrada!");
                }
            }
            return RedirectToAction("VerLicao/"+id, "Professor");
        }
        #endregion

        #region Editar Lição [VIEW]
        [HttpGet]
        public ActionResult EditarLicao(int id) {
            ViewBag.idMateria = new SelectList(MateriaDAO.listaMateria(), "idMateria", "nome");
            ViewBag.idTurma=new SelectList(TurmaDAO.listaTurmas(true), "idTurma", "ano");
            return View(LicaoDAO.buscarLicaoID(id));
        }
        #endregion

        #region Editar Lição [POST]
        [HttpPost]
        public ActionResult EditarLicao(Licao l, string data) {
            ViewBag.idMateria=new SelectList(MateriaDAO.listaMateria(), "idMateria", "nome");
            ViewBag.idTurma=new SelectList(TurmaDAO.listaTurmas(true), "idTurma", "ano");

            Licao li = LicaoDAO.buscarLicaoID(l.idLicao);

            try {
                li.nme_Licao = l.nme_Licao;
                li.Dta_Conclusao_Licao = Convert.ToDateTime(data);
                if(LicaoDAO.editarLicao(li)) {
                    ViewBag.Sucesso=true;
                    return RedirectToAction("ListaLicao", "Professor");
                }
            }catch{
                ModelState.AddModelError("", "Não foi possivel editar sua lição!");
                return View(li);
            }
            return View(li);
        }
        #endregion

        #region Editar Pergunta [VIEW]
        [HttpGet]
        public ActionResult EditarPergunta(int id) {
            return View(PerguntaDAO.buscarPerguntaID(id));
        }
        #endregion

        #region Editar Pergunta [POST]
        [HttpPost]
        public ActionResult EditarPergunta(Pergunta p) {
            Pergunta pe = PerguntaDAO.buscarPerguntaID(p.idPergunta);
            int id = Convert.ToInt32(TempData["idLicao"]);
            try {
                pe.des_Pergunta = p.des_Pergunta;
                if(PerguntaDAO.editarPergunta(pe)) {
                    ViewBag.Sucesso=true;
                    return RedirectToAction("VerLicao/"+pe.licao.idLicao, "Professor");
                }
            } catch{
                ModelState.AddModelError("", "Não foi possivel editar sua Pergunta!");
                return View(pe);
            }
            return View(pe);
        }
        #endregion

        #region Add Avaliação [VIEW]
        public ActionResult AddAvaliacao(int idResposta) {
            ViewBag.idResposta=idResposta;
            return View(RespostaDAO.buscarRespostaporID(idResposta));
        }
        #endregion

        #region Add Avaliação [POST]
        [HttpPost]
        public ActionResult AddAvaliacao(Resposta resposta) {
            var id = TempData["idLicao22"];
            RespostaDAO.editarNota(resposta);
            ViewBag.Sucesso=true;
            return RedirectToAction("CorrigirLicao/"+id, "Professor");
        }
        #endregion

    }
}