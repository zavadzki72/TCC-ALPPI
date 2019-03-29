namespace ALPPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bancov3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        idAdminitrador = c.Int(nullable: false, identity: true),
                        nme_Administrador = c.String(nullable: false),
                        eml_Administrador = c.String(nullable: false),
                        senha_Administrador = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.idAdminitrador);
            
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        idAluno = c.Int(nullable: false, identity: true),
                        nme_Aluno = c.String(nullable: false),
                        matricula_Aluno = c.Long(nullable: false),
                        cpf_Aluno = c.Long(nullable: false),
                        dta_NascAluno = c.DateTime(nullable: false),
                        flg_Inativo = c.Int(nullable: false),
                        cidade_idCidade = c.Int(),
                        turma_idTurma = c.Int(),
                        sexo_idSexo = c.Int(),
                    })
                .PrimaryKey(t => t.idAluno)
                .ForeignKey("dbo.Cidade", t => t.cidade_idCidade)
                .ForeignKey("dbo.Turma", t => t.turma_idTurma)
                .ForeignKey("dbo.Sexo", t => t.sexo_idSexo)
                .Index(t => t.cidade_idCidade)
                .Index(t => t.turma_idTurma)
                .Index(t => t.sexo_idSexo);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        idCidade = c.Int(nullable: false, identity: true),
                        nme_Cidade = c.String(nullable: false),
                        estado_idEstado = c.Int(),
                    })
                .PrimaryKey(t => t.idCidade)
                .ForeignKey("dbo.Estado", t => t.estado_idEstado)
                .Index(t => t.estado_idEstado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        nme_Estado = c.String(nullable: false),
                        sigla_Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        idProfessor = c.Int(nullable: false, identity: true),
                        nme_Professor = c.String(nullable: false),
                        matricula_Professor = c.Long(nullable: false),
                        cpf_Professor = c.Long(nullable: false),
                        dta_NascProfessor = c.DateTime(nullable: false),
                        flg_Inativo = c.Int(nullable: false),
                        eml_Professor = c.String(nullable: false),
                        senha_Professor = c.String(nullable: false, maxLength: 100),
                        cidade_idCidade = c.Int(),
                        sexo_idSexo = c.Int(),
                    })
                .PrimaryKey(t => t.idProfessor)
                .ForeignKey("dbo.Cidade", t => t.cidade_idCidade)
                .ForeignKey("dbo.Sexo", t => t.sexo_idSexo)
                .Index(t => t.cidade_idCidade)
                .Index(t => t.sexo_idSexo);
            
            CreateTable(
                "dbo.Licao",
                c => new
                    {
                        idLicao = c.Int(nullable: false, identity: true),
                        nme_Licao = c.String(nullable: false),
                        dta_Inicio_Licao = c.DateTime(nullable: false),
                        Dta_Conclusao_Licao = c.DateTime(nullable: false),
                        flg_Ativo = c.Int(nullable: false),
                        conceito_idConceito = c.Int(),
                        materia_idMateria = c.Int(),
                        professor_idProfessor = c.Int(),
                        turma_idTurma = c.Int(),
                    })
                .PrimaryKey(t => t.idLicao)
                .ForeignKey("dbo.Conceito", t => t.conceito_idConceito)
                .ForeignKey("dbo.Materia", t => t.materia_idMateria)
                .ForeignKey("dbo.Professor", t => t.professor_idProfessor)
                .ForeignKey("dbo.Turma", t => t.turma_idTurma)
                .Index(t => t.conceito_idConceito)
                .Index(t => t.materia_idMateria)
                .Index(t => t.professor_idProfessor)
                .Index(t => t.turma_idTurma);
            
            CreateTable(
                "dbo.Conceito",
                c => new
                    {
                        idConceito = c.Int(nullable: false, identity: true),
                        nme_Conceito = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idConceito);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        idMateria = c.Int(nullable: false, identity: true),
                        nme_Materia = c.String(nullable: false),
                        des_Materia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idMateria);
            
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        idPergunta = c.Int(nullable: false, identity: true),
                        des_Pergunta = c.String(nullable: false),
                        des_Resposta_Padrao_Pergunta = c.String(nullable: false),
                        licao_idLicao = c.Int(),
                    })
                .PrimaryKey(t => t.idPergunta)
                .ForeignKey("dbo.Licao", t => t.licao_idLicao)
                .Index(t => t.licao_idLicao);
            
            CreateTable(
                "dbo.Resposta",
                c => new
                    {
                        idResposta = c.Int(nullable: false, identity: true),
                        des_Resposta = c.String(nullable: false),
                        aluno_idAluno = c.Int(),
                        pergunta_idPergunta = c.Int(),
                    })
                .PrimaryKey(t => t.idResposta)
                .ForeignKey("dbo.Aluno", t => t.aluno_idAluno)
                .ForeignKey("dbo.Pergunta", t => t.pergunta_idPergunta)
                .Index(t => t.aluno_idAluno)
                .Index(t => t.pergunta_idPergunta);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        idTurma = c.Int(nullable: false, identity: true),
                        nme_Turma = c.String(nullable: false),
                        dta_InicioTurma = c.DateTime(nullable: false),
                        dta_ConclusaoTurma = c.DateTime(nullable: false),
                        ano_Turma = c.Int(nullable: false),
                        flg_Inativo = c.Int(nullable: false),
                        curso_idCurso = c.Int(),
                    })
                .PrimaryKey(t => t.idTurma)
                .ForeignKey("dbo.Curso", t => t.curso_idCurso)
                .Index(t => t.curso_idCurso);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        idCurso = c.Int(nullable: false, identity: true),
                        nme_Curso = c.String(nullable: false),
                        des_Curso = c.String(nullable: false),
                        flg_Inativo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCurso);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        idSexo = c.Int(nullable: false, identity: true),
                        nme_Sexo = c.String(),
                    })
                .PrimaryKey(t => t.idSexo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professor", "sexo_idSexo", "dbo.Sexo");
            DropForeignKey("dbo.Aluno", "sexo_idSexo", "dbo.Sexo");
            DropForeignKey("dbo.Licao", "turma_idTurma", "dbo.Turma");
            DropForeignKey("dbo.Turma", "curso_idCurso", "dbo.Curso");
            DropForeignKey("dbo.Aluno", "turma_idTurma", "dbo.Turma");
            DropForeignKey("dbo.Licao", "professor_idProfessor", "dbo.Professor");
            DropForeignKey("dbo.Resposta", "pergunta_idPergunta", "dbo.Pergunta");
            DropForeignKey("dbo.Resposta", "aluno_idAluno", "dbo.Aluno");
            DropForeignKey("dbo.Pergunta", "licao_idLicao", "dbo.Licao");
            DropForeignKey("dbo.Licao", "materia_idMateria", "dbo.Materia");
            DropForeignKey("dbo.Licao", "conceito_idConceito", "dbo.Conceito");
            DropForeignKey("dbo.Professor", "cidade_idCidade", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "estado_idEstado", "dbo.Estado");
            DropForeignKey("dbo.Aluno", "cidade_idCidade", "dbo.Cidade");
            DropIndex("dbo.Turma", new[] { "curso_idCurso" });
            DropIndex("dbo.Resposta", new[] { "pergunta_idPergunta" });
            DropIndex("dbo.Resposta", new[] { "aluno_idAluno" });
            DropIndex("dbo.Pergunta", new[] { "licao_idLicao" });
            DropIndex("dbo.Licao", new[] { "turma_idTurma" });
            DropIndex("dbo.Licao", new[] { "professor_idProfessor" });
            DropIndex("dbo.Licao", new[] { "materia_idMateria" });
            DropIndex("dbo.Licao", new[] { "conceito_idConceito" });
            DropIndex("dbo.Professor", new[] { "sexo_idSexo" });
            DropIndex("dbo.Professor", new[] { "cidade_idCidade" });
            DropIndex("dbo.Cidade", new[] { "estado_idEstado" });
            DropIndex("dbo.Aluno", new[] { "sexo_idSexo" });
            DropIndex("dbo.Aluno", new[] { "turma_idTurma" });
            DropIndex("dbo.Aluno", new[] { "cidade_idCidade" });
            DropTable("dbo.Sexo");
            DropTable("dbo.Curso");
            DropTable("dbo.Turma");
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
            DropTable("dbo.Materia");
            DropTable("dbo.Conceito");
            DropTable("dbo.Licao");
            DropTable("dbo.Professor");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Aluno");
            DropTable("dbo.Administrador");
        }
    }
}
