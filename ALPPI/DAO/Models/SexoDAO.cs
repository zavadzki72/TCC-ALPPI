using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class SexoDAO {
        private static Contexto ctx = Singleton.GetInstance();
        public static List<Sexo> listaSexo() {
            return ctx.sexos.ToList();
        }

        public static Sexo sexoId(int id){
            return ctx.sexos.FirstOrDefault(s => s.idSexo == id);
        }
    }
}