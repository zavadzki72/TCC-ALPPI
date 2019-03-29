using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPPI.DAO {
    public class Singleton {
        private static Contexto contexto;
        private Singleton(){}
        public static Contexto GetInstance() {
            if(contexto==null)
                contexto=new Contexto();

            return contexto;
        }
    }
}