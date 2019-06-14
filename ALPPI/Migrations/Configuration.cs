namespace ALPPI.Migrations {
    using ALPPI.DAO;
    using ALPPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto>{
        public Configuration(){
            AutomaticMigrationsEnabled = false;
            //Seed(new Contexto());
        }

        protected override void Seed(Contexto context){
            var sexos = new List<Sexo>{
                new Sexo{nme_Sexo="Masculino"},
                new Sexo{nme_Sexo="Feminino"}
            };
            sexos.ForEach(s => context.sexos.Add(s));
            context.SaveChanges();

            var cursos = new List<Curso>{
                new Curso{nme_Curso="Informatica", des_Curso="TI"},
                new Curso{nme_Curso="Alimentos", des_Curso="AL"}
            };
            cursos.ForEach(c => context.cursos.Add(c));
            context.SaveChanges();

            var turmas = new List<Turma>{
                new Turma{nme_Turma="INFO 2015", dta_InicioTurma = DateTime.Parse("01/06/2015"), dta_ConclusaoTurma = DateTime.Parse("01/06/2019"), ano_Turma=2015, curso = context.cursos.Find(1)}
            };
            turmas.ForEach(t => context.turmas.Add(t));
            context.SaveChanges();


            var adms = new List<Administrador>{
                new Administrador{nme_Administrador="Marccus", eml_Administrador="teste@ADM.com", senha_Administrador="1234"}
            };
            adms.ForEach(a => context.administradores.Add(a));
            context.SaveChanges();

            var estados = new List<Estado>{
                new Estado{nme_Estado="Acre", sigla_Estado="AC"},
                new Estado{nme_Estado="Alagoas", sigla_Estado="AL"},
                new Estado{nme_Estado="Amap�", sigla_Estado="AP"},
                new Estado{nme_Estado="Amazonas", sigla_Estado="AM"},
                new Estado{nme_Estado="Bahia", sigla_Estado="BA"},
                new Estado{nme_Estado="Cear�", sigla_Estado="CE"},
                new Estado{nme_Estado="Distrito Federal", sigla_Estado="DF"},
                new Estado{nme_Estado="Esp�rito Santo", sigla_Estado="ES"},
                new Estado{nme_Estado="Goi�s", sigla_Estado="GO"},
                new Estado{nme_Estado="Maranh�o", sigla_Estado="MA"},
                new Estado{nme_Estado="Mato Grosso", sigla_Estado="MT"},
                new Estado{nme_Estado="Mato Grosso do Sul", sigla_Estado="MS"},
                new Estado{nme_Estado="Minas Gerais", sigla_Estado="MG"},
                new Estado{nme_Estado="Par�", sigla_Estado="PA"},
                new Estado{nme_Estado="Para�ba", sigla_Estado="PB"},
                new Estado{nme_Estado="Paran�", sigla_Estado="PR"},
                new Estado{nme_Estado="Pernambuco", sigla_Estado="PE"},
                new Estado{nme_Estado="Piau�", sigla_Estado="PI"},
                new Estado{nme_Estado="Rio de Janeiro", sigla_Estado="RJ"},
                new Estado{nme_Estado="Rio Grande do Norte", sigla_Estado="RN"},
                new Estado{nme_Estado="Rio Grande do Sul", sigla_Estado="RS"},
                new Estado{nme_Estado="Rond�nia", sigla_Estado="RO"},
                new Estado{nme_Estado="Roraima", sigla_Estado="RR"},
                new Estado{nme_Estado="Santa Catarina", sigla_Estado="SC"},
                new Estado{nme_Estado="S�o Paulo", sigla_Estado="SP"},
                new Estado{nme_Estado="Sergipe", sigla_Estado="SE"},
                new Estado{nme_Estado="Tocantins", sigla_Estado="TO"}
            };
            estados.ForEach(e => context.estados.Add(e));
            context.SaveChanges();

            var materias = new List<Materia>{
                new Materia{nme_Materia="Matematica", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Portugues", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Biologia", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Quimica", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Fisica", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Artes", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Educa��o Fisica", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Filosofia", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Sociologia", des_Materia="Materia da grade"},
                new Materia{nme_Materia="JAVA", des_Materia="Materia da grade"},
                new Materia{nme_Materia="C", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Desenvolvimento Web", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Algoritimos", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Organiza��o e Arquitetura de Computadores", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Android", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Arduino", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Banco de Dados", des_Materia="Materia da grade"},
                new Materia{nme_Materia="Geografia", des_Materia="Materia da grade"}
            };
            materias.ForEach(m => context.materias.Add(m));
            context.SaveChanges();

            var conceitos = new List<Conceito>{
                new Conceito{nme_Conceito="A"},
                new Conceito{nme_Conceito="B"},
                new Conceito{nme_Conceito="C"},
                new Conceito{nme_Conceito="D"},
                new Conceito{nme_Conceito="SEM CONCEITO"}
            };
            conceitos.ForEach(c => context.conceitos.Add(c));
            context.SaveChanges();
        }
    }
}
