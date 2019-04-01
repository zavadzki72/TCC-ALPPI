using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class AlunoDAO {

        private static Contexto ctx = Singleton.GetInstance();

        #region Listar Alunos
        public static List<Aluno> listarAlunos(int idTurma) {
            return ctx.alunos.Where(x => x.turma.idTurma == idTurma).Include(x => x.turma).Include(x => x.sexo).Include(x => x.cidade).ToList();
        }
        #endregion

        #region Buscar Aluno Por Algum Atributo
        public static Aluno buscarAluno(string atributo, string valor) {
            try {
                switch(atributo) {
                    case "id":
                    int pInt = int.Parse(valor);
                    return ctx.alunos.FirstOrDefault(x => x.idAluno ==pInt);
                    case "nome":
                    return ctx.alunos.FirstOrDefault(x => x.nme_Aluno.Equals(valor));
                    case "matricula":
                    pInt = int.Parse(valor);
                    return ctx.alunos.FirstOrDefault(x => x.matricula_Aluno==pInt);
                    case "idSexo":
                    pInt = int.Parse(valor);
                    return ctx.alunos.FirstOrDefault(x => x.sexo.idSexo ==pInt);
                    case "idTurma":
                    pInt = int.Parse(valor);
                    return ctx.alunos.FirstOrDefault(x => x.turma.idTurma ==pInt);
                }
            } catch(Exception e) {
                string erro = e.Message;
            }
            return null;
        }
        #endregion

        #region Cadastrar Aluno
        public static Boolean cadastrarAluno(Aluno a) {
            if(buscarAluno("matricula", a.matricula_Aluno.ToString()) == null) {
                ctx.alunos.Add(a);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Alterar Aluno
        public static bool alterarAluno(Aluno a) {
            if(ctx.alunos.FirstOrDefault(x => x.nme_Aluno.Equals(a.nme_Aluno) && x.idAluno != a.idAluno) == null) {
                ctx.Entry(a).State=EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Remover Aluno
        public static void remAluno(int id) {
            Aluno a = new Aluno();
            a=buscarAluno("id", id.ToString());
            ctx.alunos.Remove(a);
            ctx.SaveChanges();
        }
        #endregion

        #region Login Aluno
        public static Aluno login(string nome, long matricula) {
            return ctx.alunos.Include(a => a.turma).FirstOrDefault(a => a.nme_Aluno.Equals(nome) && a.matricula_Aluno== matricula);
        }
        #endregion
    }
}