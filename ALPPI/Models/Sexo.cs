using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALPPI.Models {
    public class Sexo {
        [Key]
        public int idSexo { get; set; }

        public string nme_Sexo { get; set; }

        #region Collections
        public virtual ICollection<Aluno> alunos { get; set; }
        public virtual ICollection<Professor> professores{ get; set; }
        #endregion
    }
}