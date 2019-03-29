using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class ConceitoDAO {
        private static Contexto ctx = Singleton.GetInstance();

        public static List<Conceito> listaConceito() {
            return ctx.conceitos.ToList();
        }

        public static Conceito conceitoId(int id) {
            return ctx.conceitos.FirstOrDefault(c => c.idConceito == id);
        }
    }
}