using ALPPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ALPPI.DAO.Models {
    public class MateriaDAO {
        private static Contexto ctx = Singleton.GetInstance();
        public static List<Materia> listaMateria() {
            return ctx.materias.ToList();
        }

        public static Materia materiaId(int id) {
            return ctx.materias.FirstOrDefault(m => m.idMateria == id);
        }
    }
}