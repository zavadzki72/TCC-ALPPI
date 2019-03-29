using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class ProfessorDAO {

        private static Contexto ctx = Singleton.GetInstance();

        #region Listar Professores
        public static List<Professor> listarProfessores() {
            return ctx.professores.ToList();
        }
        #endregion

        #region Buscar Professor Por Algum Atributo
        public static Professor buscarProfessor(string atributo, string valor) {
            try {
                switch(atributo) {
                    case "CPF":
                    long cpf = long.Parse(valor);
                    return ctx.professores.FirstOrDefault(x => x.cpf_Professor == cpf);
                    case "nome":
                    return ctx.professores.FirstOrDefault(x => x.nme_Professor.Equals(valor));
                    case "matricula":
                    long matricula = long.Parse(valor);
                    return ctx.professores.FirstOrDefault(x => x.matricula_Professor == matricula);
                    case "idSexo":
                    int idSexo = int.Parse(valor);
                    return ctx.professores.FirstOrDefault(x => x.sexo.idSexo == idSexo);
                }
            } catch(Exception e) {
                string erro = e.Message;
            }
            return null;
        }
        #endregion

        #region Buscar Professores por Sexo
        public static List<Professor> buscarProfessoresPorSexo(int idSexo) {
            return ctx.professores.Where(x => x.sexo.idSexo==idSexo).ToList();
        }
        #endregion

        #region Cadastrar Professor
        public static Boolean cadastrarProfessor(Professor p) {
            if(buscarProfessor("nome", p.nme_Professor)==null) {
                ctx.professores.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Alterar Professor
        public static bool alterarProfessor(Professor p) {
            if(ctx.professores.FirstOrDefault(x => x.nme_Professor.Equals(p.nme_Professor) && x.cpf_Professor != p.cpf_Professor) == null) {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Remover Professor
        public static void remProfessor(int CPF) {
            Professor p = new Professor();
            p = buscarProfessor("CPFProfessor", CPF.ToString());
            ctx.professores.Remove(p);
            ctx.SaveChanges();
        }
        #endregion

        #region Login Professor
        public static Professor login(string email, string senha) {
            return ctx.professores.FirstOrDefault(x => x.eml_Professor.Equals(email) && x.senha_Professor.Equals(senha));
        }
        #endregion
    }
}