using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class CidadeDAO {
        private static Contexto ctx = Singleton.GetInstance();

        public static List<Cidade> listaCidades() {
            return ctx.cidades.ToList();
        }

        public static Cidade cidadeId(int id) {
            return ctx.cidades.FirstOrDefault(c => c.idCidade == id);
        }
    }
}