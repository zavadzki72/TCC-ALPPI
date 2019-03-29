using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class TurmaDAO {
        private static Contexto ctx = Singleton.GetInstance();
        public static List<Turma> listaTurmas(bool dropdawn = false) {
            if(dropdawn) {
                return ctx.turmas.Where(x => x.ano_Turma !=1 ).ToList();
            } else {
                return ctx.turmas.ToList();
            }
        }

        public static Turma turmaId(int id) {
            return ctx.turmas.FirstOrDefault(t => t.idTurma == id);
        }
    }
}