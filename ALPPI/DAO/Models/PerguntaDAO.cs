using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class PerguntaDAO {
        private static Contexto ctx = Singleton.GetInstance();

        public static List<Pergunta> listaPerguntas(int idLicao) {
            return ctx.perguntas.Where(x => x.licao.idLicao == idLicao).ToList();
        }

        public static Pergunta buscarPergunta(Pergunta p) {
            if(ctx.perguntas.FirstOrDefault(x => x.des_Resposta_Padrao_Pergunta.Equals(p.des_Resposta_Padrao_Pergunta))!=null) {
                return ctx.perguntas.FirstOrDefault(x => x.des_Resposta_Padrao_Pergunta.Equals(p.des_Resposta_Padrao_Pergunta));
            } else {
                return null;
            }
        }

        public static Pergunta buscarPerguntaID(int id) {
            if(ctx.perguntas.FirstOrDefault(x => x.idPergunta==id)!=null) {
                return ctx.perguntas.FirstOrDefault(x => x.idPergunta==id);
            } else {
                return null;
            }
        }

        public static Boolean editarPergunta(Pergunta p) {
            if(ctx.perguntas.FirstOrDefault(x => x.idPergunta==p.idPergunta)!=null) {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Boolean addPergunta(Pergunta p) {
            if(buscarPergunta(p)==null) {
                ctx.perguntas.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

    }
}