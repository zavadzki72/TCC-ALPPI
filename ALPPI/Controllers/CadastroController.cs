using ALPPI.DAO.Models;
using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPPI.Controllers {
    public class CadastroController : Controller{

        #region Cadastrar Alunos [VIEW]
        [Authorize(Roles = "PROFESSOR")]
        public ActionResult CadastrarAluno() {
            ViewBag.idTurma=new SelectList(TurmaDAO.listaTurmas(true), "idTurma", "ano_Turma");
            ViewBag.idSexo=new SelectList(SexoDAO.listaSexo(), "idSexo", "nme_Sexo");
            ViewBag.idCidade=new SelectList(CidadeDAO.listaCidades(), "idCidade", "nme_Cidade");
            return View();
        }
        #endregion

        #region Cadastrar Aluno [POST]
        [Authorize(Roles = "PROFESSOR")]
        [HttpPost]
        public ActionResult CadastrarAluno(Aluno aluno, string data, int idSexo, int idTurma, int idCidade) {
            ViewBag.idTurma=new SelectList(TurmaDAO.listaTurmas(true), "idTurma", "ano_Turma");
            ViewBag.idSexo=new SelectList(SexoDAO.listaSexo(), "idSexo", "nme_Sexo");
            ViewBag.idCidade=new SelectList(CidadeDAO.listaCidades(), "idCidade", "nme_Cidade");

            if(ModelState.IsValid) {
                aluno.dta_NascAluno=Convert.ToDateTime(data);

                aluno.sexo=SexoDAO.sexoId(idSexo);
                aluno.turma=TurmaDAO.turmaId(idTurma);
                aluno.cidade=CidadeDAO.cidadeId(idCidade);

                if(AlunoDAO.cadastrarAluno(aluno)) {
                    ViewBag.Sucesso=true;
                    return View();
                } else {
                    ModelState.AddModelError("", "Usuario ja cadastrado!");
                }
            }
            return View(aluno);
        }
        #endregion


        #region Cadastrar Professor [VIEW]
        [Authorize(Roles = "ADM")]
        public ActionResult CadastrarProfessor() {
            ViewBag.idSexo=new SelectList(SexoDAO.listaSexo(), "idSexo", "nme_Sexo");
            ViewBag.idCidade=new SelectList(CidadeDAO.listaCidades(), "idCidade", "nme_Cidade");
            return View();
        }
        #endregion

        #region Cadastrar Professor [POST]
        [Authorize(Roles = "ADM")]
        [HttpPost]
        public ActionResult CadastrarProfessor(Professor professor, string data, int idSexo, int idCidade) {
            ViewBag.idSexo=new SelectList(SexoDAO.listaSexo(), "idSexo", "nme_Sexo");
            ViewBag.idCidade=new SelectList(CidadeDAO.listaCidades(), "idCidade", "nme_Cidade");

            if(ModelState.IsValid) {
                professor.dta_NascProfessor=Convert.ToDateTime(data);

                professor.sexo=SexoDAO.sexoId(idSexo);
                professor.cidade=CidadeDAO.cidadeId(idCidade);

                if(ProfessorDAO.cadastrarProfessor(professor)) {
                    ViewBag.Sucesso=true;
                    return View();
                } else {
                    ModelState.AddModelError("", "Professor ja cadastrado!");
                }
            }
            return View(professor);
        }
        #endregion

        #region Cadastrar Pergunta [VIEW]
        [Authorize(Roles = "PROFESSOR")]
        public ActionResult CadastrarPergunta() {
            return View();
        }
        #endregion

        #region Cadastrar Pergunta [POST]
        [Authorize(Roles = "PROFESSOR")]
        [HttpPost]
        public ActionResult CadastrarPergunta(Pergunta pergunta, int idLicao) {
            if(ModelState.IsValid) {
                if(PerguntaDAO.addPergunta(pergunta)) {
                    ViewBag.Sucesso=true;
                    return View();
                } else {
                    ModelState.AddModelError("", "Pergunta ja cadastrada!");
                }
            }
            return View(pergunta);
        }
        #endregion

        #region Cadastrar Lição [VIEW]
        [Authorize(Roles = "PROFESSOR")]
        public ActionResult CadastrarLicao() {
            ViewBag.idMateria=new SelectList(MateriaDAO.listaMateria(), "idMateria", "nme_Materia");
            ViewBag.idTurma=new SelectList(TurmaDAO.listaTurmas(true), "idTurma", "ano_Turma");
            return View();
        }
        #endregion

        #region Cadastrar Lição [POST]
        [Authorize(Roles = "PROFESSOR")]
        [HttpPost]
        public ActionResult CadastrarLicao(Licao licao, string data, int idTurma, int idMateria) {
            ViewBag.idMateria=new SelectList(MateriaDAO.listaMateria(), "idMateria", "nme_Materia");
            ViewBag.idTurma=new SelectList(TurmaDAO.listaTurmas(true), "idTurma", "ano_Turma");
            if(ModelState.IsValid) {
                string CPFProf = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[1];
                licao.professor = ProfessorDAO.buscarProfessor("CPF", CPFProf);

                licao.dta_Inicio_Licao=DateTime.Now;
                licao.Dta_Conclusao_Licao=Convert.ToDateTime(data);

                licao.flg_Ativo=0;

                licao.conceito=ConceitoDAO.conceitoId(5); //ID 5 = SEM CONCEITO

                licao.materia=MateriaDAO.materiaId(idMateria);

                licao.turma=TurmaDAO.turmaId(idTurma);

                if(LicaoDAO.addLicao(licao)) {
                    ViewBag.Sucesso=true;
                    return View();
                } else {
                    ModelState.AddModelError("", "Uma Lição com o mesmo nome ja foi cadastrada no sistema!");
                }
            }
            return View(licao);
        }
        #endregion
    }
}