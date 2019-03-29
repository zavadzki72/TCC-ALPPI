using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class LicaoDAO {
        private static Contexto ctx = Singleton.GetInstance();

        public static List<Licao> listLicao(long CPF) {
            return ctx.licoes.Where(c => c.professor.cpf_Professor==CPF).OrderByDescending(c => c.dta_Inicio_Licao).
                Include(c => c.conceito).Include(c => c.materia).Include(c => c.turma).Include(c => c.professor).ToList();
        }

        public static List<Licao> listLicaoTurma(int idTurma) {
            return ctx.licoes.Where(x => x.turma.idTurma == idTurma && x.flg_Ativo == 0).OrderByDescending(x => x.dta_Inicio_Licao).
                Include(c => c.conceito).Include(c => c.materia).Include(c => c.turma).Include(c => c.professor).ToList();
        }

        public static Licao buscarLicaoID(int id) {
            return ctx.licoes.FirstOrDefault(x => x.idLicao==id);
        }

        public static Licao buscarLicao(Licao l) {
            if(ctx.licoes.FirstOrDefault(x => x.nme_Licao.Equals(l.nme_Licao))!=null) {
                return ctx.licoes.FirstOrDefault(x => x.nme_Licao.Equals(l.nme_Licao));
            } else {
                return null;
            }
        }

        public static Boolean editarLicao(Licao l) {
            if(ctx.licoes.FirstOrDefault(x => x.idLicao==l.idLicao)!=null) {
                ctx.Entry(l).State=EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Boolean addLicao(Licao l) {
            if(buscarLicao(l)==null) {
                ctx.licoes.Add(l);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}