using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class AdministradorDAO {

        private static Contexto ctx = Singleton.GetInstance();

        #region Listar Adms
        public static List<Administrador> listarAdministradores() {
            return ctx.administradores.ToList();
        }
        #endregion

        #region Buscar Adms Por Id
        public static Administrador buscarAdministradorId(int id) {
            return ctx.administradores.FirstOrDefault(a => a.idAdminitrador == id);
        }
        #endregion

        #region Login Adm
        public static Administrador login(string email, string senha) {
            return ctx.administradores.FirstOrDefault(x => x.eml_Administrador.Equals(email) && x.senha_Administrador.Equals(senha));
        }
        #endregion
    }
}