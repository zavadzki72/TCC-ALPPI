using ALPPI.Helpers;
using ALPPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ALPPI.DAO.Models {
    public class RespostaDAO {

        private static Contexto ctx = Singleton.GetInstance();

        public static List<Resposta> listaRespostas(int idLicao, int idAluno) {
            return ctx.respostas.Where(r => r.aluno.idAluno == idAluno && idLicao == r.pergunta.licao.idLicao).
                Include(r => r.aluno).
                Include(r => r.pergunta)
                .ToList();
        }

        public static List<Resposta> listaRespostasPorIdLicao(int idLicao) {
            List<Resposta> lista = ctx.respostas.Where(r => idLicao==r.pergunta.licao.idLicao).OrderBy(r => r.aluno.idAluno).
                Include(r => r.aluno).
                Include(r => r.pergunta)
                .ToList();
            return lista;
        }

        public static Resposta buscarResposta(Resposta r) {
            if(ctx.respostas.FirstOrDefault(x => x.idResposta==r.idResposta)!=null) {
                return ctx.respostas.FirstOrDefault(x => x.idResposta==r.idResposta);
            } else {
                return null;
            }
        }

        public static int buscaidLicaoporResposta(Resposta r) {
            List<Resposta> res = ctx.respostas.Where(x => x.idResposta==r.idResposta).Include(x => x.pergunta).ToList();
            try {
                return res[0].pergunta.licao.idLicao;
            } catch {
                return 0;
            }
        }

        public static Resposta buscarRespostaID(Resposta r) {
            if(ctx.respostas.FirstOrDefault(x => x.idResposta==r.idResposta)!=null) {
                return ctx.respostas.FirstOrDefault(x => x.idResposta==r.idResposta);
            } else {
                return null;
            }
        }

        public static Resposta buscarRespostaporID(int id) {
            if(ctx.respostas.FirstOrDefault(x => x.idResposta==id)!=null) {
                return ctx.respostas.FirstOrDefault(x => x.idResposta==id);
            } else {
                return null;
            }
        }
        public static void editarDescricaoResposta(Resposta r) {
            ctx.Database.ExecuteSqlCommand($"UPDATE dbo.Resposta SET des_Resposta = '{r.des_Resposta}' WHERE idResposta = {r.idResposta}");
            ctx.SaveChanges();
            EntitiFrame.RefreshAll();
        }

        public static void editarNota(Resposta r) {
            ctx.Database.ExecuteSqlCommand($"UPDATE dbo.Resposta SET nota = '{r.nota}' WHERE idResposta = {r.idResposta}");
            ctx.SaveChanges();
            EntitiFrame.RefreshAll();
        }

        public static void editarBoolEnviado(Resposta r) {
            ctx.Database.ExecuteSqlCommand($"UPDATE dbo.Resposta SET isEnviado = '{r.isEnviado}' WHERE idResposta = {r.idResposta}");
            ctx.SaveChanges();
            EntitiFrame.RefreshAll();
        }

        public static Boolean addResposta(Resposta r) {
            if(buscarRespostaID(r)==null) {
                ctx.respostas.Add(r);
                ctx.SaveChanges();
                return true;
            } else {
                editarDescricaoResposta(r);
                return true;
            }
        }
    }
}