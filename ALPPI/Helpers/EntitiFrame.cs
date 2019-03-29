using ALPPI.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALPPI.Helpers {
    public class EntitiFrame {

        private static Contexto ctx = Singleton.GetInstance();
        public static void RefreshAll() {
            foreach(var entity in ctx.ChangeTracker.Entries()) {
                entity.Reload();
            }
        }

    }
}