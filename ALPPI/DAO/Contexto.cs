using ALPPI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ALPPI.DAO {
    public class Contexto : DbContext {
        public Contexto() : base("AlppiContext") {}

        public DbSet<Administrador> administradores { get; set; }
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<Cidade> cidades { get; set; }
        public DbSet<Conceito> conceitos { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Licao> licoes { get; set; }
        public DbSet<Materia> materias { get; set; }
        public DbSet<Pergunta> perguntas { get; set; }
        public DbSet<Professor> professores { get; set; }
        public DbSet<Resposta> respostas { get; set; }
        public DbSet<Sexo> sexos { get; set; }
        public DbSet<Turma> turmas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}